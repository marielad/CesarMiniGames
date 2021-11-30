using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class Level2Controller : MonoBehaviour
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
            rg.AddForce(Vector3.up * 5f, ForceMode.Impulse);

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
