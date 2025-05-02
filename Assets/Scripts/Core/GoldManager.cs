using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldManager : MonoBehaviour
{
    private static GoldManager _instance;
    public static GoldManager Instance { get { return _instance; } }

    private static string PLAYER_GOLD_KEY = "PlayerGold";
    private int _gold = 0;

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
        _gold = PlayerPrefs.GetInt(PLAYER_GOLD_KEY, 0);
    }    

    public void AddGold(int amount)
    {
        _gold += amount;
        PlayerPrefs.SetInt(PLAYER_GOLD_KEY, _gold);
    }

    public void RemoveGold(int amount)
    {
        _gold -= amount;
        PlayerPrefs.SetInt(PLAYER_GOLD_KEY, _gold);
    }

    public int GetGold()
    {
        return _gold;
    }
}
