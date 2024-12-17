using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ffffffffffffff : MonoBehaviour
{
    enum test
    {
        가렌,블라디,아펠,이즈리얼,소나,아리
    }
    test ff;
    test[] tests;
    // Start is called before the first frame update
    void Start()
    {
        tests = (test[])Enum.GetValues(typeof(test));

        print(Enum.GetValues(typeof(test)).Length);
        /*foreach(test tt in tests)
        {
            print(tt);
        }*/

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
