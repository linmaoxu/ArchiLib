using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// 资源加载管理类
/// </summary>
public class ResManager : Singleton<ResManager>
{
    /// <summary>
    /// 同步加载资源（适用于没有很多分支的资源文件夹）
    /// </summary>
    /// <typeparam name="T">资源类型</typeparam>
    /// <param name="resName">资源名称</param>
    /// <returns></returns>
    public T LoadRes<T>(string resName) where T : Object
    {
        T go = Resources.Load<T>(resName);
        if (go is GameObject)
        {
            return GameObject.Instantiate(go);
        }
        return go;
    }

    /// <summary>
    /// 异步加载游戏物体
    /// </summary>
    /// <typeparam name="T">资源类型</typeparam>
    /// <param name="resName">资源名称</param>
    /// <param name="callBack">回调函数</param>
    public void LoadAsyn<T>(string resName, UnityAction<T>callBack)where T:Object
    {
        MonoManager._instance.StartCoroutine(LoadAsynRes<T>(resName,callBack));
    }

    //加载协程
    IEnumerator LoadAsynRes<T>(string resName, UnityAction<T>callBack) where T : Object
    {
        ResourceRequest go = Resources.LoadAsync<T>(typeof(T).ToString() + "/" + resName);
        yield return go;
        if (go.asset is GameObject)
        {
            callBack(GameObject.Instantiate(go.asset) as T);
        }
        else
        {
            callBack(go.asset as T);
        }

    }
}
