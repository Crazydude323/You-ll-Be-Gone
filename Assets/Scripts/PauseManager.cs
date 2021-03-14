using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseManager : MonoBehaviour
{

    [SerializeField] GameObject Notebook;

private void Update() {
    if (Input.GetButtonDown("Cancel")) {
        Notebook.SetActive(true);
    }
}

public void CloseDialogue() {
    Notebook.SetActive(false);
}
    
}
