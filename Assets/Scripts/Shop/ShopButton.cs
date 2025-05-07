using UnityEngine;


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