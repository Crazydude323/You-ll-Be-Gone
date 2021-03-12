using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public bool InputIsLocked { get { return inputIsLocked; } }

    [Header("Variables")]
    [SerializeField] float speed=1f;
    [SerializeField] Vector2 defaultDirection;
    [SerializeField] bool inputIsLocked = true;
    private Vector2 movement;

    [Header("Components")]
    private Rigidbody2D r2d;
    private Animator animator;

    [Header("Dialogue")]
    [SerializeField] SpeakerData speakerData;
    DialogueManager dialogueManager;

    // Start is called before the first frame update
    private void Awake()
    {
        r2d = this.GetComponent<Rigidbody2D>();
        animator = this.GetComponent<Animator>();

        dialogueManager = GameObject.FindGameObjectWithTag("DialogueManager").GetComponent<DialogueManager>();
    }

    void Start()
    {
        if (inputIsLocked) movement = defaultDirection;

        dialogueManager.AddSpeaker(speakerData);
    }

    // Update is called once per frame
    void Update()
    {
        if (inputIsLocked) return;

        ReceiveInput();
    }

    private void ReceiveInput()
    {
        float vertical = Input.GetAxis("Vertical");
        float horizontal = Input.GetAxis("Horizontal");
        movement = new Vector2(horizontal, vertical);
        movement.Normalize();
    }

    private void FixedUpdate()
    {
        //move sprite
        r2d.velocity = movement * speed;

        //flip player based on movement direction
        if (movement.x < 0)
        {
            this.gameObject.transform.localScale = new Vector3(-1, 1, 1);
        }
        else if (movement.x > 0)
        {
            this.gameObject.transform.localScale = new Vector3(1, 1, 1);
        }

        //update animator
        animator.SetFloat("speed", Mathf.Abs(movement.magnitude));
    }

    public void LockInput(Vector2 lockDirection)
    {
        inputIsLocked = true;
        movement = lockDirection;
    }

    public void LockInput()
    {
        inputIsLocked = true;
        movement = new Vector2();
    }

    public void UnlockInput()
    {
        inputIsLocked = false;
    }
}
