using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using System.Threading.Tasks;


namespace AppArchi.Infra
{

    public class SceneMgr:MonoBehaviour
    {
        public void LoadScene(string sceneName)
        {
            SceneManager.LoadScene(sceneName);
        }


        public void LoadScene(int sceneIndex)
        {
            SceneManager.LoadScene(sceneIndex);
        }


        public async void LoadAsynScene(string sceneName, UnityAction callBack)
        {
            AsyncOperation ao = SceneManager.LoadSceneAsync(sceneName);
            while (!ao.isDone)
            {
                await Task.Delay(100);
            }
            if (callBack != null)
            {
                callBack();
            }
        }


    }
}