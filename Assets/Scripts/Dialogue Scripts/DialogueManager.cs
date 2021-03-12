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
    public DialogueRunner primaryDialogueRunner;
    public DialogueRunner secondaryDialogueRunner;
    [SerializeField] Animator primaryAnimator;
    [SerializeField] Animator secondaryAnimator;
    PlayerMovement playerMovement;
    bool isDialogueRunning;

    [Header("UI Elements")]
    [SerializeField] Image leftCharacterSplash;
    [SerializeField] Image rightCharacterSplash;
    [SerializeField] Image speechBubble;
    [SerializeField] TextMeshProUGUI txt_speakerName;

    [Header("Player Emotions")]
    [SerializeField] SpeakerData[] playerEmotions;

    private void Awake()
    {
        playerMovement = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
        primaryDialogueRunner.AddCommandHandler("Speaker:", SetSpeaker);
        primaryDialogueRunner.AddCommandHandler("Splash:", SetSplash);
    }

    private void Start()
    {
        foreach(SpeakerData playerEmotion in playerEmotions)
        {
            AddSpeaker(playerEmotion);
        }
    }

    public void AddSpeaker(SpeakerData data)
    {
        if (speakerDatabase.ContainsKey(data.speakerName))
        {
            Debug.LogWarningFormat("Attempting to add {0} into speaker database, but it already exists!");
            return;
        }

        speakerDatabase.Add(data.speakerName, data);
    }

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

    void SetSplash(string[] info)
    {
        string side = info[0];
        string name = info[1];
        string emotion = info.Length > 2 ? info[2].ToLower() : SpeakerData.STATE_NEUTRAL;

        if (speakerDatabase.TryGetValue(name, out SpeakerData data))
        {
            switch (side)
            {
                case "L":
                    leftCharacterSplash.sprite = data.GetStateSplash(emotion);
                    leftCharacterSplash.SetNativeSize();
                    break;
                default:
                case "R":
                    rightCharacterSplash.sprite = data.GetStateSplash(emotion);
                    rightCharacterSplash.SetNativeSize();
                    break;
            }
            return;
        }
        Debug.LogErrorFormat("Could not set splash for unknown speaker {0}", name);
    }

    public void BeginPrimary()
    {
        isDialogueRunning = true;
        primaryAnimator.SetTrigger("Begin");
        playerMovement.LockInput();
    }

    public void EndPrimary()
    {
        isDialogueRunning = false;
        primaryAnimator.SetTrigger("End");
    }

    public void OnPrimaryOut()
    {
        if (isDialogueRunning) return;
        playerMovement.UnlockInput();
    }

    public void BeginSecondary()
    {
        isDialogueRunning = true;
        secondaryAnimator.SetTrigger("Begin");
    }

    public void EndSecondary()
    {
        secondaryAnimator.SetTrigger("End");
    }
}
