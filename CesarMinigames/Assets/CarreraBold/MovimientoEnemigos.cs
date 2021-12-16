using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class MovimientoEnemigos : MonoBehaviour
{

    Rigidbody rg;
    public float temporizador = 1f;
    private float timer;
    public bool correr;
    public float speed;
    public float empuje;
    public static MovimientoEnemigos intance;
    void Awake()
    {
        rg = GetComponent<Rigidbody>();
        intance = this;
    }

    public void Start()
    {
        timer = temporizador;
        correr = true;
    }
    public void Update()
    {
        if (correr == true && GameController.instance.isPlaying)
        {
            timer = timer - Time.deltaTime;

            if (timer <= 0)
            {
                
                transform.position = transform.position + new Vector3(empuje * speed * Time.deltaTime, 0, 0);
                rg.gameObject.transform.Rotate(0, 180, 0);
                //transform.position = transform.position.x * speed * Time.deltaTime;
                timer = temporizador;
            }
            else
            {
                rg.gameObject.transform.Rotate(0, 0, 0);


            }
        }
            
        
    }
    /*public void PressedButton(InputAction.CallbackContext callback)
    {
        if (callback.performed)
        {
            
            rg.gameObject.transform.Rotate(0, 180, 0);

        }
    }*/

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name.Equals("FinishLine"))
        {
            correr = false;

            StartCoroutine(GameController.instance.FailMiniGame());
            

        }
    }
}
