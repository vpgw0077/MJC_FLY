using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;
using System.IO;

public enum Character
{
    P1, P2, P3, P4
}
public enum CharacterList
{
    StandardBird = 0,
    BrownBird
}
public enum AbilityList
{
    JumpPower,
    JumpCount,
    Gravity,
    ItemPower
}
public class CharacterUnlockData
{
    public bool[] CharacterUnlockState = new bool[Enum.GetValues(typeof(CharacterList)).Length];
}
public class PlayerData
{
    public int totalCoin;
    public int grade_JumpCount = 0;
    public int grade_JumpPower = 0;
    public int grade_Gravity = 0;
    public int grade_ItemPower = 0;
    public CharacterList currentCharacter;

}
public class GameSettingData
{
    public bool BgmOn = true;
    public bool SfxOn = true;
}
public class DataManager_PGW : MonoBehaviour
{
    public static DataManager_PGW instance = null;
    public CharacterUnlockData characterUnlockData = new CharacterUnlockData();
    public PlayerData playerData = new PlayerData();


    public AbilityPurchaseData jumpCountData;
    public AbilityPurchaseData jumpPowerData;
    public AbilityPurchaseData gravityData;
    public AbilityPurchaseData itemPowerData;

    [SerializeField]private string dataFilePath;
    private string playerDataFileName = "playerData";
    private string CharacterUnlockDataName = "unlockData";

    #region 정리
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
    #endregion
    void Awake()
    {
        if (instance == null)
        {
            instance = this;


        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);

        jumpCountData = Resources.Load<AbilityPurchaseData>("ShopData/JumpCountData");
        jumpPowerData = Resources.Load<AbilityPurchaseData>("ShopData/JumpPowerData");
        gravityData = Resources.Load<AbilityPurchaseData>("ShopData/GravityData");
        itemPowerData = Resources.Load<AbilityPurchaseData>("ShopData/ItemPowerData");

        dataFilePath = Application.persistentDataPath + "/save/";
        playerData.totalCoin += 10000;
        LoadData();
        /* if (File.Exists())
         {
             LoadData();
         }
         else
         {
             characterUnlockData.CharacterUnlockState[0] = true;
             for (int i = 1; i < characterUnlockData.CharacterUnlockState.Length; i++)
             {
                 characterUnlockData.CharacterUnlockState[i] = false;
             }
         }*/

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
    private void OnApplicationQuit()
    {
        SaveData();

    }
    public void SaveData()
    {
        string player_Data = JsonUtility.ToJson(playerData);
        File.WriteAllText(dataFilePath + playerDataFileName, player_Data);
        string unlock_Data = JsonUtility.ToJson(characterUnlockData);
        File.WriteAllText(dataFilePath + CharacterUnlockDataName, unlock_Data);
    }

    public void LoadData()
    {
        if (!File.Exists(dataFilePath + playerDataFileName))
        {
            Debug.LogError("데이터가 없습니다");
            return;
        }
        string player_Data = File.ReadAllText(dataFilePath + playerDataFileName);
        playerData = JsonUtility.FromJson<PlayerData>(player_Data);
        string unlock_Data = File.ReadAllText(dataFilePath + CharacterUnlockDataName);
        characterUnlockData = JsonUtility.FromJson<CharacterUnlockData>(unlock_Data);
    }


    public void UpdateAbilityGradeData(AbilityList ability)
    {
        switch (ability)
        {
            case AbilityList.JumpPower:
                playerData.grade_JumpPower++;
                break;
            case AbilityList.JumpCount:
                playerData.grade_JumpCount++;
                break;
            case AbilityList.Gravity:
                playerData.grade_Gravity++;
                break;
            case AbilityList.ItemPower:
                playerData.grade_ItemPower++;
                break;

        }
    }
   /* public void SaveData()
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
    }*/

    /*public void LoadData()
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
    }*/

}
