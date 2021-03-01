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

    private void Start()
    {
        prompt = this.gameObject.transform.Find("TextBubblePrompt");
        sr = this.GetComponent<SpriteRenderer>();
        promptSr = prompt.gameObject.GetComponent<SpriteRenderer>();
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
        prompt.gameObject.SetActive(isClose);
    }
}
