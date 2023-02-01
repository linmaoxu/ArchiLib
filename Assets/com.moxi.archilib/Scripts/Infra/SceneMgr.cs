using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using AppArchi.Base;

namespace AppArchi.Infra
{
    /// <summary>
    /// ����������
    /// </summary>
    public class SceneMgr : Singleton<SceneMgr>
    {
        /// <summary>
        /// ���س���
        /// </summary>
        /// <param name="sceneName">������</param>
        public void LoadScene(string sceneName)
        {
            AudioManager._instance.StopPlayAll();
            SceneManager.LoadScene(sceneName);
        }

        /// <summary>
        /// ���س���
        /// </summary>
        /// <param name="sceneIndex">�����±�</param>
        public void LoadScene(int sceneIndex)
        {
            AudioManager._instance.StopPlayAll();
            SceneManager.LoadScene(sceneIndex);
        }

        /// <summary>
        /// �첽���س���
        /// </summary>
        /// <param name="sceneName">������</param>
        /// <param name="callBack">�ص�����</param>
        public void LoadAsynScene(string sceneName, UnityAction callBack)
        {
            MonoManager._instance.StartCoroutine(sceneName, callBack);
        }

        IEnumerator LoadAsyn(string sceneName, UnityAction callBack)
        {
            AsyncOperation ao = SceneManager.LoadSceneAsync(sceneName);
            while (!ao.isDone)
            {
                yield return ao.progress;
            }
            if (callBack != null)
            {
                callBack();
            }
        }
    }
}