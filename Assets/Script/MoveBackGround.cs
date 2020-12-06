using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBackGround : MonoBehaviour
{
    public enum BG_num
    {
        first,
        second
    }
    public BG_num BackGround_Number;
    public float speed;
    public GameObject[] CoinBlock;
    public GameObject CurrentBlock;

    int random;
    Transform tr;
    public CoinActivate ChildrenCoin;
    // Start is called before the first frame update
    void Start()
    {

        tr = GetComponent<Transform>();
        if (BackGround_Number == BG_num.first)
        {

            random = UnityEngine.Random.Range(0, CoinBlock.Length);
            CoinBlock[random].SetActive(true);
            CurrentBlock = CoinBlock[random];
            ChildrenCoin = CurrentBlock.GetComponent<CoinActivate>();

        }
        else if(BackGround_Number == BG_num.second)
        {
            StartCoroutine(ShowCoin());
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!PauseGame.isPause && GamePlayManager.isStart)
        {
            tr.Translate(speed, 0, 0);
            if (tr.position.x < -80)
            {
                ReplaceBG();

            }

        }



    }

    private IEnumerator ShowCoin()
    {
        random = UnityEngine.Random.Range(0, CoinBlock.Length);
        yield return new WaitForSeconds(11.5f);
        CoinBlock[random].SetActive(true);
        CurrentBlock = CoinBlock[random];
        ChildrenCoin = CurrentBlock.GetComponent<CoinActivate>();
    }

    private void ReplaceBG()
    {

        tr.position = new Vector3(80f, tr.position.y, 0);
        ChildrenCoin.CoinOn();
        CurrentBlock.SetActive(false);
        StartCoroutine(ShowCoin());


    }

}