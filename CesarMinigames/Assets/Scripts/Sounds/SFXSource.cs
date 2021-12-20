using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXSource : MonoBehaviour
{
    public static SFXSource instance;
    public AudioClip winAudio;
    public AudioClip failAudio;
    private AudioSource audioSource;
    
    void Awake()
    {
        if (SFXSource.instance == null)
        {
            SFXSource.instance = this;
            audioSource = gameObject.GetComponent<AudioSource>();
        }
        else
        {
            Destroy(this.gameObject);
        }

    }

    public void PlaySFXClip(AudioClip clip)
    {
        if(clip != null)
        {
            audioSource.PlayOneShot(clip);
        }
    }

    public void PlayWinAudio()
    {
        PlaySFXClip(winAudio);
    }

    public void PlayFailAudio()
    {
        PlaySFXClip(failAudio);
    }
}
