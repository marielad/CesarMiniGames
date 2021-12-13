using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    public AudioSource source;
    public AudioClip bgMusic;
    public AudioClip win;
    public AudioClip swoosh;
    public AudioClip lost;
    public AudioClip whistle;
    public float volume = 0.7f;
    public float volumeForBg = 0.2f;
    public static AudioController instance;

    private void Start()
    {
        instance = this;
        
    }

    public void SwooshSound()
    {
        source.PlayOneShot(swoosh, volume);
    }

    public void WinSound()
    {
        source.PlayOneShot(win, volume);
    }

    public void LostSound()
    {
        source.PlayOneShot(lost, volume);
    }

    public void PlayBackgroundMusic()
    {
        source.PlayOneShot(bgMusic, volumeForBg);
    }

    public void PlayWhistle()
    {
        source.PlayOneShot(whistle, volumeForBg);
    }
}
