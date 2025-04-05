using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class lang : MonoBehaviour
{
    [SerializeField] private Text playText;
    
    private int value = 2;

    private void Start()
    {
        LanguageData.languageNumber = value;
    }


    public void Skip()
        {

          value++;
        if (value%2!=0)
        {
            SkipLanguageEN();
        }
        else
        {
            SkipLanguageRu();
        }
      
    }
    public void SkipLanguageEN()
    {
        playText.text = "Play";
        
    }
    public void SkipLanguageRu()
    {
        playText.text = "Играть";
        
    }

}
