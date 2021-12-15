using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public static GameController instance;

    [Tooltip("Tiempo restante para finalizar el nivel.")]

    public float remainingTimeInLevel = 5f;
    [Tooltip("Vidas restantes para el jugador")]
    public int currentLifes = 3;
    [Tooltip("Vidas disponibles al iniciar la partida")]
    public int avaliableLifes = 3;
    [Tooltip("Minijuegos en modo fácil, antes de cargar la lista dificil")]
    public int nEasyLevels = 15;
    private int currentLevel = 1;

    [Tooltip("Minijuegos modo fácil. Se cargan durante las primeras  nEasyLevels  partidas")]
    public MiniGameInfo[] miniGamesList;
    [Tooltip("Minijuegos modo difícil.")]

    public MiniGameInfo[] miniGamesListHard;

    private MiniGameInfo actualMiniGame;

    public bool win = false;
    public bool fail = false;
    public bool isPlaying { get { return gameState == GameStates.inGame; } }
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

    private void Start()
    {
        GameplayHUD.instance.InstantiateHearts(currentLifes);
    }

    public IEnumerator MiniGameSuceeded()
    {
        if (gameState == GameStates.inGame)
        {
            gameState = GameStates.pauseGame;
            currentLevel++;
            IntroLevel.instance.UpdateLevelText(currentLevel);
            yield return new WaitForSeconds(2);
            LoadMiniGame();
        }

    }

    public IEnumerator FailMiniGame()
    {
        //Dead
        gameState = GameStates.introLevel;
        currentLifes--;
        GameplayHUD.instance.ShowFailedScreen();
        GameplayHUD.instance.RemoveOneHeart();
        yield return new WaitForSeconds(1);
        if (currentLifes > 0)
        {
            LoadMiniGame();
        }
        else
        {
            gameState = GameStates.introGame;
            currentLifes = avaliableLifes;
            GameplayHUD.instance.InstantiateHearts(currentLifes);
            currentLevel = 0;
            IntroGame.instance.AnimateScreen();
        }
    }

    public void LoadMiniGame()
    {
        if (currentLevel < nEasyLevels)
        {
            actualMiniGame = miniGamesList[Random.Range(0, miniGamesList.Length)];
        }
        else
        {
            actualMiniGame = miniGamesListHard[Random.Range(0, miniGamesListHard.Length)];
        }
        gameState = GameStates.introLevel;
        SceneManager.LoadScene(actualMiniGame.SceneName);
        StartCoroutine(IntroLevel.instance.AnimateScreen(actualMiniGame.LevelChallange, currentLevel));
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
               StartCoroutine(FailMiniGame());
            }
            else
            {
                GameplayHUD.instance.UpdateRemaningTime(remainingTimeInLevel);
            }

            if (win) {
                win = false;
                StartCoroutine(MiniGameSuceeded());
            }
            if (fail)
            {
                fail = false;
                StartCoroutine(FailMiniGame());

            }
        }
    }
}
