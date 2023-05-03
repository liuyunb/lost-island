using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogController : Interactive
{
    // Start is called before the first frame update
    public Dialog_SO dialogEmpty;
    public Dialog_SO dialogFinish;

    private Stack<string> _dialogEmptyStack = new Stack<string>();
    private Stack<string> _dialogFinishStack = new Stack<string>();

    private bool _isFill = false;

    private void Start()
    {
        FillDialog();
    }

    private void FillDialog()
    {
        if (!_isFill)
        {
            for (int i = dialogEmpty.dialog.Count - 1; i > -1; i--)
            {
                _dialogEmptyStack.Push(dialogEmpty.dialog[i]);
            }

            for (int i = dialogFinish.dialog.Count - 1; i > -1; i--)
            {
                _dialogFinishStack.Push(dialogFinish.dialog[i]);
            }
        }
        else
        {
            if(!isDone)
                _dialogEmptyStack.Push(dialogEmpty.dialog[dialogEmpty.dialog.Count - 1]);
            else
            {
                _dialogFinishStack.Push(dialogEmpty.dialog[dialogFinish.dialog.Count - 1]);
            }

        }

        _isFill = true;
    }

    public override void ClickEmpty()
    {
        if(isDone)
            StartCoroutine(ShowDialog(_dialogFinishStack));
        else
            StartCoroutine(ShowDialog(_dialogEmptyStack));
    }

    protected override void ClickAction()
    {
        StartCoroutine(ShowDialog(_dialogFinishStack));
    }

    IEnumerator ShowDialog(Stack<string> dialog)
    {
        if (dialog.TryPop(out string result))
        {
            EventHandler.CallShowDialog(result);
            EventHandler.CallChangeGameStata(GameStata.Pause);
            // if(dialog.Count == 0)
            //     FillDialog();
            yield return null;
        }
        else
        {
            EventHandler.CallShowDialog(string.Empty);
            EventHandler.CallChangeGameStata(GameStata.Start);
            FillDialog();
        }
    }
}
