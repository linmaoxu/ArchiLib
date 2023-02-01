using System;
using System.Collections.Generic;
using AppArchi.Base;

namespace AppArchi.Infra
{
    /// <summary>
    /// �¼�����ģ��
    /// </summary>
    public class EventCenter : AutoSingletonMono<EventCenter>
    {
        //ʱ���ֵ�
        public Dictionary<string, Delegate> eventDic = new Dictionary<string, Delegate>();

        //�¼�����
        public delegate void eventFunc();
        public delegate void eventFunc<T>(T value);
        public delegate void eventFunc<T1, T2>(T1 value1, T2 value2);
        public delegate void eventFunc<T1, T2, T3>(T1 value1, T2 value2, T3 value3);

        #region �¼�����

        /// <summary>
        /// �¼����Ӽ��
        /// </summary>
        /// <param name="eventName">�¼���</param>
        /// <param name="callBack">�ص�����</param>
        /// <returns></returns>
        private bool CheckAdd(string eventName, Delegate callBack)
        {
            //�ֵ䲻����ʱ�������¼�
            if (!eventDic.ContainsKey(eventName))
            {
                eventDic.Add(eventName, null);
                return true;
            }

            //�����ֵ�ʱ�������¼������ж�(���¼�ֱ������)
            if (eventDic[eventName] == null)
            {
                return true;
            }
            return callBack.GetType() == eventDic[eventName].GetType();
        }

        /// <summary>
        /// �����¼�(�޲���)
        /// </summary>
        /// <param name="eventName">�¼�����</param>
        /// <param name="callBack">�ص�����</param>
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

        /// <summary>
        /// �����¼�(1������)
        /// </summary>
        /// <typeparam name="T">��������</typeparam>
        /// <param name="eventName">�¼���</param>
        /// <param name="callBack">�ص�����</param>
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
        /// �����¼�(2������)
        /// </summary>
        /// <typeparam name="T1">����1����</typeparam>
        /// <typeparam name="T2">����2����</typeparam>
        /// <param name="eventName">�¼���</param>
        /// <param name="callBack">�ص�����</param>
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

        /// <summary>
        /// �����¼�(3������)
        /// </summary>
        /// <typeparam name="T1">����1����</typeparam>
        /// <typeparam name="T2">����2����</typeparam>
        /// <typeparam name="T3">����3����</typeparam>
        /// <param name="eventName">�¼���</param>
        /// <param name="callBack">�ص�����</param>
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

        #region �¼��Ƴ�

        /// <summary>
        /// �¼��Ƴ�(�޲���)
        /// </summary>
        /// <param name="eventName">�¼���</param>
        /// <param name="callBack">�ص�����</param>
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
        /// �¼��Ƴ�(1������)
        /// </summary>
        /// <typeparam name="T">��������</typeparam>
        /// <param name="eventName">�¼���</param>
        /// <param name="callBack">�ص�����</param>
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

        /// <summary>
        /// �¼��Ƴ�(2������)
        /// </summary>
        /// <typeparam name="T1">����1����</typeparam>
        /// <typeparam name="T2">����2����</typeparam>
        /// <param name="eventName">�¼���</param>
        /// <param name="callBack">�ص�����</param>
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

        /// <summary>
        /// �¼��Ƴ�(3������)
        /// </summary>
        /// <typeparam name="T1">����1����</typeparam>
        /// <typeparam name="T2">����2����</typeparam>
        /// <typeparam name="T3">����3����</typeparam>
        /// <param name="eventName">�¼���</param>
        /// <param name="callBack">�ص�����</param>
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

        #region �¼�����


        /// <summary>
        /// �¼�����(�޲���)
        /// </summary>
        /// <param name="eventName">�¼���</param>
        public void EventTrigger(string eventName)
        {

            //�ж��¼�����
            if (eventDic.ContainsKey(eventName))
            {
                if (eventDic[eventName] is eventFunc)
                {
                    (eventDic[eventName] as eventFunc).Invoke();
                }
                //�¼�ע���ˣ�����û�о���ʵ��
                else if (eventDic[eventName] == null)
                {
                    return;
                }
                //���Ͳ�һ��
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
        /// �¼�����(1������)
        /// </summary>
        /// <typeparam name="T">��������</typeparam>
        /// <param name="eventName">�¼���</param>
        /// <param name="param">����</param>
        public void EventTrigger<T>(string eventName, T param)
        {
            //�ж��¼�����
            if (eventDic.ContainsKey(eventName))
            {
                if (eventDic[eventName] is eventFunc<T>)
                {
                    (eventDic[eventName] as eventFunc<T>).Invoke(param);
                }
                //�¼�ע���ˣ�����û�о���ʵ��
                else if (eventDic[eventName] == null)
                {
                    return;
                }
                //���Ͳ�һ��
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
        /// �¼�����(2������)
        /// </summary>
        /// <typeparam name="T1">����1����</typeparam>
        /// <typeparam name="T2">����2����</typeparam>
        /// <param name="eventName">�¼���</param>
        /// <param name="param1">����1</param>
        /// <param name="param2">����2</param>
        public void EventTrigger<T1, T2>(string eventName, T1 param1, T2 param2)
        {
            //�ж��¼�����
            if (eventDic.ContainsKey(eventName))
            {
                if (eventDic[eventName] is eventFunc<T1, T2>)
                {
                    (eventDic[eventName] as eventFunc<T1, T2>).Invoke(param1, param2);
                }
                //�¼�ע���ˣ�����û�о���ʵ��
                else if (eventDic[eventName] == null)
                {
                    return;
                }
                //���Ͳ�һ��
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
        /// �¼�����(3������)
        /// </summary>
        /// <typeparam name="T1">����1����</typeparam>
        /// <typeparam name="T2">����2����</typeparam>
        /// <typeparam name="T3">����3����</typeparam>
        /// <param name="eventName">�¼���</param>
        /// <param name="param1">����1</param>
        /// <param name="param2">����2</param>
        /// <param name="param3">����3</param>
        public void EventTrigger<T1, T2, T3>(string eventName, T1 param1, T2 param2, T3 param3)
        {
            //�ж��¼�����
            if (eventDic.ContainsKey(eventName))
            {
                if (eventDic[eventName] is eventFunc<T1, T2, T3>)
                {
                    (eventDic[eventName] as eventFunc<T1, T2, T3>).Invoke(param1, param2, param3);
                }
                //�¼�ע���ˣ�����û�о���ʵ��
                else if (eventDic[eventName] == null)
                {
                    return;
                }
                //���Ͳ�һ��
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


        //�ֵ����
        public void Clear()
        {
            eventDic = null;
        }
    }
}