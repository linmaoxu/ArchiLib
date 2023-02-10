using UnityEngine.Events;

namespace AppArchi.Infra
{
    public class MonoManager
    {
        public UnityAction monoFunc;  

        public void AddUpdateFunc(UnityAction callBack)
        {
            monoFunc += callBack;
        }

        public void RemoveUpdateFunc(UnityAction callBack)
        {
            monoFunc -= callBack;
        }

        public void Clear()
        {
            monoFunc = null;
        }

        public void Tick()
        {
            if (monoFunc != null)
            {
                monoFunc.Invoke();
            }
        }
    }
}
