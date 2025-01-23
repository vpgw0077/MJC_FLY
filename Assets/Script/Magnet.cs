using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Magnet : Item
{
    // Start is called before the first frame update

    protected override void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            // Awake 참조 문제 때문에 자석 활성화는 다른 스크립트에서 처리
            SoundManager.instance.PlaySE(itemSound);
            gameObject.SetActive(false);
        }
    }
}
