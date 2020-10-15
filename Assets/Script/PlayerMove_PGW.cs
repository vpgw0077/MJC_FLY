using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove_PGW : MonoBehaviour
{
    public float JumpForce;

    float positionX;
    Rigidbody2D rb;
    Vector3 originpos;
    Transform tr;

    // Start is called before the first frame update
    void Start()
    {
        tr = GetComponent<Transform>();
        originpos = transform.position;
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
      
       Jump();

    }

    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.velocity = Vector3.zero;
            rb.velocity = Vector2.up * JumpForce;
        }
    }

    private void Move()
    {
        positionX = positionX + 0.04f;
        tr.position = new Vector2(positionX, tr.position.y);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Item"))
        {
            rb.velocity = Vector2.up * 10f;
        }
    }


}
