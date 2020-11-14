using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinActivate : MonoBehaviour
{
    public Transform[] ChildrenCoin;
    // Start is called before the first frame update
    void Start()
    {
        ChildrenCoin = GetComponentsInChildren<Transform>();
    }

    // 먹은코인 다시 활성화
    public void CoinOn()
    {
        for (int i = 0; i < ChildrenCoin.Length; i++)
        {
            ChildrenCoin[i].gameObject.SetActive(true);
        }
    }
}
