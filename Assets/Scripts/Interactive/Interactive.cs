using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactive : MonoBehaviour
{
    public ItemName requiredItem;

    public bool isDone;

    public static bool canInteractive = true;

    public void CheckItem(ItemName itemName)
    {
        if (itemName == requiredItem)
        {
            isDone = true;
            ClickAction();
            EventHandler.CallItemUsed(itemName);
        }
        else
        {
           ClickEmpty();
        }
    }

    protected virtual void ClickAction()
    {
        
    }

    public virtual void ClickEmpty()
    {
        Debug.Log("you dont have what i need");
    }
}
