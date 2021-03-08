using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;

public class DialogueManager : MonoBehaviour
{
    public GameObject canvas;

    public DialogueRunner dialogueRunner;

    public void SetCanvasActive(bool isActive) {
        canvas.SetActive(isActive);
    }
}
