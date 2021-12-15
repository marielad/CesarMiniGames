using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class MiniGameController : MonoBehaviour
{
    public float espacioCantidad;
    public float currentBarraCantidad;
    public float maxBarraCapacidad;

    public Sprite mus1;
    public Sprite mus2;
    public Sprite mus3;
    public Sprite presion;
    public Sprite nopres;

    public Slider barra;

    public GameObject personaje;
    private Image person;
    public GameObject boton;
    private Image bot;

    public float tempo1 = 0.5f;
    public float tempo2 = 0.5f;

    public bool sec1 = false;
    public bool sec2 = false;

    private Animator pesas;

    private void Awake()
    {
        currentBarraCantidad = 0f;
        barra.value = currentBarraCantidad;
        barra.maxValue = maxBarraCapacidad;

        person = personaje.GetComponent<Image>();
        bot = boton.GetComponent<Image>();
        pesas = personaje.GetComponent<Animator>();
        sec1 = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (currentBarraCantidad >= maxBarraCapacidad)
        {
            
            StartCoroutine(GameController.instance.MiniGameSuceeded());
        }

        if(currentBarraCantidad < (maxBarraCapacidad * 0.5f))
        {
            person.sprite = mus1;
        }

        if (currentBarraCantidad > (maxBarraCapacidad * 0.5f))
        {
            person.sprite = mus2;
        }

        if(currentBarraCantidad > (maxBarraCapacidad * 0.99f))
        {
            person.sprite = mus3;
        }

        if(sec1 == true)
        {
            tempo1 = tempo1 - Time.deltaTime;
        }

        if(tempo1 <= 0f)
        {
            sec1 = false;
            tempo1 = 0.5f;
            bot.sprite = presion;
            sec2 = true;
        }

        if (sec2 == true)
        {
            tempo2 = tempo2 - Time.deltaTime;
        }

        if (tempo2 <= 0f)
        {
            sec2 = false;
            tempo2 = 0.5f;
            bot.sprite = nopres;
            sec1 = true;
        }
    }

    public void PressedButton(InputAction.CallbackContext callback)
    {
        if (callback.performed && GameController.instance.isPlaying)
        {
            currentBarraCantidad = currentBarraCantidad + espacioCantidad;
            barra.value = currentBarraCantidad;
            GimnasioSFX.instance.GimnasioToque();
            pesas.Play("Levantamiento");
        }
    }
}
