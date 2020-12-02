using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPlayer : MonoBehaviour
{
    public GameObject[] PlayerPrefabs;
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        player = Instantiate(PlayerPrefabs[(int)DataManager_PGW.instance.currentCharacter]);
        player.transform.position = transform.position;
    }


}
