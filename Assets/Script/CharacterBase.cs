using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterBase : MonoBehaviour, IJump
{
    public GameObject gg;
    public LayerMask layer;
    Vector3 moveDirection = new Vector3(0, -9.81f, 0);
    protected int jumpCount = 1;
    [SerializeField] protected float jumpPower = 15f;
    protected float windForce = 10f; // 아이템 파워
    protected float gravity = -9.81f;
    bool isGround = true;
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        checkGround();
        if (Input.GetKeyDown(KeyCode.Q)) Jump();

        if (!isGround)
        {
            transform.position += moveDirection * Time.deltaTime;

        }

    }
    private void checkGround()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, 0.2f, layer);
        if (Physics2D.Raycast(transform.position, Vector2.down, 0.2f, layer))
        {
            isGround = true;
            Debug.Log(hit.transform.name);
        }
        else
        {
            isGround = false;
        }
        // 땅에 있는지 검사
    }
    private void OnDrawGizmos()
    {
        Debug.DrawRay(transform.position, Vector2.down * 0.3f, Color.red);
    }
    public void Jump()
    {

        transform.Translate(Vector2.up * jumpPower);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "Ground")
        {
            transform.position = gg.transform.position;
        }
    }
}
