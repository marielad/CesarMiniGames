using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public static GameController instance;
    public float remainingTimeInLevel = 5f;
    private int currentLifes = 3;
    public int avaliableLifes = 3;
    

    public MiniGameInfo[] miniGamesList;
    private MiniGameInfo actualMiniGame;
    public enum GameStates
    { 
        introGame,
        introLevel,
        inGame,
        pauseGame
    }

    private GameStates gameState;
    // Start is called before the first frame update
    void Awake()
    {
        if (GameController.instance == null)
        {
            instance = this;
            currentLifes = avaliableLifes;
            gameState = GameStates.introGame;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this);
        }
    }
    public IEnumerator MiniGameSuceeded()
    {
        gameState = GameStates.pauseGame;
        yield return new WaitForSeconds(2);
        LoadMiniGame();
    }
    public void LoadMiniGame()
    {
        actualMiniGame = miniGamesList[Random.Range(0, miniGamesList.Length)];
        gameState = GameStates.introLevel;
        SceneManager.LoadScene(actualMiniGame.SceneName);
        IntroLevel.instance.AnimateScreen(actualMiniGame.LevelChallange);
    }

    public void StartMiniGame()
    {
        gameState = GameStates.inGame;
        //Load Time for this level
        remainingTimeInLevel = actualMiniGame.duration;
        GameplayHUD.instance.timeSlider.maxValue = actualMiniGame.duration;
        GameplayHUD.instance.timeText.text = actualMiniGame.duration.ToString();
    }

    private void Update()
    {
        if (gameState == GameStates.inGame)
        {
            remainingTimeInLevel -= Time.deltaTime;
            if (remainingTimeInLevel <= 0.0f)
            {
                //Dead
                currentLifes--;
                if (currentLifes >= 0)
                {
                    LoadMiniGame();
                }
                else
                {
                    gameState = GameStates.introGame;
                    currentLifes = avaliableLifes;
                    IntroGame.instance.AnimateScreen();
                }
            }
            else
            {
                GameplayHUD.instance.UpdateRemaningTime(remainingTimeInLevel);
            }
        }
    }
}
