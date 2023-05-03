using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : Singleton<InventoryManager>
{
    [SerializeField] private List<ItemName> items = new List<ItemName>();

    public ItemData_SO itemData;

    public int ItemCount => items.Count;

    private void OnEnable()
    {
        EventHandler.ItemUsed += OnItemUsed;
        EventHandler.ChangeItem += OnChangeItem;
        EventHandler.LoadItem += OnLoadItem;
    }
    
    private void OnDisable()
    {
        EventHandler.ItemUsed -= OnItemUsed;
        EventHandler.ChangeItem -= OnChangeItem;
        EventHandler.LoadItem -= OnLoadItem;
    }

    private void OnLoadItem()
    {
        if(ItemCount == 0)
            EventHandler.CallUpdateUI(null, -1);
        else
        {
            for(int i = 0;i < ItemCount;i++)
            {
                EventHandler.CallUpdateUI(itemData.GetItemByName(items[i]), i);
            }
        }
    }

    private void OnChangeItem(int index)
    {
        if(index < 0)
            EventHandler.CallUpdateUI(null, -1);
        else if (index <= ItemCount)
        {
            EventHandler.CallUpdateUI(itemData.GetItemByName(items[index]), index);
        }
    }

    private void OnItemUsed(ItemName itemName)
    {
        var index = GetItemIndex(itemName);
        if (index != -1)
        {
            items.RemoveAt(index);
        }

        if (items.Count == 0)
        {
            EventHandler.CallUpdateUI(null, -1);
        }
        else
        {
            EventHandler.CallUpdateUI(itemData.GetItemByName(itemName), items.Count - 1);
        }
    }

    public void AddItem(ItemName itemName)
    {
        // if (!items.Contains(itemName))
        // {
        //     items.Add(itemName);
        //     EventHandler.CallUpdateUI(itemData.GetItemByName(itemName), items.Count - 1);
        // }
        items.Add(itemName);
        EventHandler.CallUpdateUI(itemData.GetItemByName(itemName), items.Count - 1);
    }

    public int GetItemIndex(ItemName itemName)
    {
        for (int i = 0; i < items.Count; i++)
        {
            if (items[i] == itemName)
                return i;
        }

        return -1;
    }
}
