using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public Transform player;
    [SerializeField] private AudioSource audio;
    public GameObject deadZone;
    public  int checkpoints = 1;
    public GameObject canvasManager;
    public GameObject canvas;
  
    public static GameController Instance { get; set; }

    private void Awake()
    {
        
    }
    public void RestartFromCheckpoint()
    {
        Vector3 checkpointPosition = CheckpointManager.Instance.GetCheckpointPosition();
      
        player.position = checkpointPosition;
        deadZone.GetComponent<DeadPlayer>().isDeadZone = false; 

       
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
           
            if (checkpoints > 0)
            {
                checkpoints--;
                RestartFromCheckpoint();
            }
            else
            {
                if (canvasManager.GetComponent<OpenCanvas>().isOpen == true)
                {
                    return;
                }
                else
                {
                    canvas.SetActive(true);
                    canvasManager.GetComponent<OpenCanvas>().isOpen = true;
                }
              
            }
           


           
        }
    }
}
