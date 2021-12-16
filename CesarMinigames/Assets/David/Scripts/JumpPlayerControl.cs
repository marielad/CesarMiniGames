using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpPlayerControl : MonoBehaviour
{
    Rigidbody2D rb;
    float jumpforce = 2f;
    float delay;

    public Sprite spriteReposo;
    public Sprite spriteSalto;
    public SpriteRenderer spriteRenderer;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        delay += Time.deltaTime;
    }

    public void Jump()
    {
        Vector2 jump = new Vector2(0.0f, jumpforce);
        if (delay >= 0.25)
        {
            rb.AddForce(jump * jumpforce, ForceMode2D.Impulse);
            delay = 0f;
            StartCoroutine("CambiarASalto");
        }
    }

    IEnumerator CambiarASalto()
    {
        spriteRenderer.sprite = spriteSalto;
        yield return new WaitForSeconds(0.2f);
        spriteRenderer.sprite = spriteReposo;
    }
}
