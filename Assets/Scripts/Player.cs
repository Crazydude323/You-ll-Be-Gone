using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public float speed=10f;
    private Rigidbody2D r2d;

    // Start is called before the first frame update
    void Start()
    {
        r2d = this.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float vertical = Input.GetAxis("Vertical");
        float horizontal = Input.GetAxis("Horizontal");
        Vector2 movement = new Vector2(horizontal, vertical);
        movement.Normalize();

        r2d.velocity = movement * speed * Time.deltaTime;
        
    }
}
