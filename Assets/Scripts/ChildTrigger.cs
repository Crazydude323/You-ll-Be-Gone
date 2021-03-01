using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChildTrigger : MonoBehaviour
{
    public string targetTag;

    [Header("Enter")]
    public string enterMessage;
    public float enterValue;

    [Header("Exit")]
    public string exitMessage;
    public float exitValue;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == targetTag)
        {
            SendMessageUpwards(enterMessage, enterValue, SendMessageOptions.DontRequireReceiver);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == targetTag)
        {
            SendMessageUpwards(exitMessage, exitValue, SendMessageOptions.DontRequireReceiver);
        }
    }
}
