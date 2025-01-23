using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterBase : MonoBehaviour
{
    [SerializeField] private LayerMask layer;
    [SerializeField] protected PlayerStat playerStat;
    [SerializeField] protected GameObject magnetZone = null;
    [SerializeField] protected AudioClip jumpSound = null;

    protected Vector3 moveDirection = Vector3.zero;
    protected bool isGround = true;

    protected float itemJumpCoolDown = 0.5f;
    [SerializeField] protected float currentItemJumpCoolDown = 0;
    [SerializeField] protected float currentCoolDown = 0;

    protected float currentMagnetTime = 0;
    protected float magnetRange = 5f;
    protected WaitForSeconds magnetDuration = new WaitForSeconds(7f);


    protected bool isJumping = false;
    [SerializeField] protected bool isItemJumping = false;

    protected Rigidbody2D rb = null;
    private void Awake()
    {
        Init();
    }
    private void Init()
    {
        playerStat.jumpCount += (int)DataManager_PGW.instance.jumpPowerData.additionalAbility[DataManager_PGW.instance.playerData.grade_JumpCount];
        playerStat.gravity += DataManager_PGW.instance.gravityData.additionalAbility[DataManager_PGW.instance.playerData.grade_Gravity];
        playerStat.LevitationDuration += DataManager_PGW.instance.LevitationDurationData.additionalAbility[DataManager_PGW.instance.playerData.grade_LevitationDuration];
        playerStat.jumpPower += DataManager_PGW.instance.jumpPowerData.additionalAbility[DataManager_PGW.instance.playerData.grade_JumpPower];
        playerStat.itemPower += DataManager_PGW.instance.itemPowerData.additionalAbility[DataManager_PGW.instance.playerData.grade_ItemPower];
        rb = GetComponent<Rigidbody2D>();

    }
    void Update()
    {
        CheckGround();
        LimitVelocity();
        CalculateJumpCoolDown();
    }
    private void CalculateJumpCoolDown()
    {
        if (isJumping)
        {
            currentCoolDown += Time.deltaTime;
            if (currentCoolDown >= playerStat.LevitationDuration)
            {
                currentCoolDown = 0;
                isJumping = false;
            }
        }

        if (isItemJumping)
        {
            currentItemJumpCoolDown += Time.deltaTime;
            if (currentItemJumpCoolDown >= itemJumpCoolDown)
            {
                currentItemJumpCoolDown = 0;
                isItemJumping = false;

            }
        }
    }
    private void LimitVelocity()
    {
        if (rb.velocity.y < -10)
        {
            float velY = Mathf.Clamp(rb.velocity.y, -10f, float.MaxValue);
            rb.velocity = new Vector2(rb.velocity.x, velY);
        }
    }

    public void CollideItem()
    {
        if (isItemJumping) return;
        isItemJumping = true;
        SoundManager.instance.PlaySE(jumpSound);
        rb.AddForce(Vector2.up * playerStat.itemPower, ForceMode2D.Force);

    }

    public void ActivateMagnet()
    {
        StopCoroutine(nameof(MagnetCoroutine));
        StartCoroutine(nameof(MagnetCoroutine));

    }
    protected IEnumerator MagnetCoroutine()
    {
        magnetZone.SetActive(true);
        yield return magnetDuration;
        magnetZone.SetActive(false);
    }
    protected void CheckGround()
    {
        if (Physics2D.Raycast(transform.position, Vector2.down, 0.2f, layer))
        {
            isGround = true;
        }
        else
        {
            isGround = false;
        }

    }
    public void ReadyToJump()
    {
        if (isJumping) return;

        if (playerStat.jumpCount > 0)
        {
            isJumping = true;
            SoundManager.instance.PlaySE(jumpSound);
            rb.AddForce(Vector2.up * playerStat.jumpPower, ForceMode2D.Force);
            playerStat.jumpCount--;

        }
    }

}
