using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemMove : MonoBehaviour
{
    Transform tr;

    // Start is called before the first frame update
    void Start()
    {
        tr = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        tr.Translate(-0.1f, 0, 0);

        if (tr.position.x < -12)
        {
            tr.position = new Vector3(12, tr.position.y, tr.position.z);
        }

        else
        {

        }
    }
}
