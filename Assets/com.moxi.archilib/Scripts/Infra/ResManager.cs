using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using AppArchi.Base;

namespace AppArchi.Infra
{
    /// <summary>
    /// ��Դ���ع�����
    /// </summary>
    public class ResManager : Singleton<ResManager>
    {
        /// <summary>
        /// ͬ��������Դ��������û�кܶ��֧����Դ�ļ��У�
        /// </summary>
        /// <typeparam name="T">��Դ����</typeparam>
        /// <param name="resName">��Դ����</param>
        /// <returns></returns>
        public T LoadRes<T>(string resName) where T : Object
        {
            T go = Resources.Load<T>(resName);
            if (go is GameObject)
            {
                return GameObject.Instantiate(go);
            }
            return go;
        }

        /// <summary>
        /// �첽������Ϸ����
        /// </summary>
        /// <typeparam name="T">��Դ����</typeparam>
        /// <param name="resName">��Դ����</param>
        /// <param name="callBack">�ص�����</param>
        public void LoadAsyn<T>(string resName, UnityAction<T> callBack) where T : Object
        {
            MonoManager._instance.StartCoroutine(LoadAsynRes<T>(resName, callBack));
        }

        //����Э��
        IEnumerator LoadAsynRes<T>(string resName, UnityAction<T> callBack) where T : Object
        {
            ResourceRequest go = Resources.LoadAsync<T>(typeof(T).ToString() + "/" + resName);
            yield return go;
            if (go.asset is GameObject)
            {
                callBack(GameObject.Instantiate(go.asset) as T);
            }
            else
            {
                callBack(go.asset as T);
            }

        }
    }
}
