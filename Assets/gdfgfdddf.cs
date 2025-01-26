using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class gdfgfdddf : MonoBehaviour
{
    [SerializeField] private Button btn = null;
    [SerializeField] private ShopManager shop = null;
    // Start is called before the first frame update

    void Start()
    {
        btn = GetComponent<Button>();
        shop = FindObjectOfType<ShopManager>();

    }

}
