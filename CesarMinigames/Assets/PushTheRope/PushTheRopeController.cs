using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PushTheRopeController : MonoBehaviour
{

    public GameObject player;
    public GameObject enemy;
    public HingeJoint2D playerRope;
    public float enemyCadence = 1.0f;
    public float enemyForce = 1.0f;
    public float playerForce = 1.0f;
    private float timerEnemy = 0.0f;

    private void Awake()
    {
        GameController.onTimesUp += FinishGame;

    }

    void FinishGame()
    {
        if (enemy != null && enemy.GetComponent<Rigidbody2D>() != null)
        {
            enemy.GetComponent<Rigidbody2D>().AddForce(Vector2.right * enemyForce * 4, ForceMode2D.Impulse);
        }
        if (gameObject != null && gameObject.GetComponent<BoxCollider2D>() != null)
        {
            gameObject.GetComponent<BoxCollider2D>().enabled = false;

        }
        GameController.onTimesUp -= FinishGame;

    }
    // Update is called once per frame
    void Update()
    {
        if (GameController.instance.isPlaying)
        {
            timerEnemy += Time.deltaTime;
            if (timerEnemy >= enemyCadence)
            {
                timerEnemy = 0.0f;
                enemy.GetComponent<Rigidbody2D>().AddForce(Vector2.right * enemyForce, ForceMode2D.Impulse);
                player.GetComponent<Rigidbody2D>().AddForce(Vector2.right * enemyForce, ForceMode2D.Impulse);
            }

        }
    }

    public void PressedButton(InputAction.CallbackContext callback)
    {
        if (GameController.instance.isPlaying)
        {
            enemy.GetComponent<Rigidbody2D>().AddForce(Vector2.left * playerForce, ForceMode2D.Impulse);
            player.GetComponent<Rigidbody2D>().AddForce(Vector2.left * playerForce, ForceMode2D.Impulse);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (GameController.instance.isPlaying == true)
        {
            if (collision.gameObject.name.Equals("Enemy"))
            {
                playerRope.connectedBody = null;
                playerRope.gameObject.SetActive(false);
                StartCoroutine(GameController.instance.MiniGameSuceeded());
            }
            else if (collision.gameObject.name.Equals("Player"))
            {
                enemy.GetComponent<HingeJoint2D>().connectedBody = null;
                StartCoroutine(GameController.instance.FailMiniGame());
            }
        }      
    }
}
