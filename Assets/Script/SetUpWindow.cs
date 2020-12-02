using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetUpWindow : MonoBehaviour
{
    public GameObject SetUp;

    public Toggle BGM_Toggle;
    public Toggle Sfx_Toggle;

    public bool BGM_On = true;
    public bool Sfx_On = true;

    private void Start()
    {
        BGM_Toggle.isOn = DataManager_PGW.instance.BgmOn;
        Sfx_Toggle.isOn = DataManager_PGW.instance.SfxOn;
    }
    public void ToggleBGM()
    {
        BGM_On = BGM_Toggle.isOn;
        DataManager_PGW.instance.BgmOn = BGM_On;
        DataManager_PGW.instance.SaveData();
        if (BGM_On)
        {
            SoundManager.instance.bgmPlayer.Play();

        }
        else
        {
            SoundManager.instance.bgmPlayer.Stop();
        }
    }

    public void ToggleSfx()
    {
        Sfx_On = Sfx_Toggle.isOn;
        DataManager_PGW.instance.SfxOn = Sfx_On;
        DataManager_PGW.instance.SaveData();
        
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
