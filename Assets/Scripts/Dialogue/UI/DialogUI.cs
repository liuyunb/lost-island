using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class DialogUI : MonoBehaviour
{
    public GameObject panel;

    public TextMeshProUGUI dialogText;

    private void OnEnable()
    {
        EventHandler.ShowDialog += OnShowDialog;
    }

    private void OnDisable()
    {
        EventHandler.ShowDialog -= OnShowDialog;
    }

    public void  OnShowDialog(string dialog)
    {
        if (dialog != string.Empty)
        {
            panel.SetActive(true);
        }
        else
        {
            panel.SetActive(false);
        }
        dialogText.text = dialog;
    }
}
