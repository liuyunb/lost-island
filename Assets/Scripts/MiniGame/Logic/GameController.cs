using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameController : Singleton<GameController>
{
    public UnityEvent onFinish;
    
    public MiniGame_SO miniGameData;

    public GameObject lineParent;

    public LineRenderer linePfb;

    public Ball ballPfb;

    public Transform[] ballHolders;

    private void OnEnable()
    {
        EventHandler.CheckMiniGame += OnCheckMiniGame;
    }

    private void OnDisable()
    {
        EventHandler.CheckMiniGame -= OnCheckMiniGame;
    }

    private void Start()
    {
        CreateBalls();
        CreateLines();
    }

    private void OnCheckMiniGame()
    {
        foreach (var ball in FindObjectsOfType<Ball>())
        {
            if (!ball.isMatch)
                return;
        }
        EventHandler.CallMiniGameOver(miniGameData.miniGameName);
        onFinish?.Invoke();
    }

    public void ResetGame()
    {
        for (int i = 0; i < ballHolders.Length; i++)
        {
            if(ballHolders[i].transform.childCount > 0)
                Destroy(ballHolders[i].GetChild(0).gameObject);
        }
        
        CreateBalls();
    }
    
    private void CreateLines()
    {
        foreach (var conection in miniGameData.lineList)
        {
            var line = Instantiate(linePfb, lineParent.transform);
            line.SetPosition(0, ballHolders[conection.from].position);
            line.SetPosition(1, ballHolders[conection.to].position);
            ballHolders[conection.from].GetComponent<BallHolder>().LineHolder
                .Add(ballHolders[conection.to].GetComponent<BallHolder>());
            ballHolders[conection.to].GetComponent<BallHolder>().LineHolder
                .Add(ballHolders[conection.@from].GetComponent<BallHolder>());
        }
    }

    private void CreateBalls()
    {
        for (int i = 0; i < miniGameData.startBallOrder.Count; i++)
        {
            if (miniGameData.startBallOrder[i] == BallName.None)
            {
                ballHolders[i].GetComponent<BallHolder>().isEmpty = true;
                continue;
            }

            var ball = Instantiate(ballPfb, ballHolders[i]);
            ball.SetUpBall(miniGameData.GetBallByName(miniGameData.startBallOrder[i]));
            ballHolders[i].GetComponent<BallHolder>().CheckBall(ball);
        }
    }
}
