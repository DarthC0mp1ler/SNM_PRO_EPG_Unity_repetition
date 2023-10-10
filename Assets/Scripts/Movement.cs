using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Stats))]
public class Movement : MonoBehaviour
{
    public float speed = 3000f;
    public float sprintSpeed = 7000f;

    public float jumpForce = 200;

    private Rigidbody2D rb;
    private Stats stats;

    private bool isGrounded = true;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        stats = GetComponent<Stats>();
    }


    void Update()
    {
        if (stats.IsAlive())
        {
            HandleMove();
            HandleJump();
        }
    }

    private void HandleMove() 
    {
        float delta = Input.GetAxis("Horizontal");
        float tmpSpeed = 0;

        if (Input.GetKey(KeyCode.LeftShift))
        {
            tmpSpeed = sprintSpeed;
        }
        else
        {
            tmpSpeed = speed;
        }

        rb.velocity = new Vector2
        (
            delta * tmpSpeed * Time.deltaTime,
            rb.velocity.y
        );
    }

    private void HandleJump() 
    {
        if (isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(Vector2.up * jumpForce);
            isGrounded = false;
        }
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("floor"))
        {
            isGrounded = true;
        }
    }

}
