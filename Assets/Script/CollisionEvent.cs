using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionEvent : MonoBehaviour
{
    public delegate void ExecuteEvent();
    public event ExecuteEvent gameOverEvent;

    private CharacterBase player = null;

    private void Start()
    {
        player = GetComponentInParent<CharacterBase>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Ground"))
        {
            gameOverEvent?.Invoke();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Item"))
        {
            player.CollideItem();
        }

        if (collision.CompareTag("Magnet"))
        {
            player.ActivateMagnet();
        }
    }
}
