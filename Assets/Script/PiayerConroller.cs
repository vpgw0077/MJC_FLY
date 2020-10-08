using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PiayerConroller : MonoBehaviour
{
    Rigidbody2D rigid;

    [SerializeField]
    private float power;

    Upgrade instance;
    CoinManager theCoin;

     int JumpCount;

    public void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
    }

    // Start is called before the first frame update
    void Start()
    {
        instance = Upgrade.instance;
        theCoin = FindObjectOfType<CoinManager>();
        JumpCount = instance.MaxJumpCount;
        
    }

    // Update is called once per frame
    void Update()

    {

    }

    public void TryJump()
    {
        if(JumpCount > 0)
        {
            rigid.velocity = Vector2.up * power;
            JumpCount -= 1;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Item"))
        {
            rigid.velocity = Vector2.up * instance.WindPower;
        }
        else if (collision.transform.CompareTag("Ground"))
        {
            GameController_PGW.instance.GameOver(true);
        }

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Coin"))
        {
            Coin_PGW thecoin = collision.GetComponent<Coin_PGW>();
            theCoin.AddCoin(thecoin.CoinAmount);
        }
    }
}
