using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    [SceneName]public string sceneFrom;
    [SceneName]public string sceneTo;
    /// <summary>
    /// 根据起始位置做转移
    /// </summary>
    public void TeleportScene()
    {
        TeleportManager.Instance.TeleportScene(sceneFrom, sceneTo);
    }
}
