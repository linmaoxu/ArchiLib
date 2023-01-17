using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// 公共mono管理模块
/// </summary>
public class MonoManager: AutoSingletonMono<MonoManager>
{
    public UnityAction monoFunc;    //mono帧事件

    //增加帧事件
    public void AddUpdateFunc(UnityAction callBack)
    {
        monoFunc += callBack;
    }

    //移除帧事件
    public void RemoveUpdateFunc(UnityAction callBack)
    {
        monoFunc -= callBack;
    }

    //清空帧事件
    public void Clear()
    {
        monoFunc = null;
    }

    private void Update()
    {
        if (monoFunc!=null)
        {
            monoFunc.Invoke();
        }
    }
}
