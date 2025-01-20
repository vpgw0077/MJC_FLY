using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gdfgfdd : MonoBehaviour
{
    [SerializeField] private Rigidbody2D[] rb;

    private void Start()
    {
        rb = FindObjectsOfType<Rigidbody2D>();
    }
}
