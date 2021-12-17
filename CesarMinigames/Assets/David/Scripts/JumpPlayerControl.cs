using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class JumpPlayerControl : MonoBehaviour
{
    Rigidbody2D rb;
    float jumpforce = 2f;
    float delay;

    public Sprite spriteReposo;
    public Sprite spriteSalto;
    public SpriteRenderer spriteRenderer;
    public ParticleSystem tierra;

    AudioSource sonidos;
    public AudioClip salto, choque, caida;

    // Start is called before the first frame update
    void Start()
    {
        sonidos = GetComponent<AudioSource>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        delay += Time.deltaTime;
    }

    public void Jump(InputAction.CallbackContext callback)
    {
        Vector2 jump = new Vector2(0.0f, jumpforce);
        if ((callback.performed && callback.duration != 0.0f) && GameController.instance.isPlaying)
        {
            sonidos.PlayOneShot(salto);
            if (delay >= 0.2)
            {
                rb.AddForce(jump * jumpforce, ForceMode2D.Impulse);
                delay = 0f;
                StartCoroutine("CambiarASalto");
            }
         }
    }

    IEnumerator CambiarASalto()
    {
        spriteRenderer.sprite = spriteSalto;
        yield return new WaitForSeconds(0.2f);
        spriteRenderer.sprite = spriteReposo;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Suelo"))
        {
            sonidos.PlayOneShot(caida);
            tierra.Play();
        }
        if (collision.gameObject.CompareTag("Obstaculo"))
        {
            sonidos.PlayOneShot(choque);
        }
    }
}
