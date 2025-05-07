using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;


public class MainUIManager : MonoBehaviour
{
    private static MainUIManager _instance;
    public static MainUIManager Instance
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

    [Header("UI")]
    [SerializeField] public GameObject InventoryPanel;
    [SerializeField] public GameObject ShopPanel;
    [SerializeField] public GameObject NPCCommunicationPanel;
    [SerializeField] public GameObject MainUIPanel;
    [SerializeField] public TextMeshProUGUI GoldText;

    private float highScore;

    private void Start()
    {
    }

    public void Update()
    {
        int gold = GoldManager.Instance.GetGold();
        GoldText.text = gold.ToString();
    }

    public void ShowInventoryPanel()
    {
    }

    public void ShowNPCCommunicationPanel()
    {
    }

    public void UpdateMainUIPanel()
    {
        UpdateGoldText();
    }

    public void OpenShopPanel()
    {
        ShopPanel.SetActive(true);
    }

    public void CloseShopPanel()
    {
        ShopPanel.SetActive(false);
    }
    
    public void UpdateGoldText()
    {
        int gold = GoldManager.Instance.GetGold();
        GoldText.text = gold.ToString();
    }

}
