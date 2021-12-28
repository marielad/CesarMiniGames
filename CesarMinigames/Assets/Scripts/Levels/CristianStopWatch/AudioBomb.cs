using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioBomb : MonoBehaviour
{
    public AudioSource bombCountClip;
    public AudioSource chispasClip;

    public void BombActiveSound()
    {
        bombCountClip.Play();
        bombCountClip.volume *= 15f;
    }

    public void ChispasSound()
    {
        chispasClip.Play();
    }
}
