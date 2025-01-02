using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class PurchaseCharacter : MonoBehaviour
{
    [SerializeField] private int cost = 0;
    [SerializeField] private CharacterList character;
    [SerializeField] private Button purchaseButton;
    [SerializeField] private Text costText;
    private bool IsUnlock => DataManager_PGW.instance.characterUnlockData.CharacterUnlockState[(int)character];

    private ITrade[] trade;
    protected void Awake()
    {

        trade = FindObjectsOfType<MonoBehaviour>().OfType<ITrade>().ToArray();
    }
    private void Start()
    {
        UpdateUI();
    }
    private void Update()
    {
        UpdateButtonAction();
    }
    public void SelectAndPurchase()
    {
        // 선택할 때
        if (IsUnlock)
        {
            DataManager_PGW.instance.playerData.currentCharacter = character;
            UpdateButtonAction();
        }

        // 구매할 때
        else
        {

            if (trade.Length > 0)
            {
                if (trade[0].TradeSucceed(cost, character))
                {
                    DataManager_PGW.instance.playerData.totalCoin -= cost;
                    DataManager_PGW.instance.characterUnlockData.CharacterUnlockState[(int)character] = true;
                    UpdateUI();
                }

                else
                {
                    trade[0].TradeFail();
                }
            }
        }

    }
    private void UpdateButtonAction()
    {
        if (DataManager_PGW.instance.playerData.currentCharacter == character)
        {
            purchaseButton.interactable = false;
        }
        else
        {
            purchaseButton.interactable = true;
        }
    }
    private void UpdateUI()
    {
        if (IsUnlock)
        {
            costText.text = "선 택";
        }
        else
        {
            costText.text = cost.ToString() + "$";
        }
    }

}
