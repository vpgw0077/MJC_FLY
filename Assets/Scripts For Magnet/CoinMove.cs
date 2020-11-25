﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//SUBSCRIBE TO VIN CODES FOR MORE FREE SCRIPTS IN FUTURE VIDEOS :)

public class CoinMove : MonoBehaviour
{

    Coin coinScript;

    // Start is called before the first frame update
    void Start()
    {
        coinScript = gameObject.GetComponent<Coin>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, coinScript.playerTransform.position,
            coinScript.moveSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player Bubble")
        {
            //Add count or give points etc etc.
            Destroy(gameObject);
        }
    }
}
