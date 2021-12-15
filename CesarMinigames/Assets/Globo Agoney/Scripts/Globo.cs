using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Globo : MonoBehaviour
{

    public Sprite globoContento;
    public Sprite globoTriste;
    public GameObject globo;
    private Image globoso;

    public Transform a;
    void Start()
    {
        globoso = globo.GetComponent<Image>();
    }
    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
         
        }


    }
}
