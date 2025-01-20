using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterBase : MonoBehaviour
{
    [SerializeField] private LayerMask layer;
    [SerializeField] protected PlayerStat playerStat;
    [SerializeField] protected GameObject magnetZone;

    protected Vector3 moveDirection = Vector3.zero;
    protected bool isGround = true;

    protected float currentCoolDown = 0;

    protected float currentMagnetTime = 0;
    protected float magnetRange = 5f;
    protected WaitForSeconds magnetDuration = new WaitForSeconds(7f);


    protected bool isJumping = false;

    protected Rigidbody2D rb = null;
    private void Start()
    {
        Init();
    }
    private void Init()
    {
        playerStat.jumpCount += (int)DataManager_PGW.instance.jumpPowerData.additionalAbility[DataManager_PGW.instance.playerData.grade_JumpCount];
        playerStat.gravity += DataManager_PGW.instance.gravityData.additionalAbility[DataManager_PGW.instance.playerData.grade_Gravity];
        playerStat.LevitationDuration += DataManager_PGW.instance.LevitationDurationData.additionalAbility[DataManager_PGW.instance.playerData.grade_LevitationDuration];
        playerStat.jumpPower += DataManager_PGW.instance.jumpPowerData.additionalAbility[DataManager_PGW.instance.playerData.grade_JumpPower];
        rb = GetComponent<Rigidbody2D>();

    }
    void Update()
    {
        CheckGround();

    }
    private void FixedUpdate()
    {
        if (!isGround && !isJumping)
        {
            rb.velocity = new Vector2(0, playerStat.gravity);
        }
        if (isJumping)
        {
            Jump();
        }
    }
    protected virtual void Jump()
    {
        rb.velocity = Vector3.zero;
        rb.velocity = Vector2.up * playerStat.jumpPower * Time.fixedDeltaTime;
        currentCoolDown += Time.deltaTime;
        if (currentCoolDown >= playerStat.LevitationDuration)
        {
            currentCoolDown = 0;
            isJumping = false;
        }
    }

    public void CollideItem()
    {
        rb.velocity = Vector3.zero;
        rb.velocity = Vector2.up * playerStat.jumpPower;
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
        if (playerStat.jumpCount > 0)
        {
            isJumping = true;
            playerStat.jumpCount--;

        }
    }

}
