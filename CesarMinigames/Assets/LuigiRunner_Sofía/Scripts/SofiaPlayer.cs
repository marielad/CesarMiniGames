using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class SofiaPlayer : MonoBehaviour
{

    public Rigidbody2D rb2D;

    public float jump = 5.0f;

    public int vidas = 3;

    public Animator animator;

    public Vector2 startPos;

    public Animator fondo;
    public Animator plataformas;
    public Animator obstaculos;
    public Animator final;
    public Animator suelo;

    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        startPos = transform.position;
    }


    public void PressedButton(InputAction.CallbackContext callback)
    {
        if (callback.performed && GameController.instance.isPlaying)
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
            Reset();
            GameOver();
        }

        if(collision.gameObject.CompareTag("Moneda"))
        {
            Debug.Log("Gané");
            StartCoroutine(GameController.instance.MiniGameSuceeded());    
        }
    }

    public void GameOver()
    {
        if (vidas == 0)
        {
            Debug.Log("Morí :'c");
            //GameOver
            StartCoroutine(GameController.instance.FailMiniGame());
        }
    }

    // Resetea pos personaje 
    public void Reset()
    {
        Debug.Log("Reseteo");
        transform.position = startPos;
        fondo.SetTrigger("Reset");
        plataformas.SetTrigger("Reset");
        obstaculos.SetTrigger("Reset");
        final.SetTrigger("Reset");
        suelo.SetTrigger("Reset");
    }
}
