using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBackGround : MonoBehaviour
{
    public float speed;
    public GameObject[] CoinBlock;
    public GameObject CurrentBlock;

    int random;
    Transform tr;
    CoinActivate ChildrenCoin;
    // Start is called before the first frame update
    void Start()
    {
        tr = GetComponent<Transform>();
        random = UnityEngine.Random.Range(0, CoinBlock.Length);
        CoinBlock[random].SetActive(true);
        CurrentBlock = CoinBlock[random];
        ChildrenCoin = CurrentBlock.GetComponent<CoinActivate>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!PauseGame.isPause)
        {
            tr.Translate(speed, 0, 0);
            if (tr.position.x < -80)
            {
                ReplaceBG();

            }

        }
    }

    private void ReplaceBG()
    {
        tr.position = new Vector3(40f, tr.position.y, 0);
        ChildrenCoin.CoinOn();
        CurrentBlock.SetActive(false);
        random = UnityEngine.Random.Range(0, CoinBlock.Length);
        CoinBlock[random].SetActive(true);
        CurrentBlock = CoinBlock[random];
        ChildrenCoin = CurrentBlock.GetComponent<CoinActivate>();
    }

}