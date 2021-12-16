using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class HitDectector : MonoBehaviour
{
    public TrainMiniGameController trainController;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (trainController != null && collision.gameObject.name.Equals("Dead"))
        {
            trainController.EndGame();       
        }
    }
}
