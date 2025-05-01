using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FlappyBirdGameManager : MonoBehaviour
{
    private static FlappyBirdGameManager _instance;

    public const float SuccessScore = 30;
    public float Score = 0;
    public float HighScore = 0;
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
        }
    }

    private void Start()
    {
        Time.timeScale = 0;
        UIManager.Instance.ShowGameStartPanel();
        HighScore = PlayerPrefs.GetFloat("HighScore");
        UIManager.Instance.SetHighScoreText(HighScore);
    }

    private void Update()
    {
        Score += Time.deltaTime;
        UIManager.Instance.SetScoreText(Score);

        if(HighScore < Score)
        {
            HighScore = Score;
            UIManager.Instance.SetHighScoreText(HighScore);
        }
    }

    public void GameStart()
    {
        Time.timeScale = 1;
        UIManager.Instance.HideGameStartPanel();
    }

    public void GameEnd()
    {
        Time.timeScale = 0;
        PlayerPrefs.SetFloat("HighScore", HighScore);
        

        if(Score > 30f)
        {
            UIManager.Instance.ShowGameEndPanel(true);
        }
        else
        {
            UIManager.Instance.ShowGameEndPanel(false);
        }
    }

    public void Restart()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneNames.MiniGames.FlappyBird);
    }

    public void ReturnMainScene()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneNames.Main);
    }
}
