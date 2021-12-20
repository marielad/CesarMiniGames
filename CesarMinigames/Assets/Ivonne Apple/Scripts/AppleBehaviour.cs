using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class AppleBehaviour : MonoBehaviour
{
    
    public GameObject openHand;
    public GameObject closedHand;
    public GameObject hands;
    
    private bool falling;
    private float appleSpeed = 8.0f;
    private bool appleReady;

    private Vector2 startPos;
    private Vector2 appleTopPos;

    private Vector2 openHandStartPos;
    private Vector2 closedHandStartPos;
    private bool handsUp;
    private bool handsDown;
    private float limitHandsUp = 1.45f;
    private float limitHandsDown = -0.33f;

    private int pointsApples;
    public int goalApples;
    public TextMeshProUGUI pointsApplesText;

    private float gameTimer = 15f; 

    

    void Start()
    {
        openHandStartPos = new Vector2(0.05f, 3.94f);
        closedHandStartPos = new Vector2(0, 3.94f);
        startPos = transform.position;
        appleTopPos = new Vector2(-0.31f, 4.7f);
        appleReady = true;
        pointsApples = 0;
        
        pointsApplesText.SetText(pointsApples + "/" + goalApples);

    }

    void Update()
    {
        gameTimer -= Time.deltaTime;
        if(handsUp == true && hands.transform.position.y < limitHandsUp)
        {
            hands.transform.Translate(Vector2.up * Time.deltaTime * 4f);
            if (hands.transform.position.y >= limitHandsUp) 
            {
                handsUp = false;
            }
        }
        if (handsDown == true && hands.transform.position.y > limitHandsDown)
        {   
            hands.transform.Translate(Vector2.down * Time.deltaTime * 2f);
            transform.Translate(Vector2.down * Time.deltaTime * 2f);
            if (hands.transform.position.y <= limitHandsDown)
            {
                appleReady = true;
                handsDown = false;
            }
        }

        if (falling == true)
        {
            transform.Translate(Vector2.down * Time.deltaTime * appleSpeed);
            appleReady = false;
        }
        else
        {
            transform.Translate(Vector2.zero);
        }      

        if(pointsApples >= goalApples)
        {
            Debug.Log("game won");
            StartCoroutine(GameController.instance.MiniGameSuceeded());

        }
        if(gameTimer <= 0)
        {
            StartCoroutine(GameController.instance.FailMiniGame());
        }
    }

    public void DropApple()
    {
        if(appleReady == true)
        {
            openHand.SetActive(true);
            closedHand.SetActive(false);
            falling = true;
            handsUp = true;
        }
        
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("collision");
        if (other.gameObject.tag.Equals("Cesta"))
        {  
            falling = false;         
            Debug.Log("cesta");
            ResetApple();
            pointsApples += 1;
            pointsApplesText.SetText(pointsApples + "/" + goalApples);
        }
        if (other.gameObject.tag.Equals("Out"))
        {
            falling = false;
            Debug.Log("out");
            ResetApple();           
        }
    }


    public void ResetApple()
    {
        Debug.Log("Reset");
        handsDown = true;
        transform.position = appleTopPos;
        closedHand.SetActive(true);
        openHand.SetActive(false);
    }
}
