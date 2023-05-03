using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallHolder : Interactive
{
    public BallName matchBall;

    public HashSet<BallHolder> LineHolder = new HashSet<BallHolder>();

    public Ball curBall;

    public bool isEmpty;

    public override void ClickEmpty()
    {
        foreach (var holder in LineHolder)
        {
            if (holder.isEmpty)
            {
                if(curBall == null)
                    return;
                curBall.transform.SetParent(holder.transform);
                StartCoroutine(MoveBall(curBall, holder.transform.position));
                
                holder.CheckBall(curBall);
                curBall = null;

                this.isEmpty = true;
                holder.isEmpty = false;
                
                EventHandler.CallCheckMiniGame();
            }
        }
    }

    public void CheckBall(Ball ball)
    {
        curBall = ball;
        if (ball.ballName == matchBall)
        {
            ball.isMatch = true;
            ball.SetRight();
        }
        else
        {
            ball.isMatch = false;
            ball.SetWrong();
        }
    }

    IEnumerator MoveBall(Ball ball, Vector3 targetPos)
    {
        canInteractive = false;
        while (Vector3.Distance(targetPos, ball.transform.position) >= 0.01f)
        {
            ball.transform.position = Vector3.Lerp(ball.transform.position, targetPos, 0.2f);
            yield return null;
        }

        canInteractive = true;
    }
}
