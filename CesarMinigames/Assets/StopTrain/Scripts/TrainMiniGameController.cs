using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class TrainMiniGameController : MonoBehaviour
{
    public GameObject train;
    public Vector3 trainInitialSpeed;
    public float breakForce = 0.5f;
    public Vector3 currentTrainSpeed;
    public Rigidbody2D hero;
    public Transform heroStart;
    public Vector3 heroExit;

    void Start()
    {
        currentTrainSpeed = trainInitialSpeed;
        heroExit = hero.transform.position;
        LeanTween.move(hero.gameObject, heroStart, 1.0054f);
        GameController.onTimesUp += HeroDeadEffects;
    }

    // Update is called once per frame
    void Update()
    {
        if (GameController.instance.isPlaying)
        {
            train.transform.Translate(currentTrainSpeed * Time.deltaTime);
            if (GameController.instance.remainingTimeInLevel <= 0.0f)
            {
                HeroDeadEffects();
            }
        }
  
    }

    public void PressedButton(InputAction.CallbackContext callback)
    {
        if ((callback.performed && callback.duration != 0.0f) && GameController.instance.isPlaying)
        {             
            currentTrainSpeed = new Vector3(currentTrainSpeed.x - breakForce, currentTrainSpeed.y, currentTrainSpeed.z);
            if (currentTrainSpeed.x < 0.01f)
            {
                StopTrain();
                HeroWins();
                StartCoroutine(GameController.instance.MiniGameSuceeded());
            }
        }
    }

    void StopTrain()
    {
        currentTrainSpeed = new Vector3(0.0f, currentTrainSpeed.y, currentTrainSpeed.z);

    }
    public void EndGame()
    {
        StartCoroutine(CrashTrain());        
        HeroDeadEffects();
        StartCoroutine(GameController.instance.FailMiniGame());
    }
    IEnumerator CrashTrain()
    {
        StopTrain();
        Camera.current.GetComponent<ShakeScript>().ShakeObject();
        yield return new WaitForSeconds(0.5f);
        Camera.current.GetComponent<ShakeScript>().StopShake();
    }
    void HeroDeadEffects()
    {
        GameController.onTimesUp -= HeroDeadEffects;
        if (hero != null)
        {
            hero.constraints = RigidbodyConstraints2D.None;
            hero.AddForce(Vector2.up * 10f, ForceMode2D.Impulse);
            LeanTween.scale(hero.gameObject, Vector3.zero, 1.5f);
        }

    }

    void HeroWins()
    {
        hero.GetComponent<SpriteRenderer>().flipX = true;
        LeanTween.move(hero.gameObject, heroExit, 3.5f);
    }
}
