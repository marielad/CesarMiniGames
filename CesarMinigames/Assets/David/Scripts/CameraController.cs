using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject player;
    Vector3 posicion;
    float offsety = 3.6f;
    void Start()
    {
        posicion = new Vector3(player.transform.position.x, player.transform.position.y + offsety, -10);
    }

    void Update()
    {
        if(player.transform.position.y >= 0)
        {
            posicion = new Vector3(player.transform.position.x, player.transform.position.y, -10);
            transform.position = posicion;
        }
    }
}
