using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nubes : MonoBehaviour
{
    public Vector2 posicionInicial;
    public Vector2 posicionFinal;
    float velocidad = 3f;
    void Start()
    {
        posicionInicial = transform.position;
        posicionFinal = new Vector2(-transform.position.x, transform.position.y);
    }

    // Update is called once per frame
    void Update()
    {
        MoverNube();
        if (transform.position.x == posicionFinal.x)
        {
            posicionFinal = new Vector2(-transform.position.x, transform.position.y);
        }
    }

    void MoverNube()
    {
        transform.position = Vector2.MoveTowards(transform.position, posicionFinal, velocidad * Time.deltaTime);
    }
}
