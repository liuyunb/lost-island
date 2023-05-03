using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reset : Interactive
{
    public override void ClickEmpty()
    {
        GameController.Instance.ResetGame();
    }
}
