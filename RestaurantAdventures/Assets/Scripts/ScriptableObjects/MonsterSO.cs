using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Monster", menuName = "Monsters/New Monster")]
public class MonsterSO : ScriptableObject
{
    public string monsterName;

    public Sprite sprite;

    public int health;
    public int attack;
    public int magic;
    public int defense;
    public int resistance;
    public int speed;

    public SkillSO[] skills;
}
