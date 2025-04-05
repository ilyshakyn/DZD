using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpPlatforms : MonoBehaviour
{
   
    [SerializeField] private Rigidbody2D playerRb;
    public float doodleJumpForce = 5f;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            playerRb.AddForce(new Vector2(0, doodleJumpForce), ForceMode2D.Impulse);
        }
    }
    
}
