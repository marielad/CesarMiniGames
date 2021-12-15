using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicMixer : MonoBehaviour
{
    public static MusicMixer instance;
    public AudioSource musicSource;
    public AudioClip newSong;
    public bool changingSong = false;
    public float speedVolume = 0.02f;
    // Start is called before the first frame update
    void Awake()
    {
        if (MusicMixer.instance == null)
        {
            MusicMixer.instance = this;
            musicSource = GetComponent<AudioSource>();
        }
        else
        {
            Destroy(this);
        }
    }

    private void Update()
    {
        if (changingSong)
        {
            musicSource.volume -= speedVolume * Time.deltaTime;
            if (musicSource.volume <= 0.3f)
            {
                musicSource.clip = newSong;
                musicSource.Play();
                changingSong = false;
            }
        }
        else
        {
            musicSource.volume += speedVolume * Time.deltaTime;
        }
    }
    // Update is called once per frame
    public void ChangeSong(AudioClip newSong)
    {
        if (this.newSong != newSong)
        {
            this.newSong = newSong;
            changingSong = true;
        }
    }
}
