using UnityEngine.Events;
using AppArchi.Base;

namespace AppArchi.Infra
{
    /// <summary>
    /// ����mono����ģ��
    /// </summary>
    public class MonoManager : AutoSingletonMono<MonoManager>
    {
        public UnityAction monoFunc;    //mono֡�¼�

        //����֡�¼�
        public void AddUpdateFunc(UnityAction callBack)
        {
            monoFunc += callBack;
        }

        //�Ƴ�֡�¼�
        public void RemoveUpdateFunc(UnityAction callBack)
        {
            monoFunc -= callBack;
        }

        //���֡�¼�
        public void Clear()
        {
            monoFunc = null;
        }

        private void Update()
        {
            if (monoFunc != null)
            {
                monoFunc.Invoke();
            }
        }
    }
}
