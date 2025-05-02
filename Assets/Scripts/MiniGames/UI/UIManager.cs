using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;


public class UIManager : MonoBehaviour
{
    private static UIManager _instance;
    public static UIManager Instance
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

    [Header("게임 설명")]
    [SerializeField] public GameObject GameStartPanel;
    [SerializeField] public TextMeshProUGUI GameHelpTitleText;
    [SerializeField] public TextMeshProUGUI GameHelpDescriptionText;
    public const string TITLE = "게임 설명";
    public const string DESCRIPTION = @"점프: 마우스 왼쪽 버튼을 클릭하여 비행기를 날게 합니다

장애물: 바위 사이를 통과하여 점수를 얻으세요

목표: 최대한 오래 살아남아 높은 점수를 획득하세요";

    [Header("게임 종료")]
    [SerializeField] public GameObject GameOverPanel;
    [SerializeField] public TextMeshProUGUI GameOverResultText;
    [SerializeField] public TextMeshProUGUI GameOverInteractableText;

    [Header("게임 플레이")]
    [SerializeField] public TextMeshProUGUI ScoreText;
    [SerializeField] public TextMeshProUGUI HighScoreText;

    private float highScore;

    private void Start()
    {
        highScore = FlappyBirdGameManager.Instance.HighScore;
        FlappyBirdGameManager.Instance.OnChangeGameState += HandleGameState;
    }   

    private void HandleGameState(GameState gameState)
    {
        switch(gameState)
        {
            case GameState.Ready:
                ShowGameStartPanel();
                UpdateHighScoreText(highScore);
                break;
            case GameState.Playing:
                HideGameStartPanel();
                break;
            case GameState.Paused:
                break;
            case GameState.Success:
                ShowGameEndPanel(true);
                break;
            case GameState.Fail:
                ShowGameEndPanel(false);
                break;
        }
    }

    public void ShowGameStartPanel()
    {
        GameStartPanel.SetActive(true);
        GameHelpTitleText.text = TITLE;
        GameHelpDescriptionText.text = DESCRIPTION;
    }

    public void HideGameStartPanel()
    {
        GameStartPanel.SetActive(false);
    }

    public void ShowGameEndPanel(bool isSuccess)
    {
        if(isSuccess)
        {
            GameOverResultText.text = "미션 성공";
        }
        else
        {
            GameOverResultText.color = Color.red;
            GameOverResultText.text = "미션 실패";
        }
        
        GameOverPanel.SetActive(true);
        GameOverInteractableText.text = $"{KeyManager.Instance.QuitKey.ToString()}를 눌러 나가기\n{KeyManager.Instance.RestartKey.ToString()}를 눌러 다시 시작";
    }

    public void SetScoreText(float score)
    {
        ScoreText.text = $"점수: {score.ToString("F0")}";

        if(score > highScore)
        {
            highScore = score;
            UpdateHighScoreText(highScore);
        }
    }

    public void UpdateHighScoreText(float highScore)
    {
        HighScoreText.text = $"최고 점수: {highScore.ToString("F0")}";
    }
}
