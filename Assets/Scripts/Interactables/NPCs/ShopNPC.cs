using System.Collections.Generic;
using UnityEngine;

public class ShopNPC : MonoBehaviour, IInteractableObject
{
    public List<ItemData> shopItems;

    public void Interact()
    {
        ShopManager.Instance.OpenShop(shopItems);
    }
}
