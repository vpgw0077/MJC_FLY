using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpCountUpgrade : AbilityUpgrade
{
    protected override void Start()
    {
        ability = AbilityList.JumpCount;
        abilityPurchaseData = DataManager_PGW.instance.jumpCountData;
        base.Start();
    }

    public override void UpgradeAbility()
    {
        abilityGrade = DataManager_PGW.instance.playerData.grade_JumpCount;
        base.UpgradeAbility();
    }
    protected override void UpdateUI()
    {
        abilityGrade = DataManager_PGW.instance.playerData.grade_JumpCount;
        maximumAbilityGrade = abilityPurchaseData.maximumGrade;
        base.UpdateUI();
    }
}
