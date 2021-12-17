using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotScript : MonoBehaviour
{
    public GameObject ballLeft;
    public GameObject ballRight;
    public GameObject ballIn;

    public GameObject particlesLeft;
    public GameObject particlesRight;
    public GameObject particlesIn;

    public bool startAnimation = false;
    public bool stopClock = false;

    public GameObject rim;
    public GameObject rimAnim;

    public int lives = 2;
    public bool secondchance;

    public AudioSource rimSound;
    public AudioSource netSound;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("BallMissLeft"))
        {
            ballLeft.SetActive(true);
            Debug.Log("missed left");
            stopClock = true;
            lives -= 1;
            StartCoroutine("ActivateParticlesLeft");
            if (lives > 0)
            {
                secondchance = true;
            }

            if (lives == 0)
            {
                StartCoroutine("Lose");
                secondchance = false;
            }
            

        }
        if (collision.gameObject.CompareTag("BallMissRight"))
        {
            ballRight.SetActive(true);
            Debug.Log("missed right");
            stopClock = true;
            lives -= 1;
            StartCoroutine("ActivateParticlesRight");
            if (lives > 0)
            {
                secondchance = true;
            }
            if (lives == 0)
            {
                StartCoroutine("Lose");
                secondchance = false;
            }
        }
        if (collision.gameObject.CompareTag("BallGoIn"))
        {
            ballIn.SetActive(true);
            Debug.Log("made shot");
            stopClock = true;
            secondchance = false;
            rim.SetActive(false);
            rimAnim.SetActive(true);

            StartCoroutine("ActivateParticlesIn");
            StartCoroutine("Win");
        }
    }

    public IEnumerator ActivateParticlesLeft()
    {
        yield return new WaitForSeconds(.9f);

        particlesLeft.SetActive(true);
        rimSound.Play();

        yield return new WaitForSeconds(4);

        particlesLeft.SetActive(false);

        ballLeft.SetActive(false);
    }

    public IEnumerator ActivateParticlesRight()
    {
        yield return new WaitForSeconds(.9f);
        rimSound.Play();

        particlesRight.SetActive(true);

        yield return new WaitForSeconds(3);

        particlesRight.SetActive(false);

        ballRight.SetActive(false);
    }

    public IEnumerator ActivateParticlesIn()
    {
        yield return new WaitForSeconds(1.05f);

        particlesIn.SetActive(true);

        netSound.Play();

        startAnimation = true;

        yield return new WaitForSeconds(3);

        particlesIn.SetActive(false);
    }

    public IEnumerator Win()
    {
        yield return new WaitForSeconds(3.5f);

        StartCoroutine(GameController.instance.MiniGameSuceeded());
    }

    public IEnumerator Lose()
    {
        yield return new WaitForSeconds(2.5f);

        StartCoroutine(GameController.instance.FailMiniGame());
    }
}

