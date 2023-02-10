using UnityEngine;
using UnityEngine.Events;
using System.Threading.Tasks;

namespace AppArchi.Infra
{
    public class ResManager
    {
        public T LoadRes<T>(string resName) where T : Object
        {
            T go = Resources.Load<T>(resName);
            if (go is GameObject)
            {
                return GameObject.Instantiate(go);
            }
            return go;
        }

        public async void LoadAsyn<T>(string resName, UnityAction<T> callBack) where T : Object
        {
            ResourceRequest go = Resources.LoadAsync<T>(typeof(T).ToString() + "/" + resName);

            while (!go.isDone)
            {
                await Task.Delay(100);
            }

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
