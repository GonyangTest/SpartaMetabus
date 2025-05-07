using UnityEngine;
using TMPro;


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
    [SerializeField] private GameObject _inventoryPanel;
    [SerializeField] private GameObject _shopPanel;
    [SerializeField] private GameObject _npcCommunicationPanel;
    [SerializeField] private GameObject _mainUIPanel;
    [SerializeField] private TextMeshProUGUI _goldText;

    private void Start()
    {
        GoldManager.Instance.OnChangeGold += UpdateGoldText;
        UpdateGoldText(GoldManager.Instance.GetGold());
    }

    // 인벤토리 패널 표시 (추후 구현)
    public void ShowInventoryPanel()
    {
    }

    // NPC 대화 패널 표시 (추후 구현)
    public void ShowNPCCommunicationPanel()
    {
    }

    // 상점 패널 표시
    public void OpenShopPanel()
    {
        _shopPanel.SetActive(true);
    }

    // 상점 패널 닫기
    public void CloseShopPanel()
    {
        _shopPanel.SetActive(false);
    }
    
    // 골드 텍스트 업데이트
    public void UpdateGoldText(int gold)
    {
        _goldText.text = gold.ToString();
    }

}
