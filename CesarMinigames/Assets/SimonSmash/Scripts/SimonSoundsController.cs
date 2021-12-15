using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimonSoundsController : MonoBehaviour
{
    public AudioSource m_Explosion1;
    public AudioSource m_Explosion2;
    public AudioSource m_Explosion3;
    public AudioSource m_Explosion4;

    public AudioSource m_ChangeBulb;

    public AudioSource m_GameOver;

    public AudioSource m_Background;

    public float m_StereoPan;

    public void PlayBackground()
    {
        m_Background.Play();
    }

    public void PlayRandomExplosion(int BulbPosition)
    {

        if(BulbPosition == -3)
        {
            m_StereoPan = -1f;
        }
        else if(BulbPosition == -2)
        {
            m_StereoPan = -0.66f;
        }
        else if (BulbPosition == -1)
        {
            m_StereoPan = -0.33f;
        }
        else if (BulbPosition == 0)
        {
            m_StereoPan = 0f;
        }
        else if (BulbPosition == 1)
        {
            m_StereoPan = 0.33f;
        }
        else if (BulbPosition == 2)
        {
            m_StereoPan = 0.66f;
        }
        else if (BulbPosition == 3)
        {
            m_StereoPan = 1f;
        }


        int random = Random.Range(0, 4);

        if (random == 0)
        {
            m_Explosion1.panStereo = m_StereoPan;
            m_Explosion1.Play();
        }
        else if (random == 1)
        {
            m_Explosion2.panStereo = m_StereoPan;
            m_Explosion2.Play();
        }
        else if (random == 2)
        {
            m_Explosion3.panStereo = m_StereoPan;
            m_Explosion3.Play();
        }
        else if (random == 3)
        {
            m_Explosion4.panStereo = m_StereoPan;
            m_Explosion4.Play();
        }
    }

    public void PlayChangeBulb()
    {
        m_ChangeBulb.Play();
    }

    public void PlayGameOver()
    {
        m_GameOver.Play();
    }
}
