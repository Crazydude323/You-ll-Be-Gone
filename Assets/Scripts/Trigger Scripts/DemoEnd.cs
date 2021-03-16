using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DemoEnd : MonoBehaviour
{
    public Vector2 exitDirection;
    private TransitionManager transitionManager;

    private void Awake()
    {
        transitionManager = GameObject.Find("TransitionManager").GetComponent<TransitionManager>();
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        // detect if collider is Player
        if(other.CompareTag("Player"))
        {
            if (!other.GetComponent<PlayerMovement>().InputIsLocked)
            {
                transitionManager.FadeToScene("DemoEnd");
                other.GetComponent<PlayerMovement>().LockInput(exitDirection);
            }
        }
    }
}
