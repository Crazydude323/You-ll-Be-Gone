using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WMapEnter : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        GameObject gameUI = GameObject.Find("GameUI");
        gameUI.SendMessage("addPoint", SendMessageOptions.DontRequireReceiver);

        Destroy(this.gameObject);
        Destroy(other.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
