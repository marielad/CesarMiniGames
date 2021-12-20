using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MilkSource : MonoBehaviour
{

    public AudioSource milkOnSource;
    public AudioSource sobrecalentamientoSource;



    public void MilkOnSound()
    {
        milkOnSource.Play();
        milkOnSource.volume *= 5f;
    }

    public void MilkOnSoundStop()
    {
        milkOnSource.Stop();
    }

    public void SobrecalentamientoSound()
    {
        sobrecalentamientoSource.Play();
    }
}
