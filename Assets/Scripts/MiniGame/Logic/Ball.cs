using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class Ball : MonoBehaviour
{
    public BallName ballName;
    
    private BallDetails _ball;

    private SpriteRenderer _sr;

    public bool isMatch;

    private void Awake()
    {
        _sr = GetComponent<SpriteRenderer>();
    }

    public void SetUpBall(BallDetails ballDetails)
    {
        _ball = ballDetails;
        ballName = ballDetails.ballName;
        if (isMatch)
            SetRight();
        else
            SetWrong();
    }

    public void SetRight()
    {
        _sr.sprite = _ball.rightImg;
    }

    public void SetWrong()
    {
        _sr.sprite = _ball.wrongImg;
    }
}
