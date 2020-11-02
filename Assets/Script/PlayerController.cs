using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody2D rigid;
    CoinManager theCoin;


    float power;

    float WindForce = 10f;

    public int JumpCount;



    // Start is called before the first frame update
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        theCoin = FindObjectOfType<CoinManager>();




        if (GameController_PGW.instance.MaxJumpCount < 2)

        {
            JumpCount = 1;
        }
        else
        {
            JumpCount = GameController_PGW.instance.MaxJumpCount;
        }

        if (GameController_PGW.instance.WindForce < 20)
        {
            WindForce = 15;
        }
        else
        {
            WindForce = GameController_PGW.instance.WindForce;
        }

        if(GameController_PGW.instance.GravityGrade < 1)
        {
            rigid.gravityScale = 3;
        }
        else
        {
            rigid.gravityScale = GameController_PGW.instance.GravityScale;
        }

        if(GameController_PGW.instance.JumpPower < 20)
        {
            power = 15f;

        }
        else
        {
            power = GameController_PGW.instance.JumpPower;
        }


    }

    public void TryJump()
    {
        if (JumpCount > 0)
        {
            rigid.velocity = Vector2.up * power;
            JumpCount -= 1;
        }
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Item"))
        {
            rigid.velocity = Vector2.up * WindForce;
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
            collision.gameObject.SetActive(false);
        }
    }
}
