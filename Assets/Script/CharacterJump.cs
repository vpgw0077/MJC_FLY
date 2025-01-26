using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterJump : MonoBehaviour
{

    protected float itemJumpCoolDown = 0.5f;
    protected float currentItemJumpCoolDown = 0;
    protected float currentCoolDown = 0;


    public bool isJumping { get; private set; } = false;
    public bool isItemJumping { get; private set; } = false;

    protected Rigidbody2D rb = null;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        CalculateJumpCoolDown();
    }

    // 일반 점프 캐릭터마다 다르게 구현될 수 있게
    public virtual void CalculateJumpCoolDown(float levitationDuration)
    {
        if (isJumping)
        {
            currentCoolDown += Time.deltaTime;
            if (currentCoolDown >= levitationDuration)
            {
                currentCoolDown = 0;
                isJumping = false;
            }
        }
    }

    // 아이템과 닿았을 때 점프
    private void CalculateJumpCoolDown()
    {

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
    public virtual void ItemJump(float jumpPower)
    {
        isItemJumping = true;
        rb.AddForce(Vector2.up * jumpPower, ForceMode2D.Force);

    }

    public void Jump(float jumpPower)
    {
        isJumping = true;
        rb.AddForce(Vector2.up * jumpPower, ForceMode2D.Force);

    }

}
