using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public class Slot : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IBeginDragHandler, IEndDragHandler, IDragHandler, IPointerClickHandler
{
    private Image _slotImg;

    public ItemTooltip itemTooltip;

    private ItemDetails _curItem;

    private bool _isSelected;

    private void Awake()
    {
        _slotImg = GetComponent<Image>();
    }

    public void SetImg(ItemDetails item)
    {
        _curItem = item;
        this.gameObject.SetActive(true);
        _slotImg.sprite = item.itemImg;
        _slotImg.SetNativeSize();
    }

    public void SetEmpty()
    {
        _curItem = null;
        this.gameObject.SetActive(false);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (this.gameObject.activeInHierarchy)
        {
            itemTooltip.UpdateTooltip(_curItem.itemName);
            itemTooltip.gameObject.SetActive(true);
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        itemTooltip.gameObject.SetActive(false);
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        // if (_curItem != null)
        // {
        //     _isSelected = true;
        //     EventHandler.CallTakeItem(_curItem, _isSelected);
        // }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        // if (_curItem != null)
        // {
        //     _isSelected = false;
        //     EventHandler.CallTakeItem(_curItem, _isSelected);
        // }
    }

    public void OnDrag(PointerEventData eventData)
    {
        
    }
    
    public void OnPointerClick(PointerEventData eventData)
    {
        if (_curItem != null)
        {
            _isSelected = !_isSelected;
            EventHandler.CallTakeItem(_curItem, _isSelected);
        }
    }
}
