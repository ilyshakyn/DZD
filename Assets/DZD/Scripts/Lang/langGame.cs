using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class langGame : MonoBehaviour
{
    [SerializeField] private Text button1Text;
    [SerializeField] private Text button2Text;
    [SerializeField] private Text button3Text;

    private int value ;

    private void Start()
    {
        value = LanguageData.languageNumber;
    }


    public void Skip()
    {

        value++;
        if (value % 2 != 0)
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
        button1Text.text = "Restart level from beginning";
        button2Text.text = "Respawn at last checkpoint";
       button3Text.text = "Quit";

    }
    public void SkipLanguageRu()
    {
        button1Text.text = "Перезапустить уровень с начала";
        button2Text.text = "Возрождение к последнему чекпоинту";
       button3Text.text = "Выход";

    }
}
