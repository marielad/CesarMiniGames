using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInteractions : MonoBehaviour
{
    Rigidbody rb;
    public GameObject player;
    public GameObject comba;

    public bool gameEnd;
    public float timer;

    public Vector3 jump;
    public float jumpForce = 2.0f;
    public bool isGrounded;

    public int cantidadVidas;
    public TextMeshProUGUI vidas;

    public float fallMultiplier = 2.5f;

    public GameObject jumpeffect;

    public void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    public void Start()
    {
        jump = new Vector3(0.0f, 2.0f, 0.0f);
        vidas.text = cantidadVidas.ToString();
        gameEnd = false;
    }

    public void FixedUpdate()
    {
        isGrounded = false;
    }

    public void Jump(InputAction.CallbackContext callback)
    {

        if ((callback.performed) && GameController.instance.isPlaying && isGrounded)
        {
            rb.AddForce(jump * jumpForce, ForceMode.Impulse);
      
            isGrounded = false;

            FindObjectOfType<AudioManager>().Play("Salto");

            Instantiate(jumpeffect, rb.transform.position, rb.transform.rotation);
        } 
    }

    public void Update()
    {

        if (rb.velocity.y < 0)
        {
            rb.velocity += Vector3.up * Physics.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
        }

        if (gameEnd == false)
        {
            timer = timer - Time.deltaTime;

            if (timer <= 0)
            {
                gameEnd = true;
            }
        }

        if (gameEnd == true)
        {
            StartCoroutine(GameController.instance.MiniGameSuceeded());
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Comba"))
        {
            cantidadVidas -= 1;
            vidas.text = cantidadVidas.ToString();
            FindObjectOfType<AudioManager>().Play("ChoqueComba");
        }

        if (cantidadVidas <= 0)
        {
            Destroy(comba);
            StartCoroutine(GameController.instance.FailMiniGame());
        }
    }

    public void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }
}
