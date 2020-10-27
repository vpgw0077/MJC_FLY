using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SaveData
{
    public int TotalCoin;
    public int JumpGrade;
    public int MaxJumpCount;

    public int ItemGrade;
    public float WindForce;

    public Character playerSkin;
    public bool Firston;

    public List<PlayerInfo> chars = new List<PlayerInfo>();

}
[System.Serializable]
public class PlayerInfo
{
    public string PlayerName;
    public bool isUnlock;
}
