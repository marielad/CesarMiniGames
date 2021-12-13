using UnityEngine;
using System.Collections;
using UnityEngine.InputSystem;


[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour
{

    public Vector3 jump;
    public float jumpForce = 2.0f;

    public bool isGrounded;
    public Rigidbody rb;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        jump = new Vector3(0.0f, 2.0f, 0.0f);
    }

    void OnCollisionStay()
    {
        isGrounded = true;
    }

    void Update()
    {
       /* if (Input.GetKeyDown("Jump"))
        {
            Debug.Log("El personaje debería saltar");
            rb.AddForce(jump * jumpForce, ForceMode.Impulse);
            isGrounded = false;
        }*/
    }

    public void PlayerJump(InputAction.CallbackContext callback)
    {
            Debug.Log("·asd");
            rb.AddForce(jump * jumpForce, ForceMode.Impulse);
            isGrounded = false;
    }
}