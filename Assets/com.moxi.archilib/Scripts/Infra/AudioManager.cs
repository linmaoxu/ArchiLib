using UnityEngine;

namespace AppArchi.Infra
{
    public class AudioManager
    {
        public enum PlayType
        {
            Sound,
            BgMusic,
            All
        }
        GameObject parentGO;
        GameObject soundGO;
        AudioSource soundAS;
        GameObject bgGO;
        AudioSource bgAS;
        Coroutine waitForPlay;
        float volumn;

        public void Init()
        {
            if (parentGO == null)
            {
                parentGO = new GameObject(nameof(AudioManager));
            }

            if (soundGO == null)
            {
                soundGO = new GameObject("soundGO");
                soundGO.transform.SetParent(parentGO.transform);
                soundAS = soundGO.AddComponent<AudioSource>();
            }

            if (bgGO == null)
            {
                bgGO = new GameObject("bgGO");
                bgGO.transform.SetParent(parentGO.transform);
                bgAS = bgGO.AddComponent<AudioSource>();
                bgAS.loop = true;
            }
        }

        public void Play(AudioClip audioClip, PlayType playType)
        {
            switch (playType)
            {
                case PlayType.Sound:
                    soundAS.clip = audioClip;
                    soundAS.Play();
                    break;
                case PlayType.BgMusic:
                    bgAS.clip = audioClip;
                    bgAS.Play();
                    break;
                default:
                    break;
            }

        }

        public void Pause(PlayType playType)
        {
            switch (playType)
            {
                case PlayType.Sound:
                    soundAS.Pause();
                    break;
                case PlayType.BgMusic:
                    bgAS.Pause();
                    break;
                case PlayType.All:
                    soundAS.Pause();
                    bgAS.Pause();
                    break;
                default:
                    break;
            }
        }

        public void Stop(PlayType playType)
        {
            switch (playType)
            {
                case PlayType.Sound:
                    soundAS.Stop();
                    break;
                case PlayType.BgMusic:
                    bgAS.Stop();
                    break;
                case PlayType.All:
                    soundAS.Stop();
                    bgAS.Stop();
                    break;
                default:
                    break;
            }
        }

        public void SetVolume(float audioVolume, PlayType playType)
        {
            if (audioVolume>1)
            {
                volumn = 1;
            }
            else if (audioVolume <0)
            {
                volumn = 0;
            }

            switch (playType)
            {
                case PlayType.Sound:
                    soundAS.volume = volumn;
                    break;
                case PlayType.BgMusic:
                    bgAS.volume = volumn;
                    break;
                case PlayType.All:
                    soundAS.volume = volumn;
                    bgAS.volume = volumn;
                    break;
                default:
                    break;
            }
        }

    }
}



