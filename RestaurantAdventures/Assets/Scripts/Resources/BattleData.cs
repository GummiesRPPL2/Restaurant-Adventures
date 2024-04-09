using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

[CreateAssetMenu(fileName = "BattleData", menuName = "Scriptable Objects/Battle Data", order = 1)]
public class BattleData : ScriptableObject
{
    public EncounterSO selectedEncounter;
    public PartySO playerParty;



    private static BattleData instance;
    public static BattleData Instance
    {
        get
        {
            if (instance == null)
            {
                instance = Resources.Load<BattleData>("BattleData");
            }
            return instance;
        }
    }
}
