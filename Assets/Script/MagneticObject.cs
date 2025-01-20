using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagneticObject : MonoBehaviour
{
    private bool magnetOn = false;
    private float moveSpeed = 20f;
    private Vector3 target = Vector3.zero;

    // Start is called before the first frame update


    public void ActivateMagnet(Vector3 target)
    {
        this.target = target;
        magnetOn = true;
    }


    private void Update()
    {
        if (magnetOn)
        {
            Vector3 direction = (target - transform.position).normalized;
            transform.position = Vector3.MoveTowards(transform.position, target, moveSpeed * Time.deltaTime);
        }
    }

    private void OnDisable()
    {
        magnetOn = false;
    }
}
