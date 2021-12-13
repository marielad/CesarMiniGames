using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class SofiaPlayer : MonoBehaviour
{

    public Rigidbody2D rb2D;

    public float jump = 5.0f;

    public int vidas = 3;

    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
    }

    public void PressedButton(InputAction.CallbackContext callback)
    {
        if (callback.performed)
        {
            rb2D.AddForce(Vector3.up * jump, ForceMode2D.Impulse);
        }
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Obstaculo"))
        {
            Debug.Log("Choqué con un obstáculo");
            vidas -= 1;
            //Pos Inicial del personaje y del escenario 
            GameOver();
        }

        if(collision.gameObject.CompareTag("Moneda"))
        {
            Debug.Log("Gané");
        }
    }

    public void GameOver()
    {
        if (vidas == 0)
        {
            Debug.Log("Morí :'c");
            //GameOver
        }
    }
}
