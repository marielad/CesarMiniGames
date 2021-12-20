using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;


public class PlayerMovement : MonoBehaviour
{
    public float jumpForce;
    private new Rigidbody2D rigidbody;
    public bool isGrounded = true;
    private Vector3 jumpDirection;
    public bool jumping;
    public float timeJumping;
    public float timeJumpingLimit;
    public AudioClip jumpSound, loseSound, winSound;
    public AudioSource audioSource;
    public ParticleSystem confettiParticle;

    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        jumpDirection = new Vector3(1, 1, 0);
        jumping = false;
        timeJumping = 0f;
        timeJumpingLimit = 0.7f;
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void FixedUpdate()
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
            audioSource.PlayOneShot(jumpSound, 1f);
            
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Fuego"))
        {
            audioSource.PlayOneShot(loseSound, 1f);
            StartCoroutine(GameController.instance.FailMiniGame());
            
        }
        if (collision.gameObject.CompareTag("Meta"))
        {
            audioSource.PlayOneShot(winSound, 1f);
            confettiParticle.Play();
            StartCoroutine(GameController.instance.MiniGameSuceeded());
           
        }
        
    }

    public void Jump() 
    {
        
        Debug.Log("Jumping....");
            rigidbody.AddForce(Vector3.up * jumpForce, ForceMode2D.Impulse);
            rigidbody.AddForce(Vector3.right * jumpForce/3, ForceMode2D.Impulse);
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
