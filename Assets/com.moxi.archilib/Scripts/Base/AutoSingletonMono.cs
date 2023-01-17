using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 无需挂载在游戏物体上的单例基类
/// 适用于管理模块
/// </summary>
/// <typeparam name="T">类型</typeparam>
public class AutoSingletonMono<T> : MonoBehaviour where T:MonoBehaviour
{
    private static T instance;
    public static T _instance
    {
        get
        {
            if (instance==null)
            {
                GameObject go = new GameObject(typeof(T).ToString());
                instance = go.AddComponent<T>();
                DontDestroyOnLoad(go);
            }
            return instance;
        }
    }
}
