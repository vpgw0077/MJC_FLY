using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dddd : MonoBehaviour
{
    Vector3 vel = Vector3.zero;
    Vector3 cameraOffset = new Vector3(0.85f, 0, -15);
    [SerializeField]GameObject target;
    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player");
        //transform.position = new Vector3(target.transform.position.x, target.transform.position.y, -15);
    }


    private void LateUpdate()
    {
        Vector3 targetPosition = target.transform.position + cameraOffset;
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref vel, 0);
    }
}
