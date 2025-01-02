using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterBase : MonoBehaviour
{
    [SerializeField] private LayerMask layer;
    [SerializeField] protected PlayerStat playerStat;

    protected Vector3 moveDirection = Vector3.zero;
    [SerializeField]protected bool isGround = true;

    protected float currentCoolDown = 0;
    protected bool isJumping = false;

    private void Start()
    {
        Init();
    }
    private void Init()
    {

        /*playerStat.jumpCount += (int)DataManager_PGW.instance.jumpPowerData.additionalAbility[DataManager_PGW.instance.playerData.grade_JumpPower];
        playerStat.gravity += DataManager_PGW.instance.gravityData.additionalAbility[DataManager_PGW.instance.playerData.grade_Gravity];
        playerStat.LevitationDuration += DataManager_PGW.instance.LevitationDurationData.additionalAbility[DataManager_PGW.instance.playerData.grade_LevitationDuration];*/
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
            Jump();
        }
    }

    protected virtual void Jump()
    {
        transform.position += new Vector3(0, playerStat.jumpPower, 0) * Time.deltaTime * 0.3f;
        currentCoolDown += Time.deltaTime;
        if (currentCoolDown >= playerStat.LevitationDuration)
        {
            currentCoolDown = 0;
            isJumping = false;
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

    }
    public void ReadyToJump()
    {
        if (playerStat.jumpCount > 0)
        {
            isJumping = true;
            playerStat.jumpCount--;

        }
    }

}
