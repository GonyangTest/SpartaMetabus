using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class FlappyBirdGameManager : MonoBehaviour
{
    private static FlappyBirdGameManager _instance;
    public float Score = 0;
    public float HighScore = 0;
    public GameState GameState = GameState.None;
    public event Action<GameState> OnChangeGameState;
    public static FlappyBirdGameManager Instance
    {
        get
        {
            return _instance;
        }
    }

    private void Awake()
    {
        if(_instance == null)
        {
            _instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }

        HighScore = PlayerPrefs.GetFloat(Constant.MiniGames.FlappyBird.HIGH_SCORE_KEY);
    }

    private void Start()
    {
        Time.timeScale = 0;
        ChangeGameState(GameState.Ready);
    }

    private void Update()
    {
        Score += Time.deltaTime;
        UIManager.Instance.SetScoreText(Score);

        if(HighScore < Score)
        {
            HighScore = Score;
        }
    }

    public void GameStart()
    {
        Time.timeScale = 1;
        ChangeGameState(GameState.Playing);
    }

    public void GameEnd()
    {
        Time.timeScale = 0;
        PlayerPrefs.SetFloat(Constant.MiniGames.FlappyBird.HIGH_SCORE_KEY, HighScore);
        if(Score > Constant.MiniGames.FlappyBird.SUCCESS_SCORE)
        {
            ChangeGameState(GameState.Success);
        }
        else
        {
            ChangeGameState(GameState.Fail);
        }
    }

    public void Restart()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(Constant.MiniGames.FlappyBird.SCENE_NAME);
    }

    public void ReturnMainScene()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(Constant.MAIN_SCENE_NAME);
    }

    public void ChangeGameState(GameState gameState)
    {
        GameState = gameState;
        OnChangeGameState?.Invoke(gameState);
    }
}
