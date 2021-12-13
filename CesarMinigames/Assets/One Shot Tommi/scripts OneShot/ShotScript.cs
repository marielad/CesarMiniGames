using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotScript : MonoBehaviour
{
    public GameObject ballLeft;
    public GameObject ballRight;
    public GameObject ballIn;

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
        }
        if (collision.gameObject.CompareTag("BallMissRight"))
        {
            ballRight.SetActive(true);
            Debug.Log("missed right");
        }
        if (collision.gameObject.CompareTag("BallGoIn"))
        {
            ballIn.SetActive(true);
            Debug.Log("made shot");
        }
    }
}

