using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ItemTooltip : MonoBehaviour
{
    public TextMeshProUGUI itemTooltip;

    public void UpdateTooltip(ItemName itemName)
    {
        itemTooltip.text = itemName switch
        {
            ItemName.Key => "信箱钥匙",
            ItemName.Ticket => "一封信",
            _ => ""
        };
    }
}
