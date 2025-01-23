using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetUpWindow : MonoBehaviour
{
    [SerializeField] private Toggle bgmToggle = null;
    [SerializeField] private Toggle sfxToggle = null;

    [SerializeField] private AudioClip lobbyBgm = null;
    private void Start()
    {
        InitSetting();

    }
    private void InitSetting()
    {
        bgmToggle.isOn = DataManager_PGW.instance.gameSettingData.BgmOn;
        sfxToggle.isOn = DataManager_PGW.instance.gameSettingData.SfxOn;
        SoundManager.instance.PlayBGM(lobbyBgm);
    }
    public void ToggleBGM()
    {
        DataManager_PGW.instance.gameSettingData.BgmOn = bgmToggle.isOn;
        SoundManager.instance.PlayBGM(lobbyBgm);
    }

    public void ToggleSfx()
    {
        DataManager_PGW.instance.gameSettingData.SfxOn = sfxToggle.isOn;


    }

}
