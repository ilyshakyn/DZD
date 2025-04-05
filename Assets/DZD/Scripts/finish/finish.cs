using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class finish : MonoBehaviour
{
    private GameObject player;
    [SerializeField] private GameObject girl;
    [SerializeField] private GameObject tower;



    private void Start()
    {
        player = GameObject.FindWithTag("Player");
        
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Destroy(tower);
            girl.GetComponent<jumpingprincess>().enabled = true;
        }
    }
}
