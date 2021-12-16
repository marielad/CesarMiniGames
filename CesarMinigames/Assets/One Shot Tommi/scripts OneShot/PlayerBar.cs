using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerBar : MonoBehaviour
{
    public float speed = 5f;

    public bool switc = true;

    public GameObject missLeftBar;

    public GameObject missRightBar;

    public GameObject makeBar;

    private SpriteRenderer spriteRenderer;

    public bool startgame = false;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        StartCoroutine("StartGame");
    }

    // Update is called once per frame
    void Update()
    {
        if (startgame == true)
        {
            if (switc)
            {
                moveBarRight();

            }
            if (!switc)
            {
                moveBarLeft();
            }
            if (transform.position.x >= 645f)
            {
                //switc = false;
                //spriteRenderer.flipX = true;
            }
            if (transform.position.x <= 275f)
            {
                //switc = true;
                //spriteRenderer.flipX = true;
            }
            /*if (Input.GetKeyDown(KeyCode.Space))
            {
                missLeftBar.SetActive(true);
                missRightBar.SetActive(true);
                makeBar.SetActive(true);
                speed = 0;
            }*/
        }

    }

    void moveBarRight()
    {
        transform.Translate(speed * Time.deltaTime, 0, 0);
    }

    void moveBarLeft()
    {
        transform.Translate(-speed * Time.deltaTime, 0, 0);
    }
        
       /* public void PressedButton(InputAction.CallbackContext callback)
        {
            if (callback.performed)
            {
                missLeftBar.SetActive(true);
                missRightBar.SetActive(true);
                makeBar.SetActive(true);
                speed = 0;
            }
        }*/

    public void StopPlayerBar()
    {
        missLeftBar.SetActive(true);
        missRightBar.SetActive(true);
        makeBar.SetActive(true);
        speed = 0;
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("BorderLeft"))
        {
            switc = true;
            spriteRenderer.flipX = true;
        }
        if (collision.gameObject.CompareTag("BorderRight"))
        {
            switc = false;
            spriteRenderer.flipX = true;
            Debug.Log("rightborder");
        }
    }

    public IEnumerator StartGame()
    {

        yield return new WaitForSeconds(2);

        startgame = true;
    }
}
