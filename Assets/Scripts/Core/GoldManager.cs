using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GoldManager : MonoBehaviour
{
    private static GoldManager _instance;

    public static GoldManager Instance
    {
        get
        {
            return _instance;
        }
    }

    private int _currentGold = 0;
    [SerializeField] private TextMeshProUGUI _goldText;

    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
        }
    }

    // 현재 골드 반환
    public int GetGold()
    {
        _currentGold = PlayerPrefs.GetInt("PlayerGold", 0);
        return _currentGold;
    }

    // 골드 추가 (감소시 음수값 전달)
    public void AddGold(int amount)
    {
        _currentGold += amount;
        
        // 골드가 0 미만으로 내려가지 않도록 방지
        if (_currentGold < 0)
        {
            _currentGold = 0;
        }

        PlayerPrefs.SetInt("PlayerGold", _currentGold);
    }
}
