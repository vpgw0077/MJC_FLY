using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ShopManager : MonoBehaviour, ITrade
{
    [SerializeField] private GameObject tradeFailUI = null;
    [SerializeField] private TextMeshProUGUI coinCount = null;

    private void Start()
    {
        UpdateCoinCount();
    }


    public void UpdateCoinCount()
    {
        coinCount.text = string.Format("{0:#,###0}", DataManager_PGW.instance.playerData.totalCoin);

    }

    public bool TradeSucceed(int cost)
    {
        if(DataManager_PGW.instance.playerData.totalCoin >= cost)
        {
            return true;
        }
        return false;
    }
    public bool TradeSucceed(int cost, CharacterList character)
    {
        if (DataManager_PGW.instance.playerData.totalCoin >= cost && DataManager_PGW.instance.characterUnlockData.CharacterUnlockState[(int)character] == false )
        {
            return true;
        }
        return false;
    }
    public void TradeFail()
    {
        tradeFailUI.SetActive(true);
    }
}
