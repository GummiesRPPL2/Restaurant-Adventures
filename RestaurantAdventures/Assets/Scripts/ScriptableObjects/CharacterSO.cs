using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Character", menuName ="Characters/New Character")]
public class CharacterSO : ScriptableObject
{
    public string characterName;
    public Sprite sprite;
    public int maxHealth;
    public int attack;
    public int defense;
    public int magic;
    public int resistance;
    public int speed;
}
