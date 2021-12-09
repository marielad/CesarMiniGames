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

    public Slider barra;

    private void Awake()
    {
        currentBarraCantidad = 0f;
        barra.value = currentBarraCantidad;
        barra.maxValue = maxBarraCapacidad;
    }

    // Update is called once per frame
    void Update()
    {
        if (currentBarraCantidad >= maxBarraCapacidad)
        {
            StartCoroutine(GameController.instance.MiniGameSuceeded());
        }
        
    }

    public void PressedButton(InputAction.CallbackContext callback)
    {
        if (callback.performed)
        {
            currentBarraCantidad = currentBarraCantidad + espacioCantidad;
            barra.value = currentBarraCantidad;
        }
    }
}
