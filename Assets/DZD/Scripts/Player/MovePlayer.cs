using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayer : MonoBehaviour
{
    public float speed = 5f;
    private Rigidbody2D rb;
    public float jumpForce = 10f;
    public float horizontal;
    private Vector2 movement;
    public bool isGrounded = false;

   

    private void Start()//срабатывает первый кадр в секунду
    {
      
        rb = GetComponent<Rigidbody2D>();
      
    }

    private void Update()//срабатывает каждый кадр в секунду
    {
        horizontal = Input.GetAxis("Horizontal");
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x,0);
            rb.AddForce(Vector2.up * jumpForce,ForceMode2D.Impulse);
            isGrounded = false;
        }


       

    }

    private void FixedUpdate()//срабатывает 4 раза за каждый кадр в секунду
    {
       movement = new Vector2(horizontal * speed, rb.velocity.y);
       rb.velocity = movement;
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }

   
}