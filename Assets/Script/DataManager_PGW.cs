using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public enum Character
{
    P1, P2, P3, P4
}

public class ShopData
{
    public int grade_JumpCount = 0;
    public readonly int[] cost_JumpCount = new int[5] { 100, 200, 400, 800, 1600 };
    public readonly int[] additional_JumpCount = new int[6] { 0, 1, 2, 3, 4, 5 };
    public readonly int maxJumpCountGrade = 5;

    public int grade_JumpPower = 0;
    public readonly int[] cost_JumpPower = new int[5] { 100, 200, 400, 800, 1600 };
    public readonly int[] additional_JumpPower = new int[6] { 0, 20, 25, 30, 35, 40 };
    public readonly int maxJumpPowerGrade = 5;

    public int grade_Gravity = 0;
    public readonly int[] cost_Gravity = new int[5] { 100, 200, 400, 800, 1600 };
    public readonly int[] reduction_Gravity = new int[6] { 0, 1, 2, 3, 4, 5 };
    public readonly int maxGravityGrade = 5;

    public int grade_ItemPower = 0;
    public readonly int[] cost_ItemPower = new int[5] { 100, 200, 400, 800, 1600 };
    public readonly int[] additional_ItemPower = new int[6] { 0, 20, 25, 30, 40, 50 };
    public readonly int maxItemPowerGrade = 5;
}
public class PlayerData
{
    public int totalCoin;
    public int grade_JumpCount = 0;
    public int grade_JumpPower = 0;
    public int grade_Gravity = 0;
    public int grade_ItemPower = 0;
    /*public int grade_JumpCount;
    public int grade_JumpPower;
    public int grade_Gravity;
    public int grade_ItemPower;

    public int jumpCount = 1;
    public float WindForce;
    public float JumpPower;
    public float GravityScale;

    public Character playerSkin;
    public bool Firston;

    public List<PlayerInfo> chars = new List<PlayerInfo>();*/
}
public class GameSettingData
{
    public bool BgmOn = true;
    public bool SfxOn = true;
}
public class DataManager_PGW : MonoBehaviour
{
    public static DataManager_PGW instance = null;
    public ShopData shopData = new ShopData();
    public PlayerData playerData = new PlayerData();

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

        }
    }


    public void GameStart()
    {
        AdMobManager.instance.ShowFrontAd();
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
