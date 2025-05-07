using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : InteractableObject
{
    public override void Interact()
    {
        ShopManager.Instance.OpenShop();
    }
}
