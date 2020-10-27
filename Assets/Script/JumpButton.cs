﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JumpButton : MonoBehaviour
{
    Button btn;
    PlayerController thePlayer;
    // Start is called before the first frame update
    void Start()
    {
        btn = GetComponent<Button>();
        thePlayer = FindObjectOfType<PlayerController>();
        btn.onClick.AddListener(thePlayer.TryJump);

    }

}