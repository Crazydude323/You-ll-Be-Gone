using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WMapEnter : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        SceneManager.LoadScene("WMap");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
