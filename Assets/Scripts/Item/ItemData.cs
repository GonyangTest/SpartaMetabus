using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Item/Item")]
public class ItemData : ScriptableObject
{
    public int id;
    public string itemName;
    public string description;
    public int price;
    public int defense;
    public Sprite icon;

    public virtual string GetEffectText()
    {
        return "";
    }
}