using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class Level2ControllerRicardo : MonoBehaviour
{

    Rigidbody rg;
    public float jumpForce = 5f;
    public static Level2ControllerRicardo intance;
    public bool paro;
    public AudioSource victoria;
    

    void Awake()
    {
        rg = GetComponent<Rigidbody>();
        intance = this;
        
       
    }
    public void Start()
    {
        paro = true;
    }


    public void PressedButton(InputAction.CallbackContext callback)
    {
        if (paro == true)
        {
            if (callback.performed && GameController.instance.isPlaying)
            {

                rg.AddForce(Vector3.right * jumpForce, ForceMode.Impulse);
                rg.gameObject.transform.Rotate(0, 180, 0);

            }
        }
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name.Equals("FinishLine"))
        {
            StartCoroutine(GameController.instance.MiniGameSuceeded());

            MovimientoEnemigos.intance.correr = false;
            victoria.Play();

            

        }
    }
}
