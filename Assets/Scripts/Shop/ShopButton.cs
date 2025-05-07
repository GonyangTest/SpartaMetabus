using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;


public class ShopButton : MonoBehaviour
{
    public void OnBuyButtonClicked()
    {
        Debug.Log("구매 버튼 클릭");
        ShopManager.Instance.BuyItem();
    }

    public void OnClickCloseShopButton()
    {
        Debug.Log("상점 닫기 버튼 클릭");
        ShopManager.Instance.CloseShop();
    }
}