using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleThievesBasket : MonoBehaviour
{
    public GameObject basket;
    public float basketSpeed;
    private float limitLeft = -6.0f;
    private float limitRight = 6.0f;
    private bool movingRight;


    // Start is called before the first frame update
    void Start()
    {
        movingRight = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(movingRight == true)
        {
            if (basket.transform.position.x <= limitRight)
            {
                basket.transform.Translate(Vector2.right * Time.deltaTime * basketSpeed);
                //MoveRight();
            }
            else
            {
                movingRight = false;
            }
        }
        if (movingRight == false)
        {
            if (basket.transform.position.x >= limitLeft)
            {
                basket.transform.Translate(Vector2.left * Time.deltaTime * basketSpeed);
                //MoveRight();
            }
            else
            {
                movingRight = true;
            }
        }

        //else if (basket.transform.position.x >= 6.0f && basket.transform.position.x >= -6)
        //{

        //    basket.transform.Translate(Vector2.left * Time.deltaTime * basketSpeed);
        //}

    }

 
}
