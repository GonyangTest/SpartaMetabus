using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyManager : MonoBehaviour
{
    [Header("메인 게임")]
    [SerializeField] public KeyCode InteractKey = KeyCode.E;
    
    [Header("미니 게임")]
    [SerializeField] public KeyCode QuitKey = KeyCode.Q;
    [SerializeField] public KeyCode RestartKey = KeyCode.R;
    [SerializeField] public KeyCode PauseKey = KeyCode.Escape;

    private static KeyManager _instance;
    public static KeyManager Instance
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
    }
}
