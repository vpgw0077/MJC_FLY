using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIToggler : MonoBehaviour
{
    public void TogglePage(GameObject page)
    {
        bool isActive = page.activeSelf;
        page.SetActive(!isActive);
    }

}
