using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseGame : MonoBehaviour
{
    public GameObject PauseUI;
    public static bool isPause;



    private void Awake()
    {
        isPause = false;
        
    }

    public void Pause()
    {
        PauseUI.SetActive(true);
        isPause = true;
        Time.timeScale = 0;
    }

    public void Resume()
    {
        PauseUI.SetActive(false);
        isPause = false;
        Time.timeScale = 1;
    }

    public void BackToMain()
    {
        isPause = false;
        DataManager_PGW.instance.Back();
    }
}
