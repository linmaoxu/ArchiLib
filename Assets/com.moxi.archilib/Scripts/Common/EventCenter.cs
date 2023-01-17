using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 事件中心模块
/// </summary>
public class EventCenter: AutoSingletonMono<EventCenter>
{
    //时间字典
    public Dictionary<string, Delegate> eventDic = new Dictionary<string, Delegate>();

    //事件类型
    public delegate void eventFunc();
    public delegate void eventFunc<T>(T value);
    public delegate void eventFunc<T1,T2>(T1 value1, T2 value2);
    public delegate void eventFunc<T1,T2,T3>(T1 value1, T2 value2, T3 value3);

    #region 事件添加

    /// <summary>
    /// 事件添加检测
    /// </summary>
    /// <param name="eventName">事件名</param>
    /// <param name="callBack">回调函数</param>
    /// <returns></returns>
    private bool CheckAdd(string eventName,Delegate callBack)
    {
        //字典不存在时，添加事件
        if (!eventDic.ContainsKey(eventName))
        {
            eventDic.Add(eventName, null);
            return true;
        }

        //存在字典时，进行事件类型判断(空事件直接添加)
        if (eventDic[eventName]==null)
        {
            return true;
        }
        return callBack.GetType() == eventDic[eventName].GetType();
    }

    /// <summary>
    /// 添加事件(无参数)
    /// </summary>
    /// <param name="eventName">事件名字</param>
    /// <param name="callBack">回调函数</param>
    public void AddEvent(string eventName, eventFunc callBack)
    {
        if (CheckAdd(eventName,callBack))
        {
            eventDic[eventName] = eventDic[eventName] as eventFunc + callBack;
        }
        else
        {
            throw new Exception(string.Format("Warning:Add Event Failed!The Event Type Of {0} is different from {1}.", eventName, callBack.ToString()));
        }
    }

    /// <summary>
    /// 添加事件(1个参数)
    /// </summary>
    /// <typeparam name="T">参数类型</typeparam>
    /// <param name="eventName">事件名</param>
    /// <param name="callBack">回调函数</param>
    public void AddEvent<T>(string eventName, eventFunc<T> callBack)
    {
        if (CheckAdd(eventName, callBack))
        {
            eventDic[eventName] = eventDic[eventName] as eventFunc<T> + callBack;
        }
        else
        {
            throw new Exception(string.Format("Warning:Add Event Failed!The Event Type Of {0} is different from {1}.", eventName, callBack.ToString()));
        }
    }

    /// <summary>
    /// 添加事件(2个参数)
    /// </summary>
    /// <typeparam name="T1">参数1类型</typeparam>
    /// <typeparam name="T2">参数2类型</typeparam>
    /// <param name="eventName">事件名</param>
    /// <param name="callBack">回调函数</param>
    public void AddEvent<T1,T2>(string eventName, eventFunc<T1,T2> callBack)
    {
        if (CheckAdd(eventName, callBack))
        {
            eventDic[eventName] = eventDic[eventName] as eventFunc<T1, T2> + callBack;
        }
        else
        {
            throw new Exception(string.Format("Warning:Add Event Failed!The Event Type Of {0} is different from {1}.", eventName, callBack.ToString()));
        }
    }

    /// <summary>
    /// 添加事件(3个参数)
    /// </summary>
    /// <typeparam name="T1">参数1类型</typeparam>
    /// <typeparam name="T2">参数2类型</typeparam>
    /// <typeparam name="T3">参数3类型</typeparam>
    /// <param name="eventName">事件名</param>
    /// <param name="callBack">回调函数</param>
    public void AddEvent<T1, T2,T3>(string eventName, eventFunc<T1, T2,T3> callBack)
    {
        if (CheckAdd(eventName, callBack))
        {
            eventDic[eventName] = eventDic[eventName] as eventFunc<T1, T2,T3> + callBack;
        }
        else
        {
            throw new Exception(string.Format("Warning:Add Event Failed!The Event Type Of {0} is different from {1}.", eventName, callBack.ToString()));
        }
    }

    #endregion

    #region 事件移除

    /// <summary>
    /// 事件移除(无参数)
    /// </summary>
    /// <param name="eventName">事件名</param>
    /// <param name="callBack">回调函数</param>
    public void RemoveEvent(string eventName, eventFunc callBack)
    {
        if (!eventDic.ContainsKey(eventName)) return;


        if (callBack.GetType() == eventDic[eventName].GetType())
        {
            eventDic[eventName] = eventDic[eventName] as eventFunc - callBack;
        }
        else
        {
            throw new Exception(String.Format("Warning:Remove Event Failed!The Event Type of {0} is different from {1}", eventDic[eventName].GetType(), callBack.GetType()));
        }
    }

    /// <summary>
    /// 事件移除(1个参数)
    /// </summary>
    /// <typeparam name="T">参数类型</typeparam>
    /// <param name="eventName">事件名</param>
    /// <param name="callBack">回调函数</param>
    public void RemoveEvent<T>(string eventName, eventFunc<T>callBack)
    {
        if (!eventDic.ContainsKey(eventName)) return;

        if (callBack.GetType() == eventDic[eventName].GetType())
        {
            eventDic[eventName] = eventDic[eventName] as eventFunc<T> - callBack;
        }
        else
        {
            throw new Exception(String.Format("Warning:Remove Event Failed!The Event Type of {0} is different from {1}", eventDic[eventName].GetType(), callBack.GetType()));
        }
    }

    /// <summary>
    /// 事件移除(2个参数)
    /// </summary>
    /// <typeparam name="T1">参数1类型</typeparam>
    /// <typeparam name="T2">参数2类型</typeparam>
    /// <param name="eventName">事件名</param>
    /// <param name="callBack">回调函数</param>
    public void RemoveEvent<T1,T2>(string eventName, eventFunc<T1, T2> callBack)
    {
        if (!eventDic.ContainsKey(eventName)) return;

        if (callBack.GetType() == eventDic[eventName].GetType())
        {
            eventDic[eventName] = eventDic[eventName] as eventFunc<T1, T2> - callBack;
        }
        else
        {
            throw new Exception(String.Format("Warning:Remove Event Failed!The Event Type of {0} is different from {1}", eventDic[eventName].GetType(), callBack.GetType()));
        }
    }

    /// <summary>
    /// 事件移除(3个参数)
    /// </summary>
    /// <typeparam name="T1">参数1类型</typeparam>
    /// <typeparam name="T2">参数2类型</typeparam>
    /// <typeparam name="T3">参数3类型</typeparam>
    /// <param name="eventName">事件名</param>
    /// <param name="callBack">回调函数</param>
    public void RemoveEvent<T1, T2,T3>(string eventName, eventFunc<T1, T2, T3> callBack)
    {
        if (!eventDic.ContainsKey(eventName)) return;

        if (callBack.GetType() == eventDic[eventName].GetType())
        {
            eventDic[eventName] = eventDic[eventName] as eventFunc<T1, T2, T3> - callBack;
        }
        else
        {
            throw new Exception(String.Format("Warning:Remove Event Failed!The Event Type of {0} is different from {1}", eventDic[eventName].GetType(), callBack.GetType()));
        }
    }

    #endregion

    #region 事件触发


    /// <summary>
    /// 事件触发(无参数)
    /// </summary>
    /// <param name="eventName">事件名</param>
    public void EventTrigger(string eventName)
    {

        //判断事件类型
        if (eventDic.ContainsKey(eventName))
        {
            if (eventDic[eventName] is eventFunc)
            {
                (eventDic[eventName] as eventFunc).Invoke();
            }
            //事件注册了，但是没有具体实例
            else if (eventDic[eventName]==null)
            {
                return;
            }
            //类型不一致
            else
            {
                throw new Exception(string.Format("Warning:Failed to execute the event!Event:{0} parameter pass error ", eventName));
            }

        }
        else
        {
            throw new Exception(string.Format("Warning:Failed to execute the event!Event:{0} does not exist", eventName));
        }
    }

    /// <summary>
    /// 事件触发(1个参数)
    /// </summary>
    /// <typeparam name="T">参数类型</typeparam>
    /// <param name="eventName">事件名</param>
    /// <param name="param">参数</param>
    public void EventTrigger<T>(string eventName, T param)
    {
        //判断事件类型
        if (eventDic.ContainsKey(eventName))
        {
            if (eventDic[eventName] is eventFunc<T>)
            {
                (eventDic[eventName] as eventFunc<T>).Invoke(param);
            }
            //事件注册了，但是没有具体实例
            else if (eventDic[eventName] == null)
            {
                return;
            }
            //类型不一致
            else
            {
                throw new Exception(string.Format("Warning:Failed to execute the event!Event:{0} parameter pass error ", eventName));
            }

        }
        else
        {
            throw new Exception(string.Format("Warning:Failed to execute the event!Event:{0} does not exist", eventName)) ;
        }
    }

    /// <summary>
    /// 事件触发(2个参数)
    /// </summary>
    /// <typeparam name="T1">参数1类型</typeparam>
    /// <typeparam name="T2">参数2类型</typeparam>
    /// <param name="eventName">事件名</param>
    /// <param name="param1">参数1</param>
    /// <param name="param2">参数2</param>
    public void EventTrigger<T1,T2>(string eventName, T1 param1,T2 param2)
    {
        //判断事件类型
        if (eventDic.ContainsKey(eventName))
        {
            if (eventDic[eventName] is eventFunc<T1, T2>)
            {
                (eventDic[eventName] as eventFunc<T1, T2>).Invoke(param1,param2);
            }
            //事件注册了，但是没有具体实例
            else if (eventDic[eventName] == null)
            {
                return;
            }
            //类型不一致
            else
            {
                throw new Exception(string.Format("Warning:Failed to execute the event!Event:{0} parameter pass error ", eventName));
            }

        }
        else
        {
            throw new Exception(string.Format("Warning:Failed to execute the event!Event:{0} does not exist", eventName));
        }
    }

    /// <summary>
    /// 事件触发(3个参数)
    /// </summary>
    /// <typeparam name="T1">参数1类型</typeparam>
    /// <typeparam name="T2">参数2类型</typeparam>
    /// <typeparam name="T3">参数3类型</typeparam>
    /// <param name="eventName">事件名</param>
    /// <param name="param1">参数1</param>
    /// <param name="param2">参数2</param>
    /// <param name="param3">参数3</param>
    public void EventTrigger<T1, T2,T3>(string eventName, T1 param1, T2 param2, T3 param3)
    {
        //判断事件类型
        if (eventDic.ContainsKey(eventName))
        {
            if (eventDic[eventName] is eventFunc<T1, T2, T3>)
            {
                (eventDic[eventName] as eventFunc<T1, T2, T3>).Invoke(param1, param2, param3);
            }
            //事件注册了，但是没有具体实例
            else if (eventDic[eventName] == null)
            {
                return;
            }
            //类型不一致
            else
            {
                throw new Exception(string.Format("Warning:Failed to execute the event!Event:{0} parameter pass error ", eventName));
            }

        }
        else
        {
            throw new Exception(string.Format("Warning:Failed to execute the event!Event:{0} does not exist", eventName));
        }
    }

    #endregion


    //字典清空
    public void Clear()
    {
        eventDic = null;
    }
}
