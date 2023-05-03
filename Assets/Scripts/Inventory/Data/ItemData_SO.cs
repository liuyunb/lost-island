
using System;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "ItemData" , menuName = "Data/ItemData")]
public class ItemData_SO : ScriptableObject
{
    public List<ItemDetails> items = new List<ItemDetails>();

    public ItemDetails GetItemByName(ItemName itemName)
    {
        return items.Find(i => i.itemName == itemName);
    }
}

[Serializable]
public class ItemDetails
{
    public ItemName itemName;

    public Sprite itemImg;
}