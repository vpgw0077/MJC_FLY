using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
public class CameraController : MonoBehaviour
{
    private Transform player = null;
    private Vector3 camOffset = new Vector3(0, 0, -10);
    private CinemachineVirtualCamera cam = null;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        transform.position = player.transform.position + camOffset;
        cam = FindObjectOfType<CinemachineVirtualCamera>();
        cam.Follow = player;

    }


}
