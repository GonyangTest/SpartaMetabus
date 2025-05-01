using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    private static GameManager _instance;

    public static GameManager Instance
    {
        get
        {
            return _instance;
        }
    }



    void Awake()
    {
        if(_instance == null)
        {
            _instance = this;
        }
    }

    void Start()
    {
        Debug.Log("GameManager Start");
    }

    void Update()
    {

    }

    public void FlappyBird()
    {
        SceneManager.LoadScene("FlappyStyleMiniGame");
    }

}
