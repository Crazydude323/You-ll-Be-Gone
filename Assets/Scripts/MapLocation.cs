using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MapLocation : MonoBehaviour
{
    [Header("Configuration")]
    [SerializeField] Image thumbnail;
    [SerializeField] Image title;
    [SerializeField] string levelDestination;
    TransitionManager transitionManager;

    [Header("Colors")]
    [SerializeField] Color defaultColor = new Color(1, 1, 1);
    [SerializeField] Color hoverColor = new Color(.5f, .5f, 1);
    [SerializeField] Color clickColor = new Color(0, 0, 1);

    [Header("Values")]
    bool isHovering;

    private void Awake()
    {
        transitionManager = GameObject.FindGameObjectWithTag("TransitionManager").GetComponent<TransitionManager>();
    }

    private void Start()
    {
        thumbnail.color = defaultColor;
        title.color = defaultColor;
    }

    private void Update()
    {
        if (!isHovering) return;

        if (Input.GetMouseButton(0))
        {
            thumbnail.color = clickColor;
            title.color = clickColor;
            transitionManager.FadeToScene(levelDestination);
            return;
        }

        if (Input.GetMouseButtonUp(0))
        {
            thumbnail.color = hoverColor;
            title.color = hoverColor;
            return;
        }
    }

    public void OnHover()
    {
        isHovering = true;
        thumbnail.color = hoverColor;
        title.color = hoverColor;
    }

    public void OffHover()
    {
        isHovering = false;
        thumbnail.color = defaultColor;
        title.color = defaultColor;
    }
}
