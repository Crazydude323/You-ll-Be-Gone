using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrimaryAnimationTrigger : MonoBehaviour
{
    [SerializeField] DialogueManager dialogueManager;

    public void OnPrimaryOut()
    {
        dialogueManager.OnPrimaryOut();
    }
}
