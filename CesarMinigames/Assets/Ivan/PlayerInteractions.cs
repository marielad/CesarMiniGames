using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerInteractions : MonoBehaviour
{

    public int cantidadVidas;

    public TextMeshProUGUI vidas;

    public void Start()
    {
        vidas.text = cantidadVidas.ToString();
    }

    public void Update()
    {
        if (cantidadVidas <= 0)
        {
            CodigoDePerder();
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
