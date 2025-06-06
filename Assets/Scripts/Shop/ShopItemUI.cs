using System.Collections.Generic;
using UnityEngine;

public class ShopUI : MonoBehaviour
{
    [SerializeField] private ItemScrollView _itemScrollView;
    private List<ItemData> _items;

    private void UpdateItemList()
    {
        _items = ShopManager.Instance.GetShopItems();
        _itemScrollView.ClearItems();
        foreach (var item in _items)
        {
            _itemScrollView.AddItem(item);
        }
    }

    private void OnEnable()
    {
        UpdateItemList();
    }
} 