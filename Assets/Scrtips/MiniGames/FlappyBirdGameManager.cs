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

    private void Start()
    {
        Debug.Log("Start");
        Obstacle[] obstacles = FindObjectsOfType<Obstacle>();
        Vector3 lastPosition = obstacles[0].transform.position;

        foreach(Obstacle obstacle in obstacles)
        {
            lastPosition = obstacle.SetRandomPlace(lastPosition);
        }
    }

    public void GameOver()
    {
        Debug.Log("Game Over");
    }
}
