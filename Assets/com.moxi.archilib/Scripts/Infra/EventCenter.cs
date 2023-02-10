using System;
using System.Collections.Generic;

namespace AppArchi.Infra
{
    public class EventCenter
    {
        public Dictionary<string, Delegate> eventDic;

        public delegate void eventFunc();
        public delegate void eventFunc<T>(T value);
        public delegate void eventFunc<T1, T2>(T1 value1, T2 value2);
        public delegate void eventFunc<T1, T2, T3>(T1 value1, T2 value2, T3 value3);

        public void Init()
        {
            eventDic = new Dictionary<string, Delegate>();
        }

        #region Add

        private bool CheckAdd(string eventName, Delegate callBack)
        {
            if (!eventDic.ContainsKey(eventName))
            {
                eventDic.Add(eventName, null);
                return true;
            }

            if (eventDic[eventName] == null)
            {
                return true;
            }
            return callBack.GetType() == eventDic[eventName].GetType();
        }

        public void AddEvent(string eventName, eventFunc callBack)
        {
            if (CheckAdd(eventName, callBack))
            {
                eventDic[eventName] = eventDic[eventName] as eventFunc + callBack;
            }
            else
            {
                throw new Exception(string.Format("Warning:Add Event Failed!The Event Type Of {0} is different from {1}.", eventName, callBack.ToString()));
            }
        }

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

        public void AddEvent<T1, T2>(string eventName, eventFunc<T1, T2> callBack)
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

        public void AddEvent<T1, T2, T3>(string eventName, eventFunc<T1, T2, T3> callBack)
        {
            if (CheckAdd(eventName, callBack))
            {
                eventDic[eventName] = eventDic[eventName] as eventFunc<T1, T2, T3> + callBack;
            }
            else
            {
                throw new Exception(string.Format("Warning:Add Event Failed!The Event Type Of {0} is different from {1}.", eventName, callBack.ToString()));
            }
        }

        #endregion

        #region Remove

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
        public void RemoveEvent<T>(string eventName, eventFunc<T> callBack)
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

        public void RemoveEvent<T1, T2>(string eventName, eventFunc<T1, T2> callBack)
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

        public void RemoveEvent<T1, T2, T3>(string eventName, eventFunc<T1, T2, T3> callBack)
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

        #region Trigger

        public void EventTrigger(string eventName)
        {

            if (eventDic.ContainsKey(eventName))
            {
                if (eventDic[eventName] is eventFunc)
                {
                    (eventDic[eventName] as eventFunc).Invoke();
                }

                else if (eventDic[eventName] == null)
                {
                    return;
                }

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

        public void EventTrigger<T>(string eventName, T param)
        {

            if (eventDic.ContainsKey(eventName))
            {
                if (eventDic[eventName] is eventFunc<T>)
                {
                    (eventDic[eventName] as eventFunc<T>).Invoke(param);
                }
                else if (eventDic[eventName] == null)
                {
                    return;
                }
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

        public void EventTrigger<T1, T2>(string eventName, T1 param1, T2 param2)
        {
            if (eventDic.ContainsKey(eventName))
            {
                if (eventDic[eventName] is eventFunc<T1, T2>)
                {
                    (eventDic[eventName] as eventFunc<T1, T2>).Invoke(param1, param2);
                }
                else if (eventDic[eventName] == null)
                {
                    return;
                }
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

        public void EventTrigger<T1, T2, T3>(string eventName, T1 param1, T2 param2, T3 param3)
        {
            if (eventDic.ContainsKey(eventName))
            {
                if (eventDic[eventName] is eventFunc<T1, T2, T3>)
                {
                    (eventDic[eventName] as eventFunc<T1, T2, T3>).Invoke(param1, param2, param3);
                }
                else if (eventDic[eventName] == null)
                {
                    return;
                }
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

        public void Clear()
        {
            eventDic = null;
        }
    }
}