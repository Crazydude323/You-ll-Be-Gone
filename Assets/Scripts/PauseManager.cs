using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseManager : MonoBehaviour
{

    [SerializeField] GameObject Notebook;

    void Start()
    {
        Notebook.SetActive(false);
    }

    private void Update() {
        if (Input.GetButtonDown("Cancel")) {
            if(!Notebook.activeSelf) Notebook.SetActive(true);
            else Notebook.SetActive(false);
        }
    }

    public void CloseDialogue() {
        Notebook.SetActive(false);
    }
    
}
