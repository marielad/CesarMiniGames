using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class GameManagerAgoney : MonoBehaviour
{

    public Sprite globoContento;
    public Sprite globoTriste;
    public Sprite infladorArriba;
    public Sprite infladorAbajo;
    public GameObject inflador_object;
    public GameObject globo_object;
    private Image globo;
    private Image inflador;

    //public Transform a;
    void Start()
    {
        globo = globo_object.GetComponent<Image>();
        inflador = inflador_object.GetComponent<Image>();

    }
    public void PressedButton(InputAction.CallbackContext callback)
    {
        if ((callback.performed && callback.duration != 0.0f) && GameController.instance.isPlaying)
        {
            StartCoroutine("CambiarInflador");
        }
    }
    IEnumerator CambiarInflador()
    {
        inflador.sprite = infladorAbajo;
        yield return new WaitForSeconds(0.2f);
        inflador.sprite = infladorArriba;
    }
}
