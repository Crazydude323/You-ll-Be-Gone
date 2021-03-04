using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Variables")]
    public float speed=1f;
    private Vector2 movement;
    private bool isInputLocked = false;

    [Header("Components")]
    private Rigidbody2D r2d;
    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        r2d = this.GetComponent<Rigidbody2D>();
        animator = this.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!isInputLocked) ReceiveInput();
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
            this.gameObject.transform.localScale = new Vector3(1, 1, 1);
        }
        else if (movement.x > 0)
        {
            this.gameObject.transform.localScale = new Vector3(-1, 1, 1);
        }

        //update animator
        animator.SetFloat("speed", Mathf.Abs(movement.magnitude));
    }

    public void LockInput(Vector2 lockDirection)
    {
        isInputLocked = true;
        movement = lockDirection;
    }
    public void UnlockInput(Vector2 direction)
    {
        isInputLocked = false;
    }
}
