using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class MovimientoEnemigos : MonoBehaviour
{

    Rigidbody rg;
    
    void Awake()
    {
        rg = GetComponent<Rigidbody>();
    }


    public void PressedButton(InputAction.CallbackContext callback)
    {
        if (callback.performed)
        {
            
            rg.gameObject.transform.Rotate(0, 180, 0);

        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name.Equals("FinishLine"))
        {

            StartCoroutine(GameController.instance.MiniGameSuceeded());


        }
    }
}
