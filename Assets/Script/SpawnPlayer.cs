using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPlayer : MonoBehaviour
{
    [SerializeField] private CharacterDictionary characterList;
    private void Awake()
    {
        GameObject player = Instantiate(characterList.characters[DataManager_PGW.instance.playerData.currentCharacter]);
        player.transform.position = transform.position;
    }


}
