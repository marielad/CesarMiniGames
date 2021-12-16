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

            StartCoroutine("ActivateParticlesLeft");
            StartCoroutine("Lose");

        }
        if (collision.gameObject.CompareTag("BallMissRight"))
        {
            ballRight.SetActive(true);
            Debug.Log("missed right");
            stopClock = true;

            StartCoroutine("ActivateParticlesRight");
            StartCoroutine("Lose");
        }
        if (collision.gameObject.CompareTag("BallGoIn"))
        {
            ballIn.SetActive(true);
            Debug.Log("made shot");
            stopClock = true;

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
    }

    public IEnumerator ActivateParticlesRight()
    {
        yield return new WaitForSeconds(.9f);

        particlesRight.SetActive(true);
    }

    public IEnumerator ActivateParticlesIn()
    {
        yield return new WaitForSeconds(1.05f);

        particlesIn.SetActive(true);

        startAnimation = true;
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

