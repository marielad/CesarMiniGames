using UnityEngine;
using System.Collections;
using UnityEngine.InputSystem;
using TMPro;

//[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour
{
    public GameController gameController;

    public Vector2 jump;
    public float jumpForce = 2.0f;

    public bool isGrounded;
    public Rigidbody2D rb;

    public TextMeshProUGUI timer;
    public float timeValue = 0f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        jump = new Vector2(0.0f, 2.0f);
        isGrounded = true;

        timeValue = 15f; //Hacer un isPlaying para que el Update se haga una sola vez
    }

    void Update()
    {
        
        timeValue -= Time.deltaTime;
        timer.text = "" + timeValue.ToString("F0");


        if (timeValue <= 0f)
        {
            timeValue = 0;
        }
        
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemigos"))
        {
            Debug.Log("Choque con un enemigo");
            StartCoroutine(GameController.instance.FailMiniGame()); //Función de derrota
        }
    }

    public void PlayerJump()//(InputAction.CallbackContext callback)
    {
        //if(isGrounded)
        {
            Debug.Log("Salto");
            rb.AddForce(Vector2.up * jumpForce);
            isGrounded = false;
        }

    }
}