using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rimCollider : MonoBehaviour
{
    public GameObject particlesLeft;
    public GameObject particlesRight;
    public GameObject particlesIn;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter (Collider other)
    {
        if (other.gameObject.CompareTag("BallMissLeft"))
        {
            particlesLeft.SetActive(true);
            Debug.Log("missed left");
        }
        if (other.gameObject.CompareTag("BallMissRight"))
        {
            particlesRight.SetActive(true);
            Debug.Log("missed right");
        }
        if (other.gameObject.CompareTag("BallGoIn"))
        {
            particlesIn.SetActive(true);
            Debug.Log("made shot");
        }
    }
}
