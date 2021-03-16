using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class TransitionManager : MonoBehaviour
{
    [Header("Components")]
    [SerializeField] TextMeshProUGUI txt_sceneTitle;
    private Animator animator;
    private PlayerMovement playerMovement;

    [Header("Variables")]
    [SerializeField] string sceneTitle;
    [SerializeField] bool fadeInOnStart = true;
    private string sceneToLoad;

    private void Awake()
    {
        animator = this.gameObject.GetComponent<Animator>();
        if(GameObject.FindGameObjectWithTag("Player"))
            playerMovement = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
    }

    private void Start()
    {
        if (fadeInOnStart) animator.SetTrigger("FadeIn");
        txt_sceneTitle.text = sceneTitle;
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
