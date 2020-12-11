using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GamePlayManager : MonoBehaviour
{
    public GameObject StartPanel;
    public GameObject ResultPanel;
    public Text ResultCoin;
    public static bool isStart;
    // Start is called before the first frame update
    private void Awake()
    {
        Time.timeScale = 0;
        isStart = false;
    }
    public void GameStart()
    {
        isStart = true;
        Time.timeScale = 1;
        StartPanel.SetActive(false);
    }

    public void GameOver()
    {
        ResultPanel.SetActive(true);
        ResultCoin.text = " X " + CoinManager.instance.CurrentCoin.ToString();
        isStart = false;
    }

    public void Replay()
    {
        AdMobManager.instance.ShowFrontAd();
        DataManager_PGW.instance.GameStart();
    }
    public void BackToMain()
    {
        DataManager_PGW.instance.BacktoMain();
    }

}
