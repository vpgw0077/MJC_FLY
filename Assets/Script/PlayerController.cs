using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float vel;
    public Rigidbody2D rigid;

    float power;

    float WindForce = 10f;

    public int JumpCount;
    public string sound_Jump;

    public GameObject MagnetZone;
    GamePlayManager GamePlayer;


    // Start is called before the first frame update
    /*void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        GamePlayer = FindObjectOfType<GamePlayManager>();



        if (DataManager_PGW.instance.MaxJumpCount < 2)

        {
            JumpCount = 1;
        }
        else
        {
            JumpCount = DataManager_PGW.instance.MaxJumpCount;
        }

        if (DataManager_PGW.instance.WindForce < 20)
        {
            WindForce = 15;
        }
        else
        {
            WindForce = DataManager_PGW.instance.WindForce;
        }

        if (DataManager_PGW.instance.GravityGrade < 1)
        {
            rigid.gravityScale = 3;
        }
        else
        {
            rigid.gravityScale = DataManager_PGW.instance.GravityScale;
        }

        if (DataManager_PGW.instance.JumpPower < 20)
        {
            power = 15f;

        }
        else
        {
            power = DataManager_PGW.instance.JumpPower;
        }


    }*/
    private void Update()
    {
        vel = rigid.velocity.magnitude;
    }
    public void TryJump()
    {
        if (JumpCount > 0)
        {
            rigid.velocity = Vector2.zero;
            rigid.velocity = Vector2.up * power;
            SoundManager.instance.PlaySE(sound_Jump);
            JumpCount -= 1;
        }
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.transform.CompareTag("Ground"))
        {
            DataManager_PGW.instance.GameOver(true);
            GamePlayer.GameOver();
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.transform.CompareTag("Item"))
        {
            SoundManager.instance.PlaySE(sound_Jump);
            rigid.velocity = Vector2.zero;
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
