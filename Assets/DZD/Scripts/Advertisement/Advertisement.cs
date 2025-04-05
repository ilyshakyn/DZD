using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using YG;

public class Advertisement : MonoBehaviour
{
    [SerializeField] private GameObject reSpawnn;
    [SerializeField] private OpenCanvas canvass;
   
  
    public void AddReword()
    {
        canvass.isOpen = false;
        reSpawnn.GetComponent<GameController>().RestartFromCheckpoint();
      //  reSpawn.RestartFromCheckpoint();
    }

    public void ShowAd()
    {
        YandexGame.RewVideoShow(0);
        reSpawnn.GetComponent<GameController>().canvas.SetActive(false);
      //  GameController.Instance.canvas.SetActive(false);
       
    }
}
