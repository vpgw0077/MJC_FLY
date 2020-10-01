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
        Move();
        Jump();

    }

    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //rb.velocity = Vector3.zero;
            rb.AddForce(Vector2.up * JumpForce, ForceMode2D.Impulse);
        }
    }

    private void Move()
    {
        positionX = positionX + 0.005f;
        tr.position = new Vector2(positionX, tr.position.y);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Trigger"))
        {
            tr.position = originpos;
            rb.velocity = Vector3.zero;
        }
    }
}
