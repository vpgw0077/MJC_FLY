using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public enum Character
{
    P1, P2, P3,P4
}

public class DataManager_PGW : MonoBehaviour
{
    public static DataManager_PGW instance = null;
    public bool FirstOn = true;

    public int JumpGrade;
    public int MaxJumpCount;

    public int ItemGrade;
    public float WindForce;

    public int GravityGrade;
    public float GravityScale;

    public int JumpPowerGrade;
    public float JumpPower;

    public int TotalCoin;
    public List<PlayerInfo> chars = new List<PlayerInfo>();

    public Character currentCharacter;

    public bool BgmOn;
    public bool SfxOn;
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



    public void GameOver(bool isOver)
    {
        if (isOver)
        {
            TotalCoin += CoinManager.instance.CurrentCoin;
            SaveData();
            AdMobManager.instance.ShowFrontAd();

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
    public void BacktoMain()
    {
        SceneManager.LoadScene("MainTitle");
    }
    public void GameQuit()
    {
        Application.Quit();
    }



    public void SaveData()
    {
        SaveData save = new SaveData();
        save.TotalCoin = TotalCoin;

        save.JumpGrade = JumpGrade;
        save.MaxJumpCount = MaxJumpCount;

        save.ItemGrade = ItemGrade;
        save.WindForce = WindForce;

        save.JumpPowerGrade = JumpPowerGrade;
        save.JumpPower = JumpPower;

        save.GravityGrade = GravityGrade;
        save.GravityScale = GravityScale;

        save.playerSkin = currentCharacter;
        save.chars = chars;
        save.Firston = FirstOn;

        save.BgmOn = BgmOn;
        save.SfxOn = SfxOn;

        GameData_PGW.Save(save);
    }

    public void LoadData()
    {
        SaveData save = GameData_PGW.Load();
        if (save != null)
        {
            TotalCoin = save.TotalCoin;

            JumpGrade = save.JumpGrade;
            MaxJumpCount = save.MaxJumpCount;

            ItemGrade = save.ItemGrade;
            WindForce = save.WindForce;

            JumpPowerGrade = save.JumpPowerGrade;
            JumpPower = save.JumpPower;

            GravityGrade = save.GravityGrade;
            GravityScale = save.GravityScale;

            currentCharacter = save.playerSkin;
            chars = save.chars;
            FirstOn = save.Firston;

            BgmOn = save.BgmOn;
            SfxOn = save.SfxOn;

        }
    }

}
