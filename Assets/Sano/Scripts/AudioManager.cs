using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public static class AudioName
{
    /// <summary>
    ///  [0]：TitleBGM2　[1]：SelectBGM　[2]：BattleBGM
    /// </summary>
    public static string[] BGMName = new string[]{"TitleBGM2", "SelectBGM", "BattleBGM"};

    /// <summary>
    ///  [0]：Accept　[1]：MenuSelect
    /// </summary>
    public static string[] SEName = new string[] { "Accept", "MenuSelect" };
}

public class AudioManager : SingletonMonoBehaviour<AudioManager> {

    /***** ボリューム保存キーとデフォルト音量 *****/
    const string BGM_VOLUME_KEY = "BGM_VOLUME";
    const string SE_VOLUME_KEY  = "SE_VOLUME";
    const float BGM_VOLUME_DEF = 1.0f;
    const float SE_VOLUME_DEF  = 1.0f;

    /***** 次に流すファイル名 *****/
    string nextBGMName;
    string nextSEName;

    /***** BGMとSEに分けてソースを保存 *****/
    public AudioSource BGMSorces, SESorces;
    Dictionary<string, AudioClip> bgmDic, seDic;

    void Awake()
    {
        if (this != Instance)
        {
            Destroy(this);
            return;
        }

        DontDestroyOnLoad(this.gameObject); // シーン間保持

        if(!GetComponent<AudioListener>())
        {
            gameObject.AddComponent<AudioListener>();
        }

        /***** ResourcesフォルダからBGMとSEを読込、ディクショナリにセット *****/
        bgmDic = new Dictionary<string, AudioClip>();
        seDic = new Dictionary<string, AudioClip>();

        object[] bgmList = Resources.LoadAll("BGM");
        object[] seList = Resources.LoadAll("SE");
        foreach (AudioClip bgm in bgmList)
        {
            bgmDic[bgm.name] = bgm;
        }
        foreach(AudioClip se in seList)
        {
            seDic[se.name] = se;
        }
    }

    void Start()
    {
        BGMSorces.volume = PlayerPrefs.GetFloat(BGM_VOLUME_KEY, BGM_VOLUME_DEF);
        SESorces.volume = PlayerPrefs.GetFloat(SE_VOLUME_KEY, SE_VOLUME_DEF);
    }


    /*===== BGM =====*/

    /// <summary>
    ///  指定したBGMを流す
    /// </summary>
    /// <param name="_bgmName">再生するBGM名</param>
    public void PlayBGM(string _bgmName)
    {
        if(!bgmDic.ContainsKey(_bgmName))
        {
            Debug.Log("指定したBGMは存在ない");
            return;
        }

        // 現在BGMが流れていなければ、そのまま流す
	    if (!BGMSorces.isPlaying) {
			nextBGMName = "";
			BGMSorces.clip = bgmDic [_bgmName] as AudioClip;
			BGMSorces.Play ();
            }

        // 既に違うBGMが流れている場合、停止させてから流す
        // 同じBGMが流れている場合は無視
        else if(BGMSorces.clip.name != _bgmName)
        {
            BGMSorces.Stop();
            nextBGMName = _bgmName;
            PlayBGM(nextBGMName);
        }
    }


    /*===== SE =====*/

    /// <summary>
    ///  SE再生
    /// </summary>
    /// <param name="name">再生するSE名</param>
    /// <param name="delay">再生までの遅延秒数</param>
    public void PlaySE(string _seName, float delay)
    {
        if(!seDic.ContainsKey(_seName))
        {
            Debug.Log("指定したSEは存在しない");
            return;
        }

        nextSEName = _seName;
        Invoke("DelayPlaySE", delay);
    }
    private void DelayPlaySE()
    {
        SESorces.PlayOneShot(seDic[nextSEName] as AudioClip);
    }


    /*===== 音量変更 =====*/
    public void ChangeVolume(float _bgmVolume, float _seVolume)
    {
        BGMSorces.volume = _bgmVolume;
        SESorces.volume = _seVolume;

        PlayerPrefs.SetFloat(BGM_VOLUME_KEY, _bgmVolume);
        PlayerPrefs.SetFloat(SE_VOLUME_KEY, _seVolume);
    }
}
