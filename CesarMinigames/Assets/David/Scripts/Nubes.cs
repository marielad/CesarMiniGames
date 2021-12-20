using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nubes : MonoBehaviour
{
    public Vector2 posicionInicial;
    public Vector2 posicionFinal;
    float velocidad = 3f;
    public GameObject player;
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
        Transformar();
    }

    void MoverNube()
    {
        transform.position = Vector2.MoveTowards(transform.position, posicionFinal, velocidad * Time.deltaTime);
    }

    void Transformar()
    {
        Collider2D col;
        col = GetComponent<Collider2D>();
        if (player.transform.position.y > transform.position.y)
        {
            col.isTrigger = true;
        }
        else
        {
            col.isTrigger = false;
        }
    }
}
