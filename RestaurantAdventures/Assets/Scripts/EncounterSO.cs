using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Encounter", menuName = "Encounters/New Encounter")]
public class EncounterSO : ScriptableObject
{
    public string encounterName;
    public MonsterSO[] monsters;
    public float encounterChance;
}
