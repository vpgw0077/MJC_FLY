using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSound : MonoBehaviour
{
    [field: SerializeField] public AudioClip jumpSound { get; private set; }

    public void PlaySfx(AudioClip clip)
    {
        SoundManager.instance.PlaySE(clip);
    }
}
