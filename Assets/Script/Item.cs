using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Item : MonoBehaviour
{
    [SerializeField] protected AudioClip itemSound = null;

    [SerializeField] protected Vector3 originPos;
    protected float invokeTime = 3f;

    // Start is called before the first frame update
    protected virtual void Awake()
    {
        originPos = transform.localPosition;
    }

    protected abstract void OnTriggerEnter2D(Collider2D collision);

    protected void ActivateSelf()
    {
        gameObject.SetActive(true);
        transform.localPosition = originPos;
    }
    protected void OnDisable()
    {
        Invoke("ActivateSelf", invokeTime);
    }
}
