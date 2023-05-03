using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MiniGame : MonoBehaviour
{
    public UnityEvent onFinish;

    [SceneName] public string gameName;

    public bool isPass;

    public void GameOver()
    {
        if (isPass)
        {
            onFinish?.Invoke();
            gameObject.SetActive(false);
        }
    }
}
