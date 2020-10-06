using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PiayerConroller : MonoBehaviour
{
    Rigidbody2D rigid;

    [SerializeField]
    private float power;

    public void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()

    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rigid.velocity = Vector2.up * power;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Item"))
        {
            rigid.velocity = Vector2.up * 20f;
        }
    }

}
