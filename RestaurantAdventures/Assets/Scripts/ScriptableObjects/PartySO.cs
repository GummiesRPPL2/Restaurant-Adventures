using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Party", menuName = "Parties/Party")]
public class PartySO : ScriptableObject
{ 
    public List<CharacterSO> characters = new List<CharacterSO>();
}
