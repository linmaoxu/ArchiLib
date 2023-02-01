using UnityEngine;

namespace AppArchi.Base
{
    /// <summary>
    /// �����������Ϸ�����ϵĵ�������
    /// �����ڹ���ģ��
    /// </summary>
    /// <typeparam name="T">����</typeparam>
    public class AutoSingletonMono<T> : MonoBehaviour where T : MonoBehaviour
    {
        private static T instance;
        public static T _instance
        {
            get
            {
                if (instance == null)
                {
                    GameObject go = new GameObject(typeof(T).ToString());
                    instance = go.AddComponent<T>();
                    DontDestroyOnLoad(go);
                }
                return instance;
            }
        }
    }

}
