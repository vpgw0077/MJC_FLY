using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemReset : MonoBehaviour
{
    [SerializeField] private GameObject[] itemBlock;
    [SerializeField] private GameObject currentBlock;


    public void ShowItemBlock()
    {
        currentBlock = itemBlock[Random.Range(0, itemBlock.Length)];
        currentBlock.SetActive(true);
    }

    public void HideCurrentBlock()
    {
        currentBlock.SetActive(false);
    }
}
