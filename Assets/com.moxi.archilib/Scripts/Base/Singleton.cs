using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace AppArchi.Base
{
    /// <summary>
    /// ���������Ϸ�����ϵĵ�������
    /// </summary>
    /// <typeparam name="T">��������</typeparam>
    public class Singleton<T> where T : new()
    {
        private static T instance;
        public static T _instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new T();
                }
                return instance;
            }
        }

    }

}
