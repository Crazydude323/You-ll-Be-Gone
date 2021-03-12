using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCDialogue : MonoBehaviour
{
    [Header("Dialogue")]
    [SerializeField] string yarnStartNode = "Start";
    [SerializeField] YarnProgram yarnDialogue;
    [SerializeField] SpeakerData speakerData;
    DialogueManager dialogueManager;

    [Header("Components")]
    [SerializeField] GameObject chatBubble;

    GameObject npc;
    SpriteRenderer spriteRenderer;
    Animator animator;
    Vector3 defaultScale;

    GameObject player;
    PlayerMovement playerMovement;

    [Header("Booleans")]
    [SerializeField] bool shouldLookAtPlayer;
    [SerializeField] bool shouldRevertDirection;
    bool isClose;

    private void Awake()
    {
        //find Dialogue Manager
        dialogueManager = GameObject.FindGameObjectWithTag("DialogueManager").GetComponent<DialogueManager>();

        //find NPC
        npc = transform.parent.gameObject;
        spriteRenderer = npc.GetComponent<SpriteRenderer>();
        if (npc.GetComponent<Animator>() != null)
            animator = npc.GetComponent<Animator>();

        //find Player
        player = GameObject.FindGameObjectWithTag("Player");
        playerMovement = player.GetComponent<PlayerMovement>();
    }

    private void Start()
    {
        chatBubble.SetActive(false);                                //hide chat bubble
        dialogueManager.primaryDialogueRunner.Add(yarnDialogue);    //send .yarn to the Dialogue Manager
        dialogueManager.AddSpeaker(speakerData);                    //send this NPC's speaker data to the DM
        defaultScale = npc.transform.localScale;                    //save starting direction of NPC
    }

    private void Update()
    {
        if (!isClose) return;

        if (Input.GetButtonDown("Interact") && !playerMovement.InputIsLocked)
            StartDialogue();

        if (shouldLookAtPlayer)
            LookAtPlayer();
    }

    //shows the chat bubble
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject == player)
        {
            isClose = true;
            animator.SetBool("isClose", isClose);
            chatBubble.SetActive(true);
        }
    }

    //hides the chat bubble & resets npc direction
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject == player)
        {
            isClose = false;
            animator.SetBool("isClose", isClose);
            chatBubble.SetActive(false);
            if (!shouldRevertDirection) return;
            npc.transform.localScale = defaultScale;
        }
    }

    //flips the NPC object toward the player's position
    private void LookAtPlayer()
    {
        Vector3 currentScale = npc.transform.localScale;
        currentScale.x = Mathf.Sign(player.transform.position.x - npc.transform.position.x);
        npc.transform.localScale = currentScale;
    }

    //tells Diallogue Manager to start at this NPC's node
    private void StartDialogue()
    {
        Debug.Log("Starting Dialogue with " + this.gameObject.name, this);
        //START DIALOGUE
        dialogueManager.BeginPrimary();
        dialogueManager.primaryDialogueRunner.StartDialogue(yarnStartNode);
    }
}
