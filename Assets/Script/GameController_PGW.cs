using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController_PGW : MonoBehaviour
{
    public static GameController_PGW instance = null;
    public int TotalCoin;

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

    private void Start()
    {
        Debug.Log(TotalCoin);
    }

    public void GameOver(bool isOver)
    {
        if (isOver)
        {
            TotalCoin += CoinManager.CurrentCoin;
            SceneManager.LoadScene("MainTitle");
        }
    }


    public void GameStart()
    {
        SceneManager.LoadScene("Repeat");
    }

    public void Back()
    {
        instance.GameOver(true);
        SceneManager.LoadScene("MainTitle");
    }

    private void OnApplicationQuit()
    {

        GameData_PGW gameData = new GameData_PGW(TotalCoin);
        

        gameData.Save();
    }
    
}
