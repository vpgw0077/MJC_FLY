using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin_PGW : Item
{
    [SerializeField] private int coinAmount = 10;

    private InGameRecorder inGameRecorder = null;

    protected override void Awake()
    {
        base.Awake();
        inGameRecorder = FindObjectOfType<InGameRecorder>();
    }


    protected override void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            inGameRecorder.UpdateCoin(coinAmount);
            SoundManager.instance.PlaySE(itemSound);
            gameObject.SetActive(false);
        }
    }

}
