using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMagnet : MonoBehaviour
{
    [SerializeField] private GameObject magnetZone = null;

    private WaitForSeconds magnetDuration = new WaitForSeconds(7f);
    // Start is called before the first frame update

    public void ActivateMagnet()
    {
        StopCoroutine(nameof(MagnetCoroutine));
        StartCoroutine(nameof(MagnetCoroutine));

    }
    protected IEnumerator MagnetCoroutine()
    {
        magnetZone.SetActive(true);
        yield return magnetDuration;
        magnetZone.SetActive(false);
    }
}
