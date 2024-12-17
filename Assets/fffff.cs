using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fffff : MonoBehaviour
{
    Rigidbody2D rb;
    public float gravity;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(rb.velocity.x, -gravity);
    }
}
