﻿using System.Collections;
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
    public int nEasyLevels = 10;
    private int currentLevel = 0;

    [Tooltip("Minijuegos modo fácil. Se cargan durante las primeras  nEasyLevels  partidas")]
    public MiniGameInfo[] miniGamesList;
    [Tooltip("Minijuegos modo difícil.")]

    public MiniGameInfo[] miniGamesListHard;

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
        currentLevel++;
        yield return new WaitForSeconds(2);
        LoadMiniGame();
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
                    currentLevel = 0;
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
