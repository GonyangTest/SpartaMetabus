using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;


public class MiniGameButton : MonoBehaviour
{
    public void OnClickReturnMainButton()
    {
        FlappyBirdGameManager.Instance.ReturnMainScene();
    }

    public void OnClickFlappyBirdStartButton()
    {
        FlappyBirdGameManager.Instance.GameStart();
    }
}