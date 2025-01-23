using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class CharacterDic : SerializableDictionary<CharacterList, GameObject> { }
[CreateAssetMenu(fileName = "CharacterList", menuName = "Scriptable Object/CharacterList", order = int.MaxValue)]
public class CharacterDictionary : ScriptableObject
{
    public CharacterDic characters;

}
