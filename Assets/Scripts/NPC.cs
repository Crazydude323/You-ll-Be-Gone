using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{
    [Header("Values")]
    private bool isClose = false;

    [Header("Components")]
    Transform prompt;
    SpriteRenderer sr;
    SpriteRenderer promptSr;
    Animator animator;

    public string characterName = "";

    public string talkToNode = "";

    [Header("Optional")]
    public YarnProgram scriptToLoad;

    private void Start()
    {
        prompt = this.gameObject.transform.Find("TextBubblePrompt");
        sr = this.GetComponent<SpriteRenderer>();
        promptSr = prompt.gameObject.GetComponent<SpriteRenderer>();
        if(this.GetComponent<Animator>() != null)
        animator = this.GetComponent<Animator>();

        
    }

    private void Update()
    {
        if (Input.GetButtonDown("Interact") && isClose)
        {
            Debug.Log("Starting Dialogue with " + this.gameObject.name);
            //START DIALOGUE
        }
    }

    //moves NPC sprite behind and in front of MC sprite
    public void SetOrder(int order){
        sr.sortingOrder = order;
        promptSr.sortingOrder = order;
    }

    //determines whether MC is in range
    public void SetIsClose(bool boolean)
    {
        isClose = boolean;
        if(animator != null)
        animator.SetBool("isClose", isClose);
    }

    public void SetPromptActive(int boolean)
    {
        bool isActive = (boolean == 1);
        prompt.gameObject.SetActive(isActive);
    }
}
