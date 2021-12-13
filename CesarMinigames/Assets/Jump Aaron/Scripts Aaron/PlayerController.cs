using UnityEngine;
using System.Collections;
using UnityEngine.InputSystem;


//[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour
{

    public Vector2 jump;
    public float jumpForce = 2.0f;

    public bool isGrounded;
    public Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        jump = new Vector2(0.0f, 2.0f);
        isGrounded = true;
    }

    void Update()
    {

    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Suelo"))
        {
            isGrounded = true;
        }
    }

    public void PlayerJump()//(InputAction.CallbackContext callback)
    {
        if(isGrounded)
        {
            Debug.Log("Salto");
            rb.AddForce(Vector2.up * jumpForce);
            isGrounded = false;
        }

    }
}