using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpPowerUpgrade : AbilityUpgrade
{
    protected override void Start()
    {
        ability = AbilityList.JumpPower;
        abilityPurchaseData = DataManager_PGW.instance.jumpPowerData;
        base.Start();
    }

    public override void UpgradeAbility()
    {
        abilityGrade = DataManager_PGW.instance.playerData.grade_JumpPower;
        base.UpgradeAbility();
    }
    protected override void UpdateUI()
    {
        abilityGrade = DataManager_PGW.instance.playerData.grade_JumpPower;
        maximumAbilityGrade = abilityPurchaseData.maximumGrade;
        base.UpdateUI();
    }
}
