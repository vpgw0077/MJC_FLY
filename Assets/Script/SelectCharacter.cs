using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectCharacter : MonoBehaviour
{
    public int Cost;// 가격
    public string charsName;
    public bool isUnlock;// 언락 유무
    public SelectCharacter[] chars;
    public Button btn;
    public Text txt;

    public Character character;
    public PlayerInfo thePlayer;

    // Start is called before the first frame update
    private void Start()
    {

        btn = GetComponent<Button>();

        for (int i = 0; i < DataManager_PGW.instance.chars.Count; i++)
        {
            if (charsName == DataManager_PGW.instance.chars[i].PlayerName)
            {
                thePlayer = DataManager_PGW.instance.chars[i];

            }
        }

        isUnlock = thePlayer.isUnlock;



    }

    private void Update()
    {
        if (!isUnlock)
        {
            txt.text = Cost + "$";
        }
        else
        {
            txt.text = "선 택";
        }
    }

    public void SelectChar()
    {
        if (isUnlock)
        {
            DataManager_PGW.instance.currentCharacter = character;
            for (int i = 0; i < chars.Length; i++)
            {
                if (chars[i] != this) chars[i].NotSelect();
            }

            OnSelect();
        }
    }
    public void StartBird()
    {
        if (DataManager_PGW.instance.FirstOn)
        {
            DataManager_PGW.instance.FirstOn = false;
            TryPurchase();

        }
    }
    public void OnSelect()
    {
        btn.interactable = false;
    }
    public void NotSelect()
    {
        btn.interactable = true;
    }

    public void TryPurchase()
    {
        if (!isUnlock)
        {
            if (DataManager_PGW.instance.TotalCoin >= Cost)
            {
                DataManager_PGW.instance.TotalCoin -= Cost;
                isUnlock = true;
                thePlayer.isUnlock = isUnlock;
                thePlayer.PlayerName = charsName;
                Purchase(thePlayer);
            }
        }
    }

    private void Purchase(PlayerInfo player)
    {
        player = thePlayer;
        DataManager_PGW.instance.chars.Add(player);
       // DataManager_PGW.instance.SaveData();
    }
}
