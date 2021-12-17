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

    public ShotScript shootingscript;

    public AudioSource whistleSound;
    public AudioSource music;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        StartCoroutine("StartGame");
        //music.Play();
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

    public void StopPlayerBar()
    {
        missLeftBar.SetActive(true);
        missRightBar.SetActive(true);
        makeBar.SetActive(true);
        speed = 0;
        StartCoroutine("CheckSecondChance");
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
        whistleSound.Play();
    }

    public IEnumerator CheckSecondChance()
    {
        yield return new WaitForSeconds(2);

        missLeftBar.SetActive(false);
        missRightBar.SetActive(false);
        makeBar.SetActive(false);

        yield return new WaitForSeconds(2);

        if (shootingscript.secondchance == true)
        {
            speed = 800;
            whistleSound.Play();
        }
    }
}
