using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

/// <summary>
/// 场景管理器
/// </summary>
public class SceneMgr : Singleton<SceneMgr>
{
    /// <summary>
    /// 加载场景
    /// </summary>
    /// <param name="sceneName">场景名</param>
    public void LoadScene(string sceneName)
    {
        AudioManager._instance.StopPlayAll();
        SceneManager.LoadScene(sceneName);
    }

    /// <summary>
    /// 加载场景
    /// </summary>
    /// <param name="sceneIndex">场景下标</param>
    public void LoadScene(int sceneIndex)
    {
        AudioManager._instance.StopPlayAll();
        SceneManager.LoadScene(sceneIndex);
    }

    /// <summary>
    /// 异步加载场景
    /// </summary>
    /// <param name="sceneName">场景名</param>
    /// <param name="callBack">回调函数</param>
    public void LoadAsynScene(string sceneName, UnityAction callBack)
    {
        MonoManager._instance.StartCoroutine(sceneName, callBack);
    }

    IEnumerator LoadAsyn(string sceneName, UnityAction callBack)
    {
        AsyncOperation ao = SceneManager.LoadSceneAsync(sceneName);
        while (!ao.isDone)
        {
             yield return ao.progress;
        }
        if (callBack!=null)
        {
            callBack();
        }
    }
}
