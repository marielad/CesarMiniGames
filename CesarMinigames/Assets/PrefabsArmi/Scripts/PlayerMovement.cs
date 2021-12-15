using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class PlayerMovement : MonoBehaviour
{
    public float jumpForce;
    private new Rigidbody2D rigidbody;
    public bool isGrounded = true;
    private Vector3 jumpDirection;
    public bool jumping;
    public float timeJumping;
    public float timeJumpingLimit;
  
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        jumpDirection = new Vector3(1, 1, 0);
        jumping = false;
        timeJumping = 0f;
        timeJumpingLimit = 0.7f;
    }

    // Update is called once per frame
    void Update()
    {
        
        if (jumping)
        {
            timeJumping += Time.deltaTime;
            Jump();
           
        }
        if (timeJumping >= timeJumpingLimit)
        {
            jumping = false;
            timeJumping = 0f;
        }

    }
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Suelo"))
        {
                isGrounded = true;
            
        }
    }
    public void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Suelo"))
        {
            isGrounded = false;

        }
    }

    public void Jump() 
    {
            
            Debug.Log("Jumping....");
            rigidbody.AddForce(Vector3.up * jumpForce);
            rigidbody.AddForce(Vector3.right * jumpForce/3);
            //isGrounded = false;

    }
    public void CheckJumpInput(InputAction.CallbackContext context)
    {
        if (context.performed && isGrounded)
        {
            jumping = true;
            
        }
        else if (context.canceled)
        {
            jumping = false;
            timeJumping = 0f;
        }
    }
   


}
