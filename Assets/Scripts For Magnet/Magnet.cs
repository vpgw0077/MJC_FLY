﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//SUBSCRIBE TO VIN CODES FOR MORE FREE SCRIPTS IN FUTURE VIDEOS :)

public class Magnet : MonoBehaviour
{

    public GameObject coinDetectorObj;

    // Start is called before the first frame update
    void Start()
    {
        coinDetectorObj = GameObject.FindGameObjectWithTag("Coin Detector");
        coinDetectorObj.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            StartCoroutine(ActivateCoin());
            Destroy(transform.GetChild(0).gameObject);
            
        }
    }

    IEnumerator ActivateCoin()
    {
        coinDetectorObj.SetActive(true);
        yield return new WaitForSeconds(6f);
        coinDetectorObj.SetActive(false);
    }
}
