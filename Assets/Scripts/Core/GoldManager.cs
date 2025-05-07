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

    [SerializeField] private int currentGold = 0;
    [SerializeField] private TextMeshProUGUI goldText;

    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        UpdateGoldUI();
    }

    // 현재 골드 반환
    public int GetGold()
    {
        return currentGold;
    }

    // 골드 추가 (감소시 음수값 전달)
    public void AddGold(int amount)
    {
        currentGold += amount;
        
        // 골드가 0 미만으로 내려가지 않도록 방지
        if (currentGold < 0)
        {
            currentGold = 0;
        }
        
        UpdateGoldUI();
    }

    // 골드 설정
    public void SetGold(int amount)
    {
        currentGold = Mathf.Max(0, amount);
        UpdateGoldUI();
    }

    // UI 업데이트
    private void UpdateGoldUI()
    {
        if (goldText != null)
        {
            goldText.text = currentGold.ToString();
        }
    }
}
