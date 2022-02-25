using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GameLoop : MonoBehaviour
{
    public bool isPlaying = false;
    public float stopTime = 0.5f;
    public GameObject palancaUp;
    public GameObject palancaDown;
    public AudioClip leverSound;
    public CandyManager[] columns;

    private int lastRowStopped = 0;
    private bool winCondition;
    private bool animationCorroutineIsRunning;
    private AudioSource AudioSource;
    private string candy = "";

    void Start()
    {
        ResetGame();
        AudioSource = GetComponent<AudioSource>();
    }

    public void OnPressedButton(InputAction.CallbackContext value) {
        if (value.started)
        {
            CheckGameStatus();
        }
    }
    public void CheckGameStatus() 
    {
        Debug.Log("Checking: " + isPlaying); 
        if (isPlaying && lastRowStopped <= columns.Length) 
        {
            StartCoroutine(AnimacionPalanca());
            columns[lastRowStopped].StopCandy();
            lastRowStopped++;
            Debug.Log("Ultima columna: "+lastRowStopped);
            if (lastRowStopped == columns.Length)
            {
                CheckResults();
            }
        }
        else
        {
            StartGame();
        }

    }
    
    public void StartGame()
    {
        if (!animationCorroutineIsRunning)
        {
            StartCoroutine(AnimacionPalanca());
        }
        for (int i = 0; i < columns.Length; i++)
        {
            StartCoroutine(columns[i].CandyRotation());
        }

        isPlaying = true;
    }
    IEnumerator AnimacionPalanca() {
        animationCorroutineIsRunning = true;
        StartCoroutine(PlayLeverSound());
        palancaUp.SetActive(false);
        palancaDown.SetActive(true);
        yield return new WaitForSeconds(stopTime);
        palancaUp.SetActive(true);
        palancaDown.SetActive(false);
        yield return new WaitForSeconds(stopTime);
        animationCorroutineIsRunning = false;
    }

    IEnumerator PlayLeverSound()
    {
        AudioSource.PlayOneShot(leverSound);
        yield return new WaitForSeconds(1f);
        AudioSource.Stop();
    }

    public void CheckResults()
    {
        List<string> candyNameList = new List<string>();

        foreach (var column in columns)
        {
            candyNameList.Add(column.CorrectPosition());
        }

        foreach (var candyName in candyNameList)
        {
            if (candy.Equals(candyName))
            {
                winCondition = true;
                Debug.Log("Candy es " + candy + " y CandyName es " + candyName);
            }
            else {
                winCondition = false;
            }
            candy = candyName;
        }

        if (winCondition)
        {
            Victory();
        }
        else
        {
            Defeat();
            ResetGame();
        }
    }

    public void ResetGame() 
    {
        isPlaying = false;
        lastRowStopped = 0;
    }

    public void Victory()
    {
        Debug.Log("Win");
        StartCoroutine(GameController.instance.MiniGameSuceeded());
    }

    public void Defeat()
    {
        Debug.Log("Game Over");

        StartCoroutine(GameController.instance.FailMiniGame());

    }


}
