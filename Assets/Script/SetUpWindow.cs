using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetUpWindow : MonoBehaviour
{
    [SerializeField] private GameObject SetUp;

    [SerializeField] private Toggle bgmToggle;
    [SerializeField] private Toggle sfxToggle;

    private void Start()
    {
        InitSetting();

    }
    private void InitSetting()
    {
        bgmToggle.isOn = DataManager_PGW.instance.gameSettingData.BgmOn;
        sfxToggle.isOn = DataManager_PGW.instance.gameSettingData.SfxOn;
    }
    public void ToggleBGM()
    {
        DataManager_PGW.instance.gameSettingData.BgmOn = bgmToggle.isOn;
    }

    public void ToggleSfx()
    {
        DataManager_PGW.instance.gameSettingData.SfxOn = sfxToggle.isOn;


    }
    public void OpenSetUp()
    {
        SetUp.SetActive(true);
    }
    public void CloseSetUp()
    {
        SetUp.SetActive(false);
    }

}
