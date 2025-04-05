using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundOffOnGame : MonoBehaviour
{
    //[SerializeField] private AudioSource musicjump;
    [SerializeField] private AudioSource musicfon;
    private static int value = 1;

    public void Filter()
    {
        if (value % 2 != 0)
        {
            SounOff();
        }
        else
        {
            SounOn();
        }
    }
    public void SounOff()
    {
        value++;
        //musicjump.Stop();
        musicfon.Stop();

    }

    public void SounOn()
    {
        value--;
        //musicjump.Play();
        musicfon.Play();
    }
}
