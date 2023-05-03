
using System;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "MiniGameData", menuName = "Data/MiniGameData")]
public class MiniGame_SO : ScriptableObject
{
    [SceneName] public string miniGameName;
    
    public List<BallDetails> ballList = new List<BallDetails>();

    public List<LineConection> lineList = new List<LineConection>();

    public List<BallName> startBallOrder = new List<BallName>();

    public BallDetails GetBallByName(BallName ballName)
    {
        return ballList.Find(i => i.ballName == ballName);
    }
}

[Serializable]
public class BallDetails
{
    public BallName ballName;
    public Sprite rightImg;
    public Sprite wrongImg;
}

[Serializable]
public class LineConection
{
    public int from;
    public int to;
}