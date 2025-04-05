using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSound : MonoBehaviour
{
    public AudioSource audioSourceEffects;  
    public AudioSource audioSourceMusic;  

    public AudioClip jumpSound;           
    public AudioClip backgroundMusic;      

    private bool isGrounded = true;        

    private void Start()
    {
        
        audioSourceMusic.clip = backgroundMusic;
        audioSourceMusic.volume = 0.03f;
        audioSourceMusic.loop = true;  

        audioSourceMusic.Play();      
    }

    private void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            Jump();
        }
    }

    private void Jump()
    {
        isGrounded = false;

        
        audioSourceEffects.PlayOneShot(jumpSound);

        
        Debug.Log("Jump!");
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
