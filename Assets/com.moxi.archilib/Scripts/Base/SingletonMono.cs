using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace AppArchi.Base
{
    /// <summary>
    /// ��������Ϸ�����ϵĵ�������
    /// </summary>
    /// <typeparam name="T">��������</typeparam>
    public class SingletonMono<T> : MonoBehaviour where T : MonoBehaviour
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

}
