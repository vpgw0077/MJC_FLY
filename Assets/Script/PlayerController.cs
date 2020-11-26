using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody2D rigid;

    float power;

    float WindForce = 10f;

    public int JumpCount;
    public string sound_Jump;

    public GameObject MagnetZone;



    // Start is called before the first frame update
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();




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

        if (GameController_PGW.instance.GravityGrade < 1)
        {
            rigid.gravityScale = 3;
        }
        else
        {
            rigid.gravityScale = GameController_PGW.instance.GravityScale;
        }

        if (GameController_PGW.instance.JumpPower < 20)
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
            SoundManager.instance.PlaySE(sound_Jump);
            JumpCount -= 1;
        }
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.transform.CompareTag("Ground"))
        {
            GameController_PGW.instance.GameOver(true);
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.transform.CompareTag("Item"))
        {
            SoundManager.instance.PlaySE(sound_Jump);
            rigid.velocity = Vector2.up * WindForce;
        }

        if (collision.transform.CompareTag("Magnet"))
        {
            StartCoroutine(MagnetActivate());
            collision.gameObject.SetActive(false);
        }
    }

    IEnumerator MagnetActivate()
    {
        MagnetZone.SetActive(true);
        yield return new WaitForSeconds(10f);
        MagnetZone.SetActive(false);
    }
}
