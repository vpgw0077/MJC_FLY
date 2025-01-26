using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterController : MonoBehaviour
{
    public delegate void ExecuteEvent();
    public event ExecuteEvent JumpEvent;

    [SerializeField] private PlayerStat playerStat;

    private CharacterJump characterJump = null;
    private CharacterSound characterSound = null;
    private CharacterMagnet characterMagnet = null;
    private CollisionEvent collisionEvent = null;

    private Rigidbody2D rb = null;
    // Start is called before the first frame update
    void Awake()
    {
        Init();
    }

    private void Init()
    {
        playerStat.jumpCount += (int)DataManager_PGW.instance.jumpCountData.additionalAbility[DataManager_PGW.instance.playerData.grade_JumpCount];
        playerStat.gravity += DataManager_PGW.instance.gravityData.additionalAbility[DataManager_PGW.instance.playerData.grade_Gravity];
        playerStat.LevitationDuration += DataManager_PGW.instance.LevitationDurationData.additionalAbility[DataManager_PGW.instance.playerData.grade_LevitationDuration];
        playerStat.jumpPower += DataManager_PGW.instance.jumpPowerData.additionalAbility[DataManager_PGW.instance.playerData.grade_JumpPower];
        playerStat.itemPower += DataManager_PGW.instance.itemPowerData.additionalAbility[DataManager_PGW.instance.playerData.grade_ItemPower];

        rb = GetComponent<Rigidbody2D>();
        characterJump = GetComponent<CharacterJump>();
        characterSound = GetComponent<CharacterSound>();
        characterMagnet = GetComponent<CharacterMagnet>();
        collisionEvent = GetComponent<CollisionEvent>();

        collisionEvent.magnetEvent += ActivateMagnet;
        collisionEvent.itemEvent += ItemJump;

    }

    // Update is called once per frame
    void Update()
    {
        LimitVelocity();
        characterJump.CalculateJumpCoolDown(playerStat.LevitationDuration);
    }

    private void LimitVelocity()
    {
        if (rb.velocity.y < playerStat.gravity)
        {
            float velY = Mathf.Clamp(rb.velocity.y, playerStat.gravity, float.MaxValue);
            rb.velocity = new Vector2(rb.velocity.x, velY);
        }
    }

    public void Jump()
    {
        if (characterJump.isJumping) return;

        if (playerStat.jumpCount > 0)
        {
            characterJump.Jump(playerStat.jumpPower);
            characterSound.PlaySfx(characterSound.jumpSound);
            playerStat.jumpCount--;
            JumpEvent?.Invoke();

        }
    }

    private void ItemJump()
    {
        if (characterJump.isItemJumping) return;
        characterJump.ItemJump(playerStat.itemPower);
        characterSound.PlaySfx(characterSound.jumpSound);
    }

    private void ActivateMagnet()
    {
        characterMagnet.ActivateMagnet();
    }

    public int GetJumpCount()
    {
        return playerStat.jumpCount;
    }
}
