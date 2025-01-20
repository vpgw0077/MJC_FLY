using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagnetZone : MonoBehaviour
{

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out MagneticObject magnet))
        {
            magnet.ActivateMagnet(transform.parent.position);
        }
    }

}
