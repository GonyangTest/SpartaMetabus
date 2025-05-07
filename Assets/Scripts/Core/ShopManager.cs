using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ShopManager : MonoBehaviour
{
    private static ShopManager _instance;

    public static ShopManager Instance
    {
        get
        {
            return _instance;
        }
    }

    private List<ItemData> _shopItems;
    [SerializeField] private GameObject shopPanel;

    private ItemData _itemData;

    void Awake()
    {
        if(_instance == null)
        {
            _instance = this;
        }
    }

    private void Start()
    {
        // 시작시 상점 패널 비활성화
        if (shopPanel != null)
        {
            shopPanel.SetActive(false);
        }
    }

    // 상점 패널 열기
    public void OpenShop(List<ItemData> shopItems)
    {
        _shopItems = shopItems;
        _itemData = null;

        if (shopPanel != null)
        {
            MainUIManager.Instance.OpenShopPanel();
        }
    }

    // 상점 패널 닫기
    public void CloseShop()
    {
        _itemData = null;

        if (shopPanel != null)
        {
            MainUIManager.Instance.CloseShopPanel();
        }
    }

    // 아이템 목록 표시
    public List<ItemData> GetShopItems()
    {
        return _shopItems;
    }

    public void SetItemData(ItemData itemData)
    {
        Debug.Log("아이템 데이터 설정: " + itemData.itemName);
        _itemData = itemData;
    }

    // 아이템 구매
    public void BuyItem()
    {
        if(_itemData == null)
        {
            Debug.Log("아이템 데이터가 설정되지 않았습니다.");
            return;
        }

        Debug.Log("아이템 구매 시도: " + _itemData.itemName);

        if(_itemData.price > GoldManager.Instance.GetGold())
        {
            Debug.Log("돈이 부족합니다.");
        }
        else
        {
            GoldManager.Instance.AddGold(-_itemData.price);
            // InventoryManager.Instance.AddItem(item);
            Debug.Log(_itemData.itemName + " 아이템을 구매했습니다.");
        }
    }
}
