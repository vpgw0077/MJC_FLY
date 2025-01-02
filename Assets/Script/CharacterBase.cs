using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterBase : MonoBehaviour, IJump
{
    public GameObject gg;
    public LayerMask layer;
    protected Vector3 moveDirection = Vector3.zero;
    [SerializeField] protected PlayerStat playerStat;
    bool isGround = true;

    public float jumpCoolDown = 1;
    public float currentCoolDown = 0;
    public bool isJumping = false;
    // Start is called before the first frame update

    // Update is called once per frame
    private void Start()
    {
        Init();
    }
    private void Init()
    {

        //playerStat.jumpCount += (int)DataManager_PGW.instance.jumpPowerData.additionalAbility[DataManager_PGW.instance.playerData.grade_JumpPower];
        //playerStat.gravity += DataManager_PGW.instance.gravityData.additionalAbility[DataManager_PGW.instance.playerData.grade_Gravity];
        moveDirection = new Vector3(0, playerStat.gravity, 0);
    }
    void Update()
    {
        checkGround();
        if (!isGround && !isJumping)
        {
            transform.position += moveDirection * Time.deltaTime;

        }
        if (isJumping)
        {
            transform.position += new Vector3(0, playerStat.jumpPower, 0) * Time.deltaTime * 0.5f;
            currentCoolDown += Time.deltaTime;
            if (currentCoolDown >= jumpCoolDown)
            {
                currentCoolDown = 0;
                isJumping = false;
            }
        }
    }
    private void checkGround()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, 0.2f, layer);
        if (Physics2D.Raycast(transform.position, Vector2.down, 0.2f, layer))
        {
            isGround = true;
            Debug.Log(hit.transform.name);
        }
        else
        {
            isGround = false;
        }
        // 땅에 있는지 검사
    }
    private void OnDrawGizmos()
    {
        Debug.DrawRay(transform.position, Vector2.down * 0.3f, Color.red);
    }
    public void Jump()
    {
        if (playerStat.jumpCount > 0)
        {
            isJumping = true;
            playerStat.jumpCount--;

        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "Ground")
        {
            transform.position = gg.transform.position;
        }
    }
}
