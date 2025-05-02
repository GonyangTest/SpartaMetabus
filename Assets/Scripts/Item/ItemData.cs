using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemType
{
    None,
    Weapon,
    Armor,
    Accessory
}

[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Item")]
public class ItemData : ScriptableObject
{
    public int id;
    public string itemName;
    public string description;
    public int price;
    public int power;
    public int defense;
    public Sprite icon;
    
    public ItemType itemType;
}