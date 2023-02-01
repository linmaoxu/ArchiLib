using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AppArchi.Base;

namespace AppArchi.Infra
{
    public class AudioManager : AutoSingletonMono<AudioManager>
    {
        GameObject soundGO; //��Ч���ص���Ϸ���壨������Ч��
        AudioSource soundAS;    //��Ч��Դ
        GameObject bgGO;    //������Ч���ص���Ϸ����(���ű�������)
        AudioSource bgAS;    //��Ч��Դ
        Coroutine waitForPlay;  //�ȴ�����Э��
        public void Awake()
        {
            Initial();
        }

        /// <summary>
        /// ��ʼ��������Ϸ���弰�������
        /// </summary>
        public void Initial()
        {
            if (soundGO == null)
            {
                soundGO = new GameObject("soundGO");
                soundGO.transform.SetParent(this.transform);
                soundAS = soundGO.AddComponent<AudioSource>();
            }

            if (bgGO == null)
            {
                bgGO = new GameObject("bgGO");
                bgGO.transform.SetParent(this.transform);
                bgAS = bgGO.AddComponent<AudioSource>();
                bgAS.loop = true;
            }
        }

        /// <summary>
        /// ������Ч
        /// </summary>
        /// <param name="audioName">��Ч����</param>
        public void PlaySound(string audioName)
        {
            //��Ч��Ϸ�����ж�
            if (soundGO == null)
            {
                Initial();
            }
            soundAS.clip = ResManager._instance.LoadRes<AudioClip>(audioName);
            soundAS.Play();
        }

        /// <summary>
        /// ������Ч(��ϲ���/�ȴ�����)
        /// </summary>
        /// <param name="audioName">��Ч����</param>
        /// <param name="isWait">�Ƿ���/�ȴ�</param>
        public void PlaySound(string audioName, bool isWait)
        {
            //��Ч��Ϸ�����ж�
            if (soundGO == null)
            {
                Initial();
            }
            AudioClip ac = ResManager._instance.LoadRes<AudioClip>(audioName);
            if (isWait)
            {
                waitForPlay = MonoManager._instance.StartCoroutine(WaitForPlaying(soundAS, ac));
            }
            else
            {
                soundAS.Stop();
                soundAS.clip = ac;
                soundAS.Play();
            }
        }

        /// <summary>
        /// ���ű�������
        /// </summary>
        /// <param name="bgName">����������</param>
        public void PlayBG(string bgName)
        {
            //��Ч��Ϸ�����ж�
            if (bgGO == null)
            {
                Initial();
            }
            bgAS.clip = ResManager._instance.LoadRes<AudioClip>(bgName);
            bgAS.Play();
        }

        /// <summary>
        /// ���ű�������
        /// </summary>
        /// <param name="bgName">����������</param>
        public void PlayBG(string bgName, float volume)
        {
            //��Ч��Ϸ�����ж�
            if (bgGO == null)
            {
                Initial();
            }
            bgAS.clip = ResManager._instance.LoadRes<AudioClip>(bgName);
            bgAS.volume = volume;
            bgAS.Play();
        }


        /// <summary>
        /// ��Ч�Ƿ����ڲ���
        /// </summary>
        /// <returns></returns>
        public bool IsSoundPlaying()
        {
            if (soundAS == null)
            {
                Initial();
            }
            return isPlayOver(soundAS);
        }

        /// <summary>
        /// �����Ƿ��ڲ���
        /// </summary>
        /// <returns></returns>
        public bool IsBgPlaying()
        {
            if (bgAS == null)
            {
                Initial();
            }
            return isPlayOver(bgAS);
        }

        /// <summary>
        /// ֹͣ���ű������ֺ���Ч
        /// </summary>
        public void StopPlayAll()
        {
            if (soundAS == null)
            {
                Initial();
            }
            if (bgAS == null)
            {
                Initial();
            }
            soundAS.Stop();
            bgAS.Stop();
        }

        //ֹͣ������Ч
        public void StopPlaySound()
        {
            if (soundAS != null)
            {
                soundAS.Stop();
            }
        }

        //ֹͣ���ű�������
        public void StopPlayBg()
        {
            if (bgAS != null)
            {
                bgAS.Stop();
            }
        }

        IEnumerator WaitForPlaying(AudioSource aS, AudioClip ac)
        {
            yield return new WaitUntil(() => isPlayOver(aS));
            aS.clip = ac;
            aS.Play();
        }

        //��Ч����Ƿ񲥷���
        bool isPlayOver(AudioSource aS)
        {
            return !aS.isPlaying;
        }
    }
}



