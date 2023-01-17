using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 无需挂在游戏物体上的单例基类
/// </summary>
/// <typeparam name="T">数据类型</typeparam>
public class Singleton<T> where T:new ()
{
    private static T instance;
    public static T _instance
    {
        get
        {
            if (instance==null)
            {
                instance = new T();
            }
            return instance;
        }
    }

}
