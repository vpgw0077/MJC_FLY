using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityUpgrade : AbilityUpgrade
{
    protected override void Start()
    {
        ability = AbilityList.Gravity;
        abilityPurchaseData = DataManager_PGW.instance.gravityData;
        base.Start();
    }

    public override void UpgradeAbility()
    {
        abilityGrade = DataManager_PGW.instance.playerData.grade_Gravity;
        base.UpgradeAbility();
    }
    protected override void UpdateUI()
    {
        abilityGrade = DataManager_PGW.instance.playerData.grade_Gravity;
        maximumAbilityGrade = abilityPurchaseData.maximumGrade;
        base.UpdateUI();
    }
}
