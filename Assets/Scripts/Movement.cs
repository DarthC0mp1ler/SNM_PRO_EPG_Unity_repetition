using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float speed = 5.5f;

    public Rigidbody2D rb;

    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    
    void Update()
    {
        float delta = Input.GetAxis("Horizontal"); 
        
        //Vector2 newPosition = 
            new Vector2(
                rb.position.x + delta * speed * Time.deltaTime,
                rb.position.y);

        //rb.MovePosition(newPosition);

        rb.velocity = new Vector2
            (
                delta * speed * Time.deltaTime,
                rb.velocity.y
            );
    }

    
}
