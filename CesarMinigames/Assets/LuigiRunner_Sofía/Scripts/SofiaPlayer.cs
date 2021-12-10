using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class SofiaPlayer : MonoBehaviour
{
    public Rigidbody2D rb2D;
    public float jump = 5.0f;

    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
    }

    /*void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            rb2D.AddForce(new Vector2(0, jump), ForceMode2D.Impulse);
        }
    }*/

    /*public void PressedButton(InputAction.CallbackContext callback)
    {
        if (callback.performed)
        {
            rb2D.AddForce(Vector3.up * jump, ForceMode2D.Impulse);
        }
    }*/

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Obstaculo"))
        {
            Debug.Log("Choqué con un obstáculo");
        }
    }
}
