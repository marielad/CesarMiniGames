using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GimnasioSFX : MonoBehaviour
{
    public static GimnasioSFX instance;

    public AudioSource sfx;
    public AudioClip espacioSound;

    private void Awake()
    {
        if(GimnasioSFX.instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this);
        }
    }

    public void GimnasioToque()
    {
        sfx.PlayOneShot(espacioSound);
    }



}
