using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class Level2ControllerRicardo : MonoBehaviour
{

    Rigidbody rg;
    public float jumpForce = 5f;
    void Awake()
    {
        rg = GetComponent<Rigidbody>();
    }


    public void PressedButton(InputAction.CallbackContext callback)
    {
        if (callback.performed)
        {
            rg.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);

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
