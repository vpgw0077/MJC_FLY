﻿using UnityEngine;
[CreateAssetMenu(fileName = "AbilityPurchase Data", menuName = "Scriptable Object/AbilityPurchase Data", order = int.MaxValue)]

public class AbilityPurchaseData : ScriptableObject
{
    public int[] cost;
    [Space]
    public float[] additionalAbility;
    [Space]
    public int maximumGrade;
    
}
