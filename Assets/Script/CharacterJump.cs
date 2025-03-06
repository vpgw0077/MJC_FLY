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

    protected virtual void CalculateJumpCoolDown()
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

    public virtual void Jump(float jumpPower)
    {
        isJumping = true;
        rb.AddForce(Vector2.up * jumpPower, ForceMode2D.Force);

    }

}
