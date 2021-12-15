using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerInteractions : MonoBehaviour
{
    public GameController general;

    public GameObject player;

    public Vector3 height; 

    public float jumpForce = 2f;

    public int cantidadVidas;

    public TextMeshProUGUI vidas;

    public void Start()
    {
        vidas.text = cantidadVidas.ToString();

        height = new Vector3(0.0f, jumpForce, 0.0f);
    }

    public void Jump()
    {   
      
    }

    public void Update()
    {
        if (cantidadVidas <= 0)
        {
            StartCoroutine(general.FailMiniGame());
        }
    }

    public void OnCollisionEnter(Collision collision)
    {
        if(gameObject.CompareTag("Comba"))
        {
            cantidadVidas -= 1;
            vidas.text = cantidadVidas.ToString();
        }
    }
}
