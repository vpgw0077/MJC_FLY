using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevitationUpgrade : AbilityUpgrade
{
    protected override void Start()
    {
        ability = AbilityList.LevitationDuration;
        abilityPurchaseData = DataManager_PGW.instance.LevitationDurationData;
        base.Start();
    }

    public override void UpgradeAbility()
    {
        abilityGrade = DataManager_PGW.instance.playerData.grade_LevitationDuration ;
        base.UpgradeAbility();
    }
    protected override void UpdateUI()
    {
        abilityGrade = DataManager_PGW.instance.playerData.grade_LevitationDuration;
        maximumAbilityGrade = abilityPurchaseData.maximumGrade;
        base.UpdateUI();
    }
}
