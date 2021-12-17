/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moving : MonoBehaviour
{
    public GameObject[] enemigos;

    public Vector3 targetPosition = new Vector3(-1.5f,0f,0f);
    public bool isMoving;

    //Dificultad
    public float speed = 2f;
    public float levelFactor = 1f;
    public float timeInLevel = 0;

    public bool reverse = false;
    public float screenSpeed = 0;

    private float targetDirection;
    int enemyIndex;

    float originPosition;

    bool gameInitialized = false;
    public GameObject pajaroPos;

    // Start is called before the first frame update
    IEnumerator Start()
    {
        yield return new WaitForSeconds(1);
        SelectEnemy();
        pajaroPos.transform.position = new Vector3(-7f, -3.5f, 0f);
    }

    // Update is called once per frame
    void Update()
    {
        SelectEnemy();
        timeInLevel += Time.deltaTime;

        if(isMoving)
        {
            Rigidbody2D rb = enemigos[enemyIndex].GetComponent<Rigidbody2D>();
            rb.MovePosition(rb.position + new Vector2(targetDirection, 0) * GetSpeedByDifficult() * Time.fixedDeltaTime);
            if ((enemigos[enemyIndex].transform.position.x >= 0 && targetDirection == 1) ||
                (enemigos[enemyIndex].transform.position.x <= 0 && targetDirection == -1))
            {
                reverse = true;
                isMoving = false;
                Debug.Log("Enemigo >" + enemyIndex + " va hacia atras");
            }   
        }

        else if(reverse)
        {
            Rigidbody2D rb = enemigos[enemyIndex].GetComponent<Rigidbody2D>();
            rb.MovePosition(rb.position + new Vector2(-1 * targetDirection, 0) * GetSpeedByDifficult() * Time.fixedDeltaTime);
            if ((enemigos[enemyIndex].transform.position.x <= originPosition && targetDirection == 1) || 
                (enemigos[enemyIndex].transform.position.x >= originPosition && targetDirection == -1))
            {
                reverse = false;
                Debug.Log("Enemigo >" + enemyIndex + " se para");
            }
        }
        else
        {
            enemigos[enemyIndex].transform.position = new Vector3(originPosition, enemigos[enemyIndex].transform.position.y, enemigos[enemyIndex].transform.position.z);
            SelectEnemy(); 
        }
    }

    private void SelectEnemy()
    {
        if(GameController.instance.isPlaying && gameInitialized == false) // O yield return new WaitForSeconds(1); en el start
        {
            enemyIndex = Random.Range(0, enemigos.Length);
            originPosition = enemigos[enemyIndex].transform.position.x;
            targetDirection = originPosition < 0 ? 1 : -1;
            isMoving = true;

            Debug.Log("Enemigo >" + enemyIndex + " va hacia delante");
            gameInitialized = true;
        }

    }


    private float GetSpeedByDifficult()
    {
        screenSpeed = speed * levelFactor + (speed * timeInLevel * 0.5f);
        return speed * levelFactor + (speed * timeInLevel * 0.5f);
    }
}
*/