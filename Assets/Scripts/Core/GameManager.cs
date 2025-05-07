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
            DontDestroyOnLoad(this.gameObject); // 인스턴스가 존재하지 않으면 파괴되지 않음
        }
        else
        {
            Destroy(this.gameObject); // 이미 인스턴스가 존재하면 파괴
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
        SceneManager.LoadScene(Constant.MiniGames.FlappyBird.SCENE_NAME);
    }
}
