using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class NotificationManager : MonoBehaviour
{
    public enum IconType { Map, Note };
    Animator animator;

    [Header("Images")]
    [SerializeField] Sprite mapIcon;
    [SerializeField] Sprite noteIcon;

    [Header("UI Elements")]
    [SerializeField] Image icon;
    [SerializeField] TextMeshProUGUI txt_header;
    [SerializeField] TextMeshProUGUI txt_message;

    private void Awake()
    {
        animator = this.GetComponent<Animator>();
    }

    public void ShowNotification(IconType iconType, string header, string message)
    {
        this.GetComponent<AudioSource>().Play();

        switch (iconType)
        {
            default:
            case IconType.Map:
                icon.sprite = mapIcon;
                break;
            case IconType.Note:
                icon.sprite = noteIcon;
                break;
        }

        txt_header.text = header;
        txt_message.text = message;

        animator.SetTrigger("Show");
    }
}
