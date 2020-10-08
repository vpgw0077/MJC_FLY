using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinManager : MonoBehaviour
{
    public Text CoinText;

    public static int CurrentCoin;
    // Start is called before the first frame update
    void Start()
    {
        CoinText.text = "코인 : " + CurrentCoin.ToString();
    }

    public void AddCoin(int coin)
    {
        CurrentCoin += coin;
        CoinText.text = "코인 : " + CurrentCoin.ToString();
    }


}
