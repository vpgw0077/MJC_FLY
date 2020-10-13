using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopManager : MonoBehaviour
{
    public GameObject ShopPage;
    public GameObject CharacterShop;
    public GameObject ItemShop;
    public GameObject PaymentShop;

    public Button JumpUpgradeBtn;
    public Text JumpText;

    public Button ItemUpgradeBtn;
    public Text ItemText;

    public Text CoinCount;

    public int JumpCost;
    public int JumpGrade;
    public int MaxJumpCount = 0;

    public int ItemCost;
    public int ItemGrade;
    public float WindPower;

    private void Start()
    {

        JumpGrade = GameController_PGW.instance.JumpGrade;
        ItemGrade = GameController_PGW.instance.ItemGrade;
        UpdateCost();
    }

    private void Update()
    {
        CoinCount.text = "코인 : " + GameController_PGW.instance.TotalCoin.ToString();
        UpdateCost();
    }
    public void OpenShop()
    {

        ShopPage.SetActive(true);
    }

    public void CloseShop()
    {

        ShopPage.SetActive(false);
    }

    public void OpenCharacterShop()
    {
        CharacterShop.SetActive(true);
        ItemShop.SetActive(false);
        PaymentShop.SetActive(false);
    }

    public void OpenItemShop()
    {
        CharacterShop.SetActive(false);
        ItemShop.SetActive(true);
        PaymentShop.SetActive(false);
    }

    public void OpenPaymentShop()
    {
        CharacterShop.SetActive(false);
        ItemShop.SetActive(false);
        PaymentShop.SetActive(true);
    }

    public void TryItemUpgrade()
    {
        if (GameController_PGW.instance.TotalCoin >= ItemCost && ItemGrade < 3)
        {
            ItemUpGrade();
            GameController_PGW.instance.TotalCoin -= ItemCost;
            GameController_PGW.instance.ItemGrade = ItemGrade;
            GameController_PGW.instance.WindForce = WindPower;
            GameController_PGW.instance.SaveData();
        }
    }

    public void TryJumpUpgrade()
    {
        if (GameController_PGW.instance.TotalCoin >= JumpCost && JumpGrade < 3)
        {
            JumpUpGrade();
            GameController_PGW.instance.TotalCoin -= JumpCost;
            GameController_PGW.instance.JumpGrade = JumpGrade;
            GameController_PGW.instance.MaxJumpCount = MaxJumpCount;
            GameController_PGW.instance.SaveData();
        }
    }

    public void JumpUpGrade()
    {
        switch (JumpGrade)
        {
            case 0:

                MaxJumpCount = 2;
                JumpGrade++;
                break;

            case 1:

                MaxJumpCount = 3;
                JumpGrade++;
                break;
            case 2:

                MaxJumpCount = 4;
                JumpGrade++;
                break;

        }


    }
    public void ItemUpGrade()
    {
        switch (ItemGrade)
        {
            case 0:

                WindPower = 20;
                ItemGrade++;
                break;

            case 1:

                WindPower = 30;
                ItemGrade++;
                break;
            case 2:

                WindPower = 40;
                ItemGrade++;
                break;

        }
    }

    private void UpdateCost()
    {
        if (JumpGrade == 0)
        {
            JumpCost = 100;

        }
        else if (JumpGrade == 1)
        {
            JumpCost = 200;
        }
        else if (JumpGrade == 2)
        {
            JumpCost = 400;
        }

        if (ItemGrade == 0)
        {
            ItemCost = 100;

        }
        else if (ItemGrade == 1)
        {
            ItemCost = 200;
        }
        else if (ItemGrade == 2)
        {
            ItemCost = 400;
        }

        JumpText.text = "점프 업그레이드 " + JumpCost.ToString() + "$";
        ItemText.text = "아이템 업그레이드" + ItemCost.ToString() + "$";

        if (JumpGrade == 3)
        {
            JumpText.text = "업그레이드 완료";
            JumpUpgradeBtn.interactable = false;
        }
        if (ItemGrade == 3)
        {
            ItemText.text = "업그레이드 완료";
            ItemUpgradeBtn.interactable = false;
        }

    }
}
