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

    public Button JumpUpgradeBtn;
    public Text JumpText;

    public Button JumpPowerBtn;
    public Text JumpPowerText;

    public Button GravityBtn;
    public Text GravityText;

    public Button ItemUpgradeBtn;
    public Text ItemText;

    public Text CoinCount;

    public int GravityCost;
    public int GravityGrade;
    public float GravityScale;

    public int JumpPowerCost;
    public int JumpPowerGrade;
    public float JumpPower;

    public int JumpCost;
    public int JumpGrade;
    public int MaxJumpCount = 0;

    public int ItemCost;
    public int ItemGrade;
    public float WindPower;

    private void Start()
    {

        JumpGrade = DataManager_PGW.instance.JumpGrade;
        ItemGrade = DataManager_PGW.instance.ItemGrade;
        JumpPowerGrade = DataManager_PGW.instance.JumpPowerGrade;
        GravityGrade = DataManager_PGW.instance.GravityGrade;
        UpdateCost();
    }

    private void Update()
    {
        CoinCount.text = " X " + DataManager_PGW.instance.TotalCoin.ToString();
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
    }

    public void OpenItemShop()
    {
        CharacterShop.SetActive(false);
        ItemShop.SetActive(true);
    }

    public void OpenPaymentShop()
    {
        CharacterShop.SetActive(false);
        ItemShop.SetActive(false);
    }

    public void TryItemUpgrade()
    {
        if (DataManager_PGW.instance.TotalCoin >= ItemCost && ItemGrade < 5)
        {
            ItemUpGrade();
            DataManager_PGW.instance.TotalCoin -= ItemCost;
            DataManager_PGW.instance.ItemGrade = ItemGrade;
            DataManager_PGW.instance.WindForce = WindPower;
            DataManager_PGW.instance.SaveData();
        }
    }

    public void TryJumpUpgrade()
    {
        if (DataManager_PGW.instance.TotalCoin >= JumpCost && JumpGrade < 5)
        {
            JumpUpGrade();
            DataManager_PGW.instance.TotalCoin -= JumpCost;
            DataManager_PGW.instance.JumpGrade = JumpGrade;
            DataManager_PGW.instance.MaxJumpCount = MaxJumpCount;
            DataManager_PGW.instance.SaveData();
        }
    }

    public void TryJumpPowerUpgrade()
    {
        if(DataManager_PGW.instance.TotalCoin >= JumpPowerCost && JumpPowerGrade < 5)
        {
            JumpPowerUpgrade();
            DataManager_PGW.instance.TotalCoin -= JumpPowerCost;
            DataManager_PGW.instance.JumpPowerGrade = JumpPowerGrade;
            DataManager_PGW.instance.JumpPower = JumpPower;
            DataManager_PGW.instance.SaveData();
        }
    }

    public void TryGravityUpgrade()
    {
        if (DataManager_PGW.instance.TotalCoin >= GravityCost && GravityGrade < 5)
        {
            GravityUpgrade();
            DataManager_PGW.instance.TotalCoin -= GravityCost;
            DataManager_PGW.instance.GravityGrade = GravityGrade;
            DataManager_PGW.instance.GravityScale = GravityScale;
            DataManager_PGW.instance.SaveData();
        }
    }

    public void GravityUpgrade()
    {
        switch (GravityGrade)
        {
            case 0:

                GravityScale = 2.6f;
                GravityGrade++;
                break;

            case 1:

                GravityScale = 2.2f;
                GravityGrade++;
                break;
            case 2:

                GravityScale = 1.8f;
                GravityGrade++;
                break;

            case 3:

                GravityScale = 1.4f;
                GravityGrade++;
                break;

            case 4:

                GravityScale = 1f;
                GravityGrade++;
                break;

        }
    }

    public void JumpPowerUpgrade()
    {
        switch (JumpPowerGrade)
        {
            case 0:

                JumpPower = 20f;
                JumpPowerGrade++;
                break;

            case 1:

                JumpPower = 25f;
                JumpPowerGrade++;
                break;
            case 2:

                JumpPower = 30f;
                JumpPowerGrade++;
                break;

            case 3:

                JumpPower = 35f;
                JumpPowerGrade++;
                break;

            case 4:

                JumpPower = 40f;
                JumpPowerGrade++;
                break;

        }
    }

    public void JumpUpGrade()
    {
        switch (JumpGrade)
        {
            case 1:

                MaxJumpCount = 2;
                JumpGrade++;
                break;

            case 2:

                MaxJumpCount = 3;
                JumpGrade++;
                break;
            case 3:

                MaxJumpCount = 4;
                JumpGrade++;
                break;

            case 4:

                MaxJumpCount = 5;
                JumpGrade++;
                break;

            case 5:

                MaxJumpCount = 6;
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

                WindPower = 25;
                ItemGrade++;
                break;

            case 2:

                WindPower = 30;
                ItemGrade++;
                break;

            case 3:

                WindPower = 40;
                ItemGrade++;
                break;

            case 4:

                WindPower = 50;
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
        else if (JumpGrade == 3)
        {
            JumpCost = 800;
        }
        else if (JumpGrade == 4)
        {
            JumpCost = 1600;
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
        else if (ItemGrade == 3)
        {
            ItemCost = 800;
        }
        else if (ItemGrade == 4)
        {
            ItemCost = 1600;
        }



        if (JumpPowerGrade == 0)
        {
            JumpPowerCost = 100;

        }
        else if (JumpPowerGrade == 1)
        {
            JumpPowerCost = 200;
        }
        else if (JumpPowerGrade == 2)
        {
            JumpPowerCost = 400;
        }
        else if (JumpPowerGrade == 3)
        {
            JumpPowerCost = 800;
        }
        else if (JumpPowerGrade == 4)
        {
            JumpPowerCost = 1600;
        }


        if (GravityGrade == 0)
        {
            GravityCost = 100;

        }
        else if (GravityGrade == 1)
        {
            GravityCost = 200;
        }
        else if (GravityGrade == 2)
        {
            GravityCost = 400;
        }
        else if (GravityGrade == 3)
        {
            GravityCost = 800;
        }
        else if (GravityGrade == 4)
        {
            GravityCost = 1600;
        }

        JumpText.text = JumpCost.ToString() + "$";
        ItemText.text = ItemCost.ToString() + "$";
        JumpPowerText.text = JumpPowerCost.ToString() + "$";
        GravityText.text = GravityCost.ToString() + "$";

        if (JumpGrade == 5)
        {
            JumpText.text = "MAX";
            JumpUpgradeBtn.interactable = false;
        }
        if (ItemGrade == 5)
        {
            ItemText.text = "MAX";
            ItemUpgradeBtn.interactable = false;
        }
        if (JumpPowerGrade == 5)
        {
            JumpPowerText.text = "MAX";
            JumpPowerBtn.interactable = false;
        }
        if (GravityGrade == 5)
        {
            GravityText.text = "MAX";
            GravityBtn.interactable = false;
        }

    }
}
