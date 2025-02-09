using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class gdfgfdddf : MonoBehaviour
{
    [SerializeField] private Transform t1;
    [SerializeField] private Transform t2;
    [SerializeField] private Transform player;

    [SerializeField] private float dis = 0;
    [SerializeField] private float fff = 0;
    [SerializeField] private Slider slider = null;

    private void Start()
    {
        dis = Mathf.Abs(t1.position.y) + Mathf.Abs(t2.position.y);
        fff = 1 / dis;
    }
    private void Update()
    {

        slider.value = (player.position.y - t2.position.y) * fff;
    }


}
