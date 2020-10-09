using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopManager : MonoBehaviour
{
    public GameObject ShopPage;
    public Text CoinCount;

    private void Update()
    {
        CoinCount.text = "코인 : " + GameController_PGW.instance.TotalCoin.ToString();
    }
    public void OpenShop()
    {

        ShopPage.SetActive(true);
   }

    public void CloseShop()
    {

        ShopPage.SetActive(false);
    }

}
