using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    public GameObject[] enemigos;
    int enemyPick;
    public bool isMoving;


    // Start is called before the first frame update
    void Start()
    {
        enemigos = GameObject.FindGameObjectsWithTag("Enemigos");
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(2.0f);
        isMoving = false;
    }
    // Update is called once per frame
    void Update()
    {
        if(isMoving == false)
        {
            enemyPick = Random.Range(0, enemigos.Length);
            isMoving = true;
            //StartCoroutine(Wait());
            Debug.Log("Aqui se movería un enemigo");
        }
        else
        {
            StartCoroutine(Wait());
            Debug.Log("En dos segundos se movería un enemigo");
        }
    }
}
