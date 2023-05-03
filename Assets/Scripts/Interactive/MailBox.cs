using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MailBox : Interactive
{
    private SpriteRenderer _sr;

    private BoxCollider2D _bc;

    public Sprite openImg;

    private void Awake()
    {
        _sr = GetComponent<SpriteRenderer>();
        _bc = GetComponent<BoxCollider2D>();
    }

    private void OnEnable()
    {
        EventHandler.LoadItem += OnLoadItem;
    }

    private void OnDisable()
    {
        EventHandler.LoadItem -= OnLoadItem;
    }

    private void OnLoadItem()
    {
        if (!isDone)
        {
            transform.GetChild(0).gameObject.SetActive(false);
        }
        else
        {
            _sr.sprite = openImg;
            _bc.enabled = false;
        }
    }
    
    protected override void ClickAction()
    {
        _sr.sprite = openImg;
        transform.GetChild(0).gameObject.SetActive(true);
    }
}
