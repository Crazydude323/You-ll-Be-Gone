using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TransitionManager : MonoBehaviour
{
    private Animator animator;

    private string sceneToLoad;

    private void Start()
    {
        DontDestroyOnLoad(transform.gameObject);
        animator = this.gameObject.GetComponent<Animator>();
    }

    public void FadeToScene (string sceneName)
    {
        sceneToLoad = sceneName;
        animator.SetTrigger("FadeOut");
    }

    public void CutToScene (string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void OnFadeComplete()
    {
        SceneManager.LoadScene(sceneToLoad);
        animator.SetTrigger("FadeIn");
    }
}
