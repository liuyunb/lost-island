using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MouseManager : Singleton<MouseManager>
{
    private Vector3 WorldPos =>
        Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y));

    private bool _canClick;
    
    
    public RectTransform hand;

    private bool _holdItem;

    private ItemDetails _curItem;

    private void OnEnable()
    {
        EventHandler.TakeItem += OnTakeItem;
        EventHandler.ItemUsed += OnItemUsed;
    }


    private void Update()
    {
        _canClick = GetObjAtMousePos();
        
        if (_holdItem)
        {
            hand.position = Input.mousePosition;
        }

        if (InteractiveWithUI())
            return;

        if (_canClick && Input.GetMouseButtonUp(0))
        {
            //处理鼠标点击事件
            ClickAction(GetObjAtMousePos().gameObject);
        }
    }

    private void OnDisable()
    {
        EventHandler.TakeItem -= OnTakeItem;
        EventHandler.ItemUsed -= OnItemUsed;
    }

    private void OnItemUsed(ItemName itemName)
    {
        hand.gameObject.SetActive(false);
    }

    private void OnTakeItem(ItemDetails itemDetails, bool isSelected)
    {
        _holdItem = isSelected;
        if (isSelected)
        {
            _curItem = itemDetails;
        }
        hand.gameObject.SetActive(isSelected);
            
    }

    public void ClickAction(GameObject obj)
    {
        switch (obj.tag)
        {
            case "Teleport":DoTransition(obj.GetComponent<Teleport>());
                break;
            case "Key":ClickItem(obj.GetComponent<Item>());
                break;
            case  "Interactive": DoInteractive(obj.GetComponent<Interactive>());
                break;
        }
    }

    private void ClickItem(Item item)
    {
        item?.ClickAction();
    }

    private void DoInteractive(Interactive interactive)
    {
        if(_holdItem && Interactive.canInteractive)
            interactive?.CheckItem(_curItem.itemName);
        else
            interactive?.ClickEmpty();
    }
    

    private void DoTransition(Teleport teleport)
    {
        teleport?.TeleportScene();
    }
    
    private Collider2D GetObjAtMousePos()
    {
        return Physics2D.OverlapPoint(WorldPos);
    }

    public bool InteractiveWithUI()
    {
        if (EventSystem.current != null && EventSystem.current.IsPointerOverGameObject())
            return true;
        return false;
    }
}
