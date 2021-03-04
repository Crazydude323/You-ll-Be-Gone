using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldMapTrigger : MonoBehaviour
{
    public Vector2 direction;
    private TransitionManager transitionManager;

    private void Start()
    {
        transitionManager = GameObject.Find("TransitionManager").GetComponent<TransitionManager>();
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        // detect if collider is Player
        if(other.tag == "Player")
        {
            transitionManager.FadeToScene("WorldMap");
            other.GetComponent<PlayerMovement>().LockInput(direction);
        }
    }
}
