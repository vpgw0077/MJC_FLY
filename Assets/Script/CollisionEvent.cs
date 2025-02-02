using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionEvent : MonoBehaviour
{
    public delegate void ExecuteEvent();
    public event ExecuteEvent gameOverEvent;
    public event ExecuteEvent gameStartEvent;
    public event ExecuteEvent itemEvent;
    public event ExecuteEvent magnetEvent;
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
            itemEvent?.Invoke();
        }

        if (collision.CompareTag("Magnet"))
        {
            magnetEvent?.Invoke();
        }

        if (collision.CompareTag("StartTrigger"))
        {
            gameStartEvent?.Invoke();
        }
    }
}
