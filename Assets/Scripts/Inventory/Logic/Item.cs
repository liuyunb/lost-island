using System.Collections;
using System.Collections.Generic;
using UnityEditor.U2D.Path.GUIFramework;
using UnityEngine;

public class Item : MonoBehaviour
{
    public ItemName itemName;

    public void ClickAction()
    {
        gameObject.SetActive(false);
        InventoryManager.Instance.AddItem(itemName);
    }
}
