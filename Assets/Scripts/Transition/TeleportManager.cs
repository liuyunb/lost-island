using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TeleportManager : Singleton<TeleportManager>
{
    [SceneName] public string startScene;
    
    public CanvasGroup fadePanel;

    private bool _isFade;

    public float fadeDuration = 0.5f;

    private bool _canTransition;

    private void OnEnable()
    {
        StartCoroutine(Transition(string.Empty, startScene));
        EventHandler.ChangeGameStata += OnChangeGameStata;
    }

    private void OnDisable()
    {
        EventHandler.ChangeGameStata -= OnChangeGameStata;
    }

    private void OnChangeGameStata(GameStata gameStata)
    {
        _canTransition = gameStata == GameStata.Start;
    }

    public void TeleportScene(string from, string to)
    {
        if (!_isFade && _canTransition) StartCoroutine(Transition(from, to));
    }

    private IEnumerator Transition(string from, string to)
    {
        yield return Fade(1);
        if (from != string.Empty)
        {
            EventHandler.CallUnloadItem();
            yield return SceneManager.UnloadSceneAsync(from);
        }
        yield return SceneManager.LoadSceneAsync(to, LoadSceneMode.Additive);
        EventHandler.CallLoadItem();
        Scene curScene = SceneManager.GetSceneByName(to);
        SceneManager.SetActiveScene(curScene);

        yield return Fade(0);

    }

    private IEnumerator Fade(float targetAlpha)
    {
        _isFade = true;

        fadePanel.blocksRaycasts = true;

        float speed = Mathf.Abs(fadePanel.alpha - targetAlpha) / fadeDuration;

        while (!Mathf.Approximately(targetAlpha, fadePanel.alpha))
        {
            fadePanel.alpha = Mathf.MoveTowards(fadePanel.alpha, targetAlpha, speed * Time.deltaTime);
            yield return null;
        }

        fadePanel.blocksRaycasts = false;

        _isFade = false;
    }
    
}
