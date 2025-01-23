using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideObject : MonoBehaviour
{
    private float delayTime = 3f;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("Hide", delayTime);
    }
    private void Hide()
    {
        gameObject.SetActive(false);
    }

}
