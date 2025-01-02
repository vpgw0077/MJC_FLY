using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;
using System.IO;

public enum CharacterList
{
    StandardBird = 0,
    BrownBird,
    RedBird
}
public enum AbilityList
{
    JumpPower,
    JumpCount,
    Gravity,
    ItemPower,
    LevitationDuration
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
    public int grade_LevitationDuration = 0;
    public CharacterList currentCharacter = CharacterList.StandardBird;

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
    public GameSettingData gameSettingData = new GameSettingData();

    public AbilityPurchaseData jumpCountData { get; private set; }
    public AbilityPurchaseData jumpPowerData { get; private set; }
    public AbilityPurchaseData gravityData { get; private set; }
    public AbilityPurchaseData itemPowerData { get; private set; }
    public AbilityPurchaseData LevitationDurationData { get; private set; }


    private string dataFilePath;
    private string playerDataFileName = "playerData";
    private string characterUnlockDataName = "unlockData";
    private string gameSettingDataName = "setting";
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
        LevitationDurationData = Resources.Load<AbilityPurchaseData>("ShopData/LevitationDurationData");

        dataFilePath = Application.persistentDataPath + "/save/";
        LoadData();

    }



    public void GameOver(bool isOver)
    {
        if (isOver)
        {
            playerData.totalCoin += CoinManager.instance.CurrentCoin;

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
        File.WriteAllText(dataFilePath + characterUnlockDataName, unlock_Data);

        string setting_Data = JsonUtility.ToJson(gameSettingData);
        File.WriteAllText(dataFilePath + gameSettingDataName, setting_Data);
    }

    public void LoadData()
    {
        if (!File.Exists(dataFilePath + playerDataFileName))
        {
            characterUnlockData.CharacterUnlockState[0] = true;
            for (int i = 1; i < characterUnlockData.CharacterUnlockState.Length; i++)
            {
                characterUnlockData.CharacterUnlockState[i] = false;
            }
            Debug.LogError("데이터가 없습니다");
            return;
        }
        string player_Data = File.ReadAllText(dataFilePath + playerDataFileName);
        playerData = JsonUtility.FromJson<PlayerData>(player_Data);

        string unlock_Data = File.ReadAllText(dataFilePath + characterUnlockDataName);
        characterUnlockData = JsonUtility.FromJson<CharacterUnlockData>(unlock_Data);

        string setting_Data = File.ReadAllText(dataFilePath + gameSettingDataName);
        gameSettingData = JsonUtility.FromJson<GameSettingData>(setting_Data);
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
            case AbilityList.LevitationDuration:
                playerData.grade_LevitationDuration++;
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
