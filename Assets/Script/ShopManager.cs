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

    public Text CoinCount;

    public int Cost;
    public int Grade;
    public int MaxJumpCount = 0;
    public float WindPower;

    private void Start()
    {

        Grade = GameController_PGW.instance.Grade;
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



    public void JumpUpgrade()
    {
        if (GameController_PGW.instance.TotalCoin >= Cost && Grade < 3)
        {
            JumpGrade();
            GameController_PGW.instance.TotalCoin -= Cost;
            GameController_PGW.instance.Grade = Grade;
            GameController_PGW.instance.MaxJumpCount = MaxJumpCount;
            GameController_PGW.instance.SaveData();
        }
    }

    public void JumpGrade()
    {
        switch (Grade)
        {
            case 0:

                MaxJumpCount = 2;
                Grade++;
                break;

            case 1:

                MaxJumpCount = 3;
                Grade++;
                break;
            case 2:

                MaxJumpCount = 4;
                Grade++;
                break;


        }
    }

    private void UpdateCost()
    {
        if (Grade == 0)
        {
            Cost = 100;

        }
        else if (Grade == 1)
        {
            Cost = 200;
        }
        else if(Grade == 2)
        {
            Cost = 400;
        }

        JumpText.text = Cost.ToString() + "$";
        if (Grade == 3)
        {
            JumpText.text = "업그레이드 완료";
            JumpUpgradeBtn.interactable = false;
        }

    }
}
