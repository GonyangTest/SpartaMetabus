using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopNPC : InteractableObject
{
    public List<ItemData> shopItems;

    public override void Interact()
    {
        ShopManager.Instance.OpenShop(shopItems);
    }
}
