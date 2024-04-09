using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

[CreateAssetMenu(fileName = "Skill", menuName = "Skills/New Skill")]
public class SkillSO : ScriptableObject
{
    public string skillName;
    public int damage;
}
