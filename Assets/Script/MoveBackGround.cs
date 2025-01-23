using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBackGround : MonoBehaviour
{

    [SerializeField] private float speed = 0;
    [SerializeField] private float targetPosX = -80f;
    [SerializeField] private float showItemMoveDistance = 50f;



    private bool isActivate = false;

    private Vector3 moveDirection = new Vector3(-1, 0, 0);
    private Vector3 resetPosition = Vector3.zero;

    private float resetPosX = 80f;
    private float currentMoveDistance = 0;

    private ItemReset itemReset = null;

    // Start is called before the first frame update
    void Start()
    {
        resetPosition = new Vector3(resetPosX, transform.position.y, transform.position.z);
        itemReset = GetComponent<ItemReset>();

    }

    // Update is called once per frame
    void Update()
    {
        if (Time.timeScale > 0)
        {
            gameObject.transform.position += moveDirection * speed * Time.deltaTime;
            if (gameObject.transform.position.x < targetPosX)
            {
                ReplaceBG();

            }

            // 아이템 블럭 활성화
            if (isActivate)
            {
                currentMoveDistance += moveDirection.magnitude * speed * Time.deltaTime;
                if (currentMoveDistance >= showItemMoveDistance)
                {
                    isActivate = false;
                    currentMoveDistance = 0;
                    itemReset.ShowItemBlock();

                }

            }

        }



    }

    private void ReplaceBG()
    {
        gameObject.transform.position = resetPosition;
        itemReset.HideCurrentBlock();
        isActivate = true;

    }

}