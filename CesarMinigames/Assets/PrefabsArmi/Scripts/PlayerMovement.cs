using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class PlayerMovement : MonoBehaviour
{
    public float jumpForce;
    private new Rigidbody2D rigidbody;
    private bool isGrounded = true;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        /*if (Input.GetButtonDown("Jump"))
        {
            
        }*/
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Suelo"))
        {
            isGrounded = true;
        }
    }
    public void Jump(InputAction.CallbackContext context) 
    {
        if (isGrounded == true)
        {
            rigidbody.AddForce(Vector3.up * jumpForce);
            isGrounded = false;
        }
    }
   


}
