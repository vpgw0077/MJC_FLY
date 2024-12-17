using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class AbilityUpgrade : MonoBehaviour
{
    [SerializeField] protected Text costText;
    [SerializeField] protected Button purchaseButton;

    protected AbilityList ability;
    protected AbilityPurchaseData abilityPurchaseData;
    protected int abilityGrade;
    protected int maximumAbilityGrade;
    protected string maxText = "MAX";
    protected ICoinUpdate[] coinUpdate;

    protected void Awake()
    {
        coinUpdate = FindObjectsOfType<MonoBehaviour>().OfType<ICoinUpdate>().ToArray();
    }
    protected virtual void Start()
    {
        UpdateUI();   
    }
    public virtual void UpgradeAbility()
    {
        if (DataManager_PGW.instance.playerData.totalCoin >= abilityPurchaseData.cost[abilityGrade])
        {
            DataManager_PGW.instance.playerData.totalCoin -= abilityPurchaseData.cost[abilityGrade];
            DataManager_PGW.instance.UpdateAbilityGradeData(ability);
            UpdateUI();
            if (coinUpdate.Length > 0)
            {
                coinUpdate[0].UpdateCoinCount();
            }
            //ui 업데이트 - 돈, 업그레이드 현황, max시 변경

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
            costText.text = abilityPurchaseData.cost[abilityGrade].ToString();
        }
    }
}
