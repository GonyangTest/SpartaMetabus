using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ShopUI : MonoBehaviour
{
    [SerializeField] private ItemScrollView _itemScrollView;
    [SerializeField] private Button _buyButton;
    [SerializeField] private Button _closeButton;
    [SerializeField] private List<ItemData> _items;
    
    public event Action OnItemClicked;

    private void Awake()
    {
        if (_buyButton != null)
        {
            _buyButton.onClick.AddListener(OnBuyButtonClicked);
        }
    }

    private void Start()
    {
        foreach (var item in _items)
        {
            _itemScrollView.AddItem(item);
        }
    }

    private void OnBuyButtonClicked()
    {
        OnItemClicked?.Invoke();
    }

    private void OnDestroy()
    {
        if (_buyButton != null)
        {
            _buyButton.onClick.RemoveListener(OnBuyButtonClicked);
        }
    }
} 