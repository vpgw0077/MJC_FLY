using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin_PGW : MonoBehaviour,IMagnetic
{
    public int coinAmount;
    public string sound_Coin;
    public Transform PlayerTransform;
    public Vector3 Originpos;
    bool MagnetOn;

    private InGameManager inGameManager = null;

    private void Start()
    {
        //PlayerTransform = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        inGameManager = FindObjectOfType<InGameManager>();
        Originpos = transform.localPosition;
    }

    private void Update()
    {

        DragCoin();

    }

    private void DragCoin()
    {
        if (MagnetOn)
        {
            transform.position = Vector3.MoveTowards(transform.position, PlayerTransform.transform.position, 40f * Time.deltaTime);

        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            inGameManager.UpdateCoin(coinAmount);
            SoundManager.instance.PlaySE(sound_Coin);
            gameObject.SetActive(false);
        }

        else if (collision.CompareTag("MagnetZone"))
        {
            MagnetOn = true;
        }
    }

    private void OnDisable()
    {
        MagnetOn = false;
        transform.localPosition = Originpos;

    }
}
