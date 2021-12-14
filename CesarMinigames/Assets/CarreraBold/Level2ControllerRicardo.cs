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
            //rg.transform.rotation(180f, 0f, 0f);
            rg.AddForce(Vector3.right * jumpForce, ForceMode.Impulse);
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
