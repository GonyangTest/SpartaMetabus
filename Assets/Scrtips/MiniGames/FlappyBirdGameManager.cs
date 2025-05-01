using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlappyBirdGameManager : MonoBehaviour
{
    private static FlappyBirdGameManager _instance;

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

    public void GameOver()
    {
        Debug.Log("Game Over");
    }
}
