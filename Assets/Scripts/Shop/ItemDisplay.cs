using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class ItemDisplay : MonoBehaviour
{
    [SerializeField] private Image _itemIcon;
    [SerializeField] private TextMeshProUGUI _itemName;
    [SerializeField] private TextMeshProUGUI _itemDescription;
    [SerializeField] private TextMeshProUGUI _itemPrice;
    [SerializeField] private TextMeshProUGUI _itemEffect;

    private ItemData _itemData;
    
    public void SetupItem(ItemData itemData)
    {
        _itemData = itemData;
        _itemIcon.sprite = itemData.icon;
        _itemName.text = itemData.itemName;
        _itemDescription.text = itemData.description;
        _itemEffect.text = itemData.GetEffectText();
        _itemPrice.text = itemData.price.ToString();
    }
    public void OnClickItemButton()
    {
        Debug.Log("아이템 데이터 설정: " + _itemData.itemName);
        // 누른 아이템 정보 전달
        ShopManager.Instance.SetItemData(_itemData);
    }
}
