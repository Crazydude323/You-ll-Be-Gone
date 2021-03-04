using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnlockInputTrigger : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        // detect if collider is Player
        if (other.CompareTag("Player"))
        {
            other.GetComponent<PlayerMovement>().UnlockInput();
        }
    }
}
