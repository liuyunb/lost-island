using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    private Dictionary<string, bool> _miniGameList = new Dictionary<string, bool>();

    private void OnEnable()
    {
        EventHandler.LoadItem += OnLoadItem;
        EventHandler.MiniGameOver += OnMiniGameOver;
    }

    private void OnDisable()
    {
        EventHandler.LoadItem -= OnLoadItem;
        EventHandler.MiniGameOver -= OnMiniGameOver;
    }

    void Start()
    {
        EventHandler.CallChangeGameStata(GameStata.Start);
    }

    private void OnLoadItem()
    {
        foreach (var game in FindObjectsOfType<MiniGame>())
        {
            if (_miniGameList.TryGetValue(game.gameName, out bool isPass))
            {
                game.isPass = isPass;
                game.GameOver();
            }
        }
    }

    private void OnMiniGameOver(string gameName)
    {
        _miniGameList[gameName] = true;
    }
    
}
