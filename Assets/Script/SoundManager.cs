using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class SoundManager : MonoBehaviour
{
    public static SoundManager instance = null;

    public AudioSource bgmPlayer;

    public AudioSource[] sfxPlayer;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;

        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }

    public void PlaySE(AudioClip clip)
    {
        if (DataManager_PGW.instance.gameSettingData.SfxOn)
        {

            for (int i = 0; i < sfxPlayer.Length; i++)
            {
                if (!sfxPlayer[i].isPlaying)
                {
                    sfxPlayer[i].clip = clip;
                    sfxPlayer[i].Play();
                    return;
                }
            }
            
        }
    }

    public void PlayBGM(AudioClip clip)
    {
        if (DataManager_PGW.instance.gameSettingData.BgmOn)
        {
            bgmPlayer.clip = clip;
            bgmPlayer.Play();

        }
        else
        {
            bgmPlayer.Stop();
        }
    }

}
