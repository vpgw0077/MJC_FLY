using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PiayerConroller : MonoBehaviour
{
    Rigidbody rigid;

    [SerializeField]
    private float power;

    public void Awake()
    {
        rigid = GetComponent<Rigidbody>();
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



}
