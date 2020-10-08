using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController_PGW : MonoBehaviour
{
    public static GameController_PGW instance = null;

    int TotalCoin;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;

            GameData_PGW gameData = GameData_PGW.Load();
            TotalCoin = gameData.TotalCoin;

        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }

    public void GameOver(bool isOver)
    {
        if (isOver)
        {
            TotalCoin += CoinManager.CurrentCoin;
            Debug.Log("총 코인량은 " + TotalCoin + "개 입니다.");
        }
    }


    public void GameStart()
    {
        SceneManager.LoadScene("Repeat");
    }

    private void OnApplicationQuit()
    {

        GameData_PGW gameData = new GameData_PGW(TotalCoin);


        gameData.Save();
    }
}
