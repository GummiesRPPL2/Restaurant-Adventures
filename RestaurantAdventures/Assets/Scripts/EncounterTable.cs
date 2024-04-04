using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EncounterTable : MonoBehaviour
{
    public RandomEncounterManager encounterManager;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            encounterManager.TriggerEncounterInArea("BerthierryPlains");
        }
    }
}
