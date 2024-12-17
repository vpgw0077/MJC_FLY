using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPowerUpgrade : AbilityUpgrade
{
    protected override void Start()
    {
        ability = AbilityList.ItemPower;
        abilityPurchaseData = DataManager_PGW.instance.itemPowerData;
        base.Start();
    }

    public override void UpgradeAbility()
    {
        abilityGrade = DataManager_PGW.instance.playerData.grade_ItemPower;
        base.UpgradeAbility();
    }
    protected override void UpdateUI()
    {
        abilityGrade = DataManager_PGW.instance.playerData.grade_ItemPower;
        maximumAbilityGrade = abilityPurchaseData.maximumGrade;
        base.UpdateUI();
    }
}
