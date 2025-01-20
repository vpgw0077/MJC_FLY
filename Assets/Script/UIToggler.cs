using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIToggler : MonoBehaviour
{
    public void OpenPage(GameObject page)
    {
        page.SetActive(true);
    }
    public void ClosePage(GameObject page)
    {
        page.SetActive(false);
    }
    public void TogglePage(GameObject page)
    {
        bool isActive = page.activeSelf;
        page.SetActive(!isActive);
    }

}
