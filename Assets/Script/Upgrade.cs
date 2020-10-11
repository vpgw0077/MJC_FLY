using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Upgrade : MonoBehaviour
{
    public static Upgrade instance;

    public int Cost;
    public int Grade;
    public int MaxJumpCount = 0;
    public float WindPower;

    float UpgradeForce = 1.2f;
    
    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }
    // Start is called before the first frame update
    void Start()
    {

        MaxJumpCount += 1;
        WindPower = 10f;
    }

    public void UpgradeJump()
    {
        WindPower *= UpgradeForce;
    }

    public void JumpUpgrade()
    {
        if(GameController_PGW.instance.TotalCoin >= Cost)
        {
            print("FFFF");
            GameController_PGW.instance.TotalCoin -= Cost;
            Grade += 1;
            GameController_PGW.instance.Grade = Grade;
            GameController_PGW.instance.SaveData();
        }
    }


}
