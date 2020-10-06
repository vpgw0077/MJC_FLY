using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController_PGW : MonoBehaviour
{
    public static GameController_PGW instance = null;

    public Text CoinText;

    int CurrentCoin;
    int TotalCoin;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;

            GameData_PGW gameData = GameData_PGW.Load();
            TotalCoin = gameData.TotalCoin;
            CoinText.text = "코인 : " + CurrentCoin.ToString();

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
            TotalCoin += CurrentCoin;
            Debug.Log("총 코인량은 " + TotalCoin + "개 입니다.");
        }
    }


    public void AddCoin(int coin)
    {
        CurrentCoin += coin;
        CoinText.text = "코인 : " + CurrentCoin.ToString();
    }

    private void OnApplicationQuit()
    {

        GameData_PGW gameData = new GameData_PGW(TotalCoin);


        gameData.Save();
    }
}
