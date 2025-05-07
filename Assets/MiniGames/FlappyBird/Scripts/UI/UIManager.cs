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
    public const string DESCRIPTION = @"조작: 마우스 왼쪽 버튼을 클릭하면 비행기가 위로 쭉 올라가고, 다시 클릭하면 아래로 쭉 내려갑니다
장애물: 바위 사이를 통과하여 점수를 얻으세요
목표: 30초 이상 생존하세요. 성공 시 100골드를 획득합니다!";

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

    public void Initialize()
    {
        highScore = FlappyBirdGameManager.Instance.HighScore;
        FlappyBirdGameManager.Instance.OnChangeGameState += HandleGameState;
        HandleGameState(GameState.Ready);
    }

    private void HandleGameState(GameState gameState)
    {
        switch(gameState)
        {
            case GameState.Ready:
                HideGameEndPanel();
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

    public void HideGameEndPanel()
    {
        GameOverPanel.SetActive(false);
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
