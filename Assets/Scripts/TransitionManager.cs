using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TransitionManager : MonoBehaviour
{
    private Animator animator;
    private PlayerMovement playerMovement;

    private string sceneToLoad;

    private void Start()
    {
        DontDestroyOnLoad(transform.gameObject);
        animator = this.gameObject.GetComponent<Animator>();
        playerMovement = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
    }

    // fade to black
    public void FadeToScene (string sceneName)
    {
        sceneToLoad = sceneName;
        animator.SetTrigger("FadeOut");
    }

    // triggered when fade to black is complete
    public void OnFadeOutComplete()
    {
        SceneManager.LoadScene(sceneToLoad);
        animator.SetTrigger("FadeIn");
    }

    public void CutToScene (string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
