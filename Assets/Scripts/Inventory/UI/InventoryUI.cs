using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class InventoryUI : MonoBehaviour
{
    private Button _leftBtn, _rightBtn;

    private Slot _slot;
    
    private int _curIndex;

    private void Awake()
    {
        _leftBtn = transform.Find("Left").GetComponent<Button>();
        _rightBtn = transform.Find("Right").GetComponent<Button>();
        _slot = transform.Find("Slot").GetComponent<Slot>();
    }

    private void OnEnable()
    {
        EventHandler.UpdateUI += UpdateInventory;
    }

    private void OnDisable()
    {
        EventHandler.UpdateUI -= UpdateInventory;
    }

    private void UpdateInventory(ItemDetails itemDetails, int index)
    {
        if (itemDetails == null)
        {
            _slot.SetEmpty();
            _curIndex = -1;
            _leftBtn.interactable = false;
            _rightBtn.interactable = false;
        }
        else
        {
            _slot.SetImg(itemDetails);
            _curIndex = index;
            SwitchBtn(index);
        }
    }

    public void SwitchItem(int amount)
    {
        var index = _curIndex + amount;

        SwitchBtn(index);
        
        EventHandler.CallChangeItem(index);
    }

    private void SwitchBtn(int index)
    {
        int count = InventoryManager.Instance.ItemCount - 1;
        bool isOne = count == 0;//检测是否只有一个物品
        Debug.Log(count);
        Debug.Log(index);
        if (index == 0)
        {
            _leftBtn.interactable = false;

            _rightBtn.interactable = !isOne;
        }
        else if (index == count)
        {
            _leftBtn.interactable = !isOne;
            _rightBtn.interactable = false;
        }
        else
        {
            _leftBtn.interactable = true;
            _rightBtn.interactable = true;
        }
    }
}
