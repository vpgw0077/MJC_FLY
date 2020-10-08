using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Upgrade : MonoBehaviour
{
    public static Upgrade instance;


    public int MaxJumpCount;
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
        MaxJumpCount += 4;
        WindPower = 10f;
    }

    public void UpgradeJump()
    {
        WindPower *= UpgradeForce;
    }

}
