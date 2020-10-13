using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController_PGW : MonoBehaviour
{
    public static GameController_PGW instance = null;

    public int JumpGrade;
    public int MaxJumpCount;

    public int ItemGrade;
    public float WindForce;

    public int TotalCoin;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            LoadData();

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
            SaveData();
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

    public void SaveData()
    {
        SaveData save = new SaveData();
        save.TotalCoin = TotalCoin;
        save.JumpGrade = JumpGrade;
        save.MaxJumpCount = MaxJumpCount;
        save.ItemGrade = ItemGrade;
        save.WindForce = WindForce;
        GameData_PGW.Save(save);
    }

    public void LoadData()
    {
        SaveData save = GameData_PGW.Load();
        JumpGrade = save.JumpGrade;
        TotalCoin = save.TotalCoin;
        MaxJumpCount = save.MaxJumpCount;
        ItemGrade = save.ItemGrade;
        WindForce = save.WindForce;
    }

    private void OnApplicationQuit()
    {

        GameOver(true);

    }

}
