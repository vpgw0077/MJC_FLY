using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class InGameTimeToggle : MonoBehaviour
{
    private CollisionEvent collisionEvent = null;
    // Start is called before the first frame update

    private void Start()
    {
        Pause();
        collisionEvent = FindObjectOfType<CollisionEvent>();
        if (collisionEvent != null)
        {
            collisionEvent.gameOverEvent += Pause;
        }
    }


    public void Pause()
    {
        Time.timeScale = 0;
    }

    public void Resume()
    {
        Time.timeScale = 1;
    }

}
