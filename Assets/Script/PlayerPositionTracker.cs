using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerPositionTracker : MonoBehaviour
{
    [SerializeField] private Transform groundPos = null;
    [SerializeField] private Transform topSkyPos = null;
    [SerializeField] private Transform playerPos = null;

    [SerializeField] private float distance = 0;
    [SerializeField] private float distanceRatio = 0;

    [SerializeField] private Slider positionTracker = null;
 
    void Start()
    {
        playerPos = FindObjectOfType<CharacterController>().GetComponent<Transform>();
        distance = Mathf.Abs(groundPos.position.y) + Mathf.Abs(topSkyPos.position.y);
        distanceRatio = 1 / distance;
    }

    private void TrackPlayer()
    {
        positionTracker.value = (playerPos.position.y - groundPos.position.y) * distanceRatio;
    }
    // Update is called once per frame
    void Update()
    {
        TrackPlayer();
    }
}
