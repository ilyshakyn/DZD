using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenCanvas : MonoBehaviour
{
    public GameObject exitCanvas;
    public bool isOpen = false;
 

    private void Start()
    {
        exitCanvas.SetActive(false);
    }

   
    void Update()
    {
       
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isOpen == false )
            {
                exitCanvas.SetActive(true);
                isOpen = true;
            }
            else
            {
                exitCanvas.SetActive(false);
                isOpen = false;
            }
       
        }
       
    }
}
