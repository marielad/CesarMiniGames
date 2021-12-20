using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManagerAgoney : MonoBehaviour
{
    [SerializeField] private AudioClip[] audios; 

    private AudioSource audioControl;

    private void Awake()
    {
        audioControl = GetComponent<AudioSource>();
    }

    public void SeleccionAudio (int indice, float volumen)
    {
        audioControl.PlayOneShot(audios[indice], volumen);
    }
}
