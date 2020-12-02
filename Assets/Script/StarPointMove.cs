using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarPointMove : MonoBehaviour
{
    public float speed;
    Transform tr;
    // Start is called before the first frame update
    void Start()
    {
        tr = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!PauseGame.isPause && GamePlayManager.isStart)
        {
            tr.Translate(speed, 0, 0);
            if (tr.position.x < -80)
            {
                gameObject.SetActive(false);

            }

        }
    }
}
