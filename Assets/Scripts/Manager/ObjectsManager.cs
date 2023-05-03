using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectsManager : MonoBehaviour
{
    private Dictionary<ItemName, bool> _itemAvilable = new Dictionary<ItemName, bool>();
    private Dictionary<string, bool> _interactive = new Dictionary<string, bool>();
    private void OnEnable()
    {
        EventHandler.UnloadItem += OnBeforeUnloadItem;
        EventHandler.LoadItem += OnAfterLoadItem;
        EventHandler.UpdateUI += OnUpdateUI;
    }

    private void OnDisable()
    {
        EventHandler.UnloadItem -= OnBeforeUnloadItem;
        EventHandler.LoadItem -= OnAfterLoadItem;
        EventHandler.UpdateUI -= OnUpdateUI;
    }

    private void OnBeforeUnloadItem()
    {
        foreach (var item in FindObjectsOfType<Item>())
        {
            if (!_itemAvilable.ContainsKey(item.itemName))
                _itemAvilable.Add(item.itemName, true);
        }

        foreach (var item in FindObjectsOfType<Interactive>())
        {
            if(!_interactive.ContainsKey(item.name))
                _interactive.Add(item.name, item.isDone);
            else
            {
                _interactive[item.name] = item.isDone;
            }
        }
    }

    private void OnAfterLoadItem()
    {
        foreach (var item in FindObjectsOfType<Item>())
        {
            if (_itemAvilable.ContainsKey(item.itemName))
            {
                item.gameObject.SetActive(_itemAvilable[item.itemName]);
            }
        }
        
        foreach (var item in FindObjectsOfType<Interactive>())
        {
            if(!_interactive.ContainsKey(item.name))
                _interactive.Add(item.name, item.isDone);
            else
            {
                item.isDone = _interactive[item.name];
            }
        }
    }

    private void OnUpdateUI(ItemDetails itemDetails, int index)
    {
        if(itemDetails == null)
            return;
        if(!_itemAvilable.ContainsKey(itemDetails.itemName))
            _itemAvilable.Add(itemDetails.itemName, false);
        else
        {
            _itemAvilable[itemDetails.itemName] = false;
        }
    }
}
