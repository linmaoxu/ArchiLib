using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : AutoSingletonMono<AudioManager>
{
    GameObject soundGO; //音效挂载的游戏物体（播放音效）
    AudioSource soundAS;    //音效资源
    GameObject bgGO;    //背景音效挂载的游戏物体(播放背景音乐)
    AudioSource bgAS;    //音效资源
    Coroutine waitForPlay;  //等待播放协程
    public void Awake()
    {
        Initial();
    }

   /// <summary>
   /// 初始化音乐游戏物体及音乐组件
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
    /// 播放音效
    /// </summary>
    /// <param name="audioName">音效名字</param>
    public void PlaySound(string audioName)
    {
        //音效游戏物体判断
        if (soundGO == null)
        {
            Initial();
        }
        soundAS.clip = ResManager._instance.LoadRes<AudioClip>(audioName);
        soundAS.Play();
    }

    /// <summary>
    /// 播放音效(打断播放/等待播放)
    /// </summary>
    /// <param name="audioName">音效名字</param>
    /// <param name="isWait">是否打断/等待</param>
    public void PlaySound(string audioName, bool isWait)
    {
        //音效游戏物体判断
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
    /// 播放背景音乐
    /// </summary>
    /// <param name="bgName">背景音乐名</param>
    public void PlayBG(string bgName)
    {
        //音效游戏物体判断
        if (bgGO == null)
        {
            Initial();
        }
        bgAS.clip = ResManager._instance.LoadRes<AudioClip>(bgName);
        bgAS.Play();
    }

    /// <summary>
    /// 播放背景音乐
    /// </summary>
    /// <param name="bgName">背景音乐名</param>
    public void PlayBG(string bgName,float volume)
    {
        //音效游戏物体判断
        if (bgGO == null)
        {
            Initial();
        }
        bgAS.clip = ResManager._instance.LoadRes<AudioClip>(bgName);
        bgAS.volume = volume;
        bgAS.Play();
    }


    /// <summary>
    /// 音效是否正在播放
    /// </summary>
    /// <returns></returns>
    public bool IsSoundPlaying()
    {
        if (soundAS==null)
        {
            Initial();
        }
        return isPlayOver(soundAS);
    }

    /// <summary>
    /// 背景是否在播放
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
    /// 停止播放背景音乐和音效
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

    //停止播放音效
    public void StopPlaySound()
    {
        if (soundAS != null)
        {
            soundAS.Stop();
        }
    }

    //停止播放背景音乐
    public void StopPlayBg()
    {
        if (bgAS != null)
        {
            bgAS.Stop();
        }
    }

    IEnumerator WaitForPlaying(AudioSource aS, AudioClip ac)
    {
        yield return new WaitUntil(()=> isPlayOver(aS));
        aS.clip = ac;
        aS.Play();
    }

    //音效组件是否播放完
    bool isPlayOver(AudioSource aS)
    {
        return !aS.isPlaying;
    }


}
