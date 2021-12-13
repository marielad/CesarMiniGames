using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class MetaManager : MonoBehaviour
{
    public bool metaAlcanzada;

    private void Awake()
    {
        metaAlcanzada = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Jugador")
        {
            metaAlcanzada = true;
        }
    }

    void FinalizarRonda()
    {
        if (metaAlcanzada == true)
        {
            StartCoroutine(GameController.instance.MiniGameSuceeded());
        }
    }
}
