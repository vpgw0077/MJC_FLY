using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionEvent : MonoBehaviour
{
    public delegate void GameOver();
    public event GameOver GameOverEvent;



    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Ground"))
        {
            GameOverEvent?.Invoke();
            Debug.Log(collision.transform.tag);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Magnet"))
        {

        }
        else if (collision.CompareTag("Item"))
        {

        }
    }
}
