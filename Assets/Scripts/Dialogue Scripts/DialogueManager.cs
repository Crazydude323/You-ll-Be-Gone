using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Yarn.Unity;

public class DialogueManager : MonoBehaviour
{
    Dictionary<string, SpeakerData> speakerDatabase = new Dictionary<string, SpeakerData>();

    [Header("Configuration")]
    public DialogueRunner dialogueRunner;
    Animator animator;
    PlayerMovement playerMovement;
    public bool isDialogueRunning;  //I haven't used this yet. I just thought it might be useful for something.

    [Header("UI Elements")]
    [SerializeField] Image backgroundDim;
    [SerializeField] Image leftCharacterSplash;
    [SerializeField] Image rightCharacterSplash;
    [SerializeField] Image speechBubble;
    [SerializeField] TextMeshProUGUI txt_speakerName;
    [SerializeField] Button buttttton;

    [Header("Images")]
    [SerializeField] Sprite[] bubbleTypes;
    string[] bubbleNames = new string[] { "speech", "box", "thought" };

    [Header("Player Emotions")]
    [SerializeField] SpeakerData[] emotionSpeakers;
    [SerializeField] Color[] emotionColors;
    string[] emotionNames = new string[] { "emptiness", "embarrassment", "love", "anger", "courage", "surprise", "excitement", "disgust", "happiness", "envy", "confusion", "worry", "sadness", "pride", "fear" };

    #region Configuration & Setup

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            print("f was pressed.");
            buttttton.gameObject.SetActive(true);
        }
    }

    private void Awake()
    {
        animator = this.GetComponent<Animator>();
        playerMovement = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();

        //links yarn commands to this class's methods
        dialogueRunner.AddCommandHandler("Speaker:", SetSpeaker);
        dialogueRunner.AddCommandHandler("SplashLeft:", SetSplashL);
        dialogueRunner.AddCommandHandler("SplashRight:", SetSplashR);
        dialogueRunner.AddCommandHandler("Bubble:", SetSpeechBubble);
        dialogueRunner.AddCommandHandler("Background:", SetBackground);
    }

    private void Start()
    {
        foreach(SpeakerData playerEmotion in emotionSpeakers)
        {
            AddSpeaker(playerEmotion);
        }

        backgroundDim.color = Color.black;
    }

    //adds a given SpeakerData scriptable object into the "speakerDatabase" dictionary
    public void AddSpeaker(SpeakerData data)
    {
        if (speakerDatabase.ContainsKey(data.speakerName))
        {
            Debug.LogWarningFormat("Attempting to add {0} into speaker database, but it already exists!");
            return;
        }

        speakerDatabase.Add(data.speakerName, data);
    }

    #endregion

    #region Yarn Commands

    //  <<Speaker: [L or R] [speaker name]>>        Flips speech bubble to left or right side & displays speaker name.
    void SetSpeaker(string[] info)
    {
        string side = info[0];
        string name = info[1];

        switch (side)
        {
            default:
            case "L":
                speechBubble.transform.localScale = new Vector3(1, 1, 1);
                break;
            case "R":
                speechBubble.transform.localScale = new Vector3(-1, 1, 1);
                break;
        }

        txt_speakerName.text = name;
    }

    //  <<Splash[L or R]: [speaker name] [state]>>  Sets left or right splash to given speaker's corresponding state. USE ADJECTIVES
    void SetSplashL(string[] info)
    {
        string name = info[0];
        string emotion = info.Length > 1 ? info[1].ToLower() : SpeakerData.STATE_NEUTRAL;

        if (speakerDatabase.TryGetValue(name, out SpeakerData data))
        {
            leftCharacterSplash.sprite = data.GetStateSplash(emotion);
            leftCharacterSplash.SetNativeSize();
            return;
        }
        Debug.LogErrorFormat("Could not set splash for unknown speaker {0}", name);
    }
    void SetSplashR(string[] info)
    {
        string name = info[0];
        string emotion = info.Length > 1 ? info[1].ToLower() : SpeakerData.STATE_NEUTRAL;

        if (speakerDatabase.TryGetValue(name, out SpeakerData data))
        {
            rightCharacterSplash.sprite = data.GetStateSplash(emotion);
            rightCharacterSplash.SetNativeSize();
            return;
        }
        Debug.LogErrorFormat("Could not set splash for unknown speaker {0}", name);
    }

    //  <<Bubble: [bubble type]>>                   Sets the speech bubble to whichever type specified.
    void SetSpeechBubble(string[] info)
    {
        string bubbleName = info[0].ToLower();
        int bubbleIndex = System.Array.IndexOf(bubbleNames, bubbleName);

        //if the bubble isn't in the list, default it to "speech".
        if (bubbleIndex < 0) bubbleIndex = 0;

        speechBubble.sprite = bubbleTypes[bubbleIndex];
        speechBubble.SetNativeSize();
    }

    //  <<Background: [emotion]>>                   Sets background color to corresponding emotion. USE NOUNS
    void SetBackground(string[] info)
    {
        string emotionName = info[0].ToLower();
        int emotionIndex = System.Array.IndexOf(emotionNames, emotionName);

        //if the emotion isn't in the list, turn the background back to default.
        if (emotionIndex < 0)
        {
            StartCoroutine(FadeToColor(Color.black));
            return;
        }

        StartCoroutine(FadeToColor(emotionColors[emotionIndex]));
    }

    #endregion

    #region Events

    //called by the NPCDialogue class,              Triggers enter animation & locks input.
    public void BeginDialogue()
    {
        isDialogueRunning = true;
        animator.SetTrigger("Begin");
        playerMovement.LockInput();
    }

    //called by the dialogue runner,                Triggers exit animation.
    public void EndDialogue()
    {
        isDialogueRunning = false;
        animator.SetTrigger("End");
    }

    //called by the UI animation ater exiting,      Unlocks input.
    public void OnDialogueOut()
    {
        if (isDialogueRunning) return;
        playerMovement.UnlockInput();
        backgroundDim.color = Color.black;
    }

    #endregion

    //called by SetBackground
    IEnumerator FadeToColor(Color endColor)
    {
        Color startColor = backgroundDim.color;
        print("fading to color" + endColor);
        float time = 0.5f;
        float elaspedTime = 0;
        while (elaspedTime < time)
        {
            elaspedTime += Time.deltaTime;
            backgroundDim.color = Color.Lerp(startColor, endColor, elaspedTime/time);
            yield return null;
        }
    }
}
