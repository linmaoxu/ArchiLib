using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 挂载在游戏物体上的单例基类
/// </summary>
/// <typeparam name="T">数据类型</typeparam>
public class SingletonMono<T>: MonoBehaviour where T:MonoBehaviour
{
    private static T instance;
    public static T _instance
    {
        get 
        {
            return instance;
        }
    }

    public virtual void Awake()
    {
        instance = this as T;
    }
}
