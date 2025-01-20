using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using TMPro;

public class AbilityUpgrade : MonoBehaviour
{
    [SerializeField] protected TextMeshProUGUI costText;
    [SerializeField] protected Button purchaseButton;

    protected AbilityList ability;
    protected AbilityPurchaseData abilityPurchaseData;
    protected int abilityGrade;
    protected int maximumAbilityGrade;
    protected string maxText = "MAX";
    protected ITrade[] trade;

    protected void Awake()
    {

        trade = FindObjectsOfType<MonoBehaviour>().OfType<ITrade>().ToArray();
    }
    protected virtual void Start()
    {
        UpdateUI();
    }
    public virtual void UpgradeAbility()
    {
        if (trade.Length > 0)
        {
            if (trade[0].TradeSucceed(abilityPurchaseData.cost[abilityGrade]))
            {
                DataManager_PGW.instance.playerData.totalCoin -= abilityPurchaseData.cost[abilityGrade];
                DataManager_PGW.instance.UpdateAbilityGradeData(ability);
                UpdateUI();
                trade[0].UpdateCoinCount();

                //ui 업데이트 - 돈, 업그레이드 현황, max시 변경

            }

            else
            {
                trade[0].TradeFail();
            }

        }

    }

    protected virtual void UpdateUI()
    {
        if (abilityGrade == maximumAbilityGrade)
        {
            costText.text = maxText;
            purchaseButton.interactable = false;
        }
        else
        {
            costText.text = string.Format("{0:#,###}", abilityPurchaseData.cost[abilityGrade]) + "$";

        }
    }
}
