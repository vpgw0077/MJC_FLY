using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class fsdfsdg : MonoBehaviour
{
    Button btn;
    CharacterBase character;
    // Start is called before the first frame update
    void Start()
    {
        btn = GetComponent<Button>();
        character = FindObjectOfType<CharacterBase>();
        btn.onClick.AddListener(character.Jump);
    }

}
