using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundOffOn : MonoBehaviour
{
    [SerializeField] private AudioSource musicAudioSource;
    private static int value=1;

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
        musicAudioSource.Stop();

    }

    public void SounOn()
    {
        value--;
        musicAudioSource.Play();
    }
}
