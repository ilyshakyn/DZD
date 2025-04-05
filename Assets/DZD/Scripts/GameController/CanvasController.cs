using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasController : MonoBehaviour
{
    [SerializeField] private OpenCanvas canvas;
    [SerializeField] private AudioSource audio;
    [SerializeField] private DeadPlayer deadZone;
    private WeaponsKryck playweapon;
    private MovePlayer playermove;

    private void Start()
    {
        canvas = FindObjectOfType<OpenCanvas>();
        playweapon = FindObjectOfType<WeaponsKryck>();
        playermove = FindObjectOfType<MovePlayer>();
    }

    private void Update()
    {
        if (canvas.isOpen == true)
        { 
            
            Time.timeScale = 0f;
           
            playweapon.enabled = false;
            playermove.enabled = false;
            audio.enabled = false;
        }
        else
        {
            if (deadZone.isDeadZone == true)
            {
                playweapon.enabled = false;
                playermove.enabled = false;
                audio.enabled = false;
            }
            else
            {
                playweapon.enabled = true;
                playermove.enabled = true;
                audio.enabled = true;
            }
            Time.timeScale = 1f;
            
        }
    }

}
