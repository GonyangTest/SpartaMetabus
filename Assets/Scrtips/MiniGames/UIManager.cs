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
    public const string Title = "게임 설명";
    public const string Description = @"점프: 마우스 왼쪽 버튼을 클릭하여 비행기를 날게 합니다

장애물: 바위 사이를 통과하여 점수를 얻으세요

목표: 최대한 오래 살아남아 높은 점수를 획득하세요";
    [SerializeField] public Button LeftButton;
    [SerializeField] public Button RightButton;

    [Header("게임 종료")]
    [SerializeField] public GameObject GameOverPanel;
    [SerializeField] public TextMeshProUGUI GameOverResultText;
    [SerializeField] public TextMeshProUGUI GameOverInteractableText;
    [SerializeField] public TextMeshProUGUI GameOverScoreText;
    [SerializeField] public TextMeshProUGUI GameOverHighScoreText;

    [Header("게임 플레이")]
    [SerializeField] public TextMeshProUGUI ScoreText;
    [SerializeField] public TextMeshProUGUI HighScoreText;

    public void OnClickLeftButton()
    {
        FlappyBirdGameManager.Instance.ReturnMainScene();
    }

    public void OnClickRightButton()
    {
        FlappyBirdGameManager.Instance.GameStart();
    }

    public void ShowGameStartPanel()
    {
        GameStartPanel.SetActive(true);
        GameHelpTitleText.text = Title;
        GameHelpDescriptionText.text = Description;
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
    }

    public void SetHighScoreText(float highScore)
    {
        HighScoreText.text = $"최고 점수: {highScore.ToString("F0")}";
    }
}
