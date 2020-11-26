using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagnetZone : MonoBehaviour
{
    public GameObject Player;

    bool isOn;

    private void OnEnable()
    {
        isOn = true;
    }
    private void OnDisable()
    {
        isOn = false;
    }
    private void Update()
    {
        if (isOn)
        {
            transform.position = Player.transform.position;

        }
    }


}
