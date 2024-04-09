using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using static RandomEncounterManager;

[System.Serializable]
public class AreaEncounterTable
{
    public string areaName;
    public List<EncounterSO> encounterTable;
}

public class RandomEncounterManager : MonoBehaviour
{
    // Dictionary to map areas to encounter tables
    //public Dictionary<string, List<EncounterSO>> areaEncounterTables = new Dictionary<string, List<EncounterSO>>();

    public List<AreaEncounterTable> areaEncounterTables = new List<AreaEncounterTable>();

    //[SerializeField] int minNumberOfMonstersToEncounter = 1;
    //[SerializeField] int maxNumberOfMonstersToEncounter = 4;

    public PartySO playerParty;

    public void AddEncounterTableForArea(string areaName, List<EncounterSO> encounterTable)
    {
        // Check if the area already exists in the list
        foreach (var areaEncounterTable in areaEncounterTables)
        {
            if (areaEncounterTable.areaName == areaName)
            {
                Debug.LogWarning("Encounter table already exists for area: " + areaName);
                return;
            }
        }

        // If the area doesn't exist, add it to the list
        AreaEncounterTable newAreaEncounterTable = new AreaEncounterTable();
        newAreaEncounterTable.areaName = areaName;
        newAreaEncounterTable.encounterTable = encounterTable;
        areaEncounterTables.Add(newAreaEncounterTable);
    }

    // Function to trigger an encounter in a specific area
    public void TriggerEncounterInArea(string areaName)
    {
        AreaEncounterTable areaTable = areaEncounterTables.Find(x => x.areaName == areaName);
        if (areaTable != null)
        {
            List<EncounterSO> encounterTable = areaTable.encounterTable;
            if (encounterTable.Count > 0)
            {
                int randomIndex = UnityEngine.Random.Range(0, encounterTable.Count);
                EncounterSO selectedEncounter = encounterTable[randomIndex];
                StartBattleEncounter(selectedEncounter, playerParty);
            }
            else
            {
                Debug.LogWarning("Encounter table is empty for area: " + areaName);
            }
        }
        else
        {
            Debug.LogWarning("Encounter table not found for area: " + areaName);
        }
    }

    // Function to select multiple random monsters from an encounter table
    private List<EncounterSO> SelectRandomMonsters(List<EncounterSO> encounterTable, int count)
    {
        List<EncounterSO> selectedMonsters = new List<EncounterSO>();

        if (encounterTable.Count == 0)
        {
            Debug.LogWarning("Encounter table is empty.");
            return selectedMonsters;
        }

        // Ensure count does not exceed the number of monsters available in the encounter table
        count = Mathf.Min(count, encounterTable.Count);

        // Shuffle the encounter table to randomize monster selection
        Shuffle(encounterTable);

        // Select count number of monsters from the shuffled encounter table
        for (int i = 0; i < count; i++)
        {
            selectedMonsters.Add(encounterTable[i]);
        }

        return selectedMonsters;
    }

    // Function to start a battle encounter with selected monsters
    private void StartBattleEncounter(EncounterSO selectedEncounter, PartySO playerParty)
    {
        if (selectedEncounter != null && playerParty != null)
        {
            Debug.Log("Starting battle encounter with: " + selectedEncounter.encounterName);

            BattleData.Instance.selectedEncounter = selectedEncounter;
            BattleData.Instance.playerParty = playerParty;

            SceneManager.LoadScene("BattleScene");
        }
        else
        {
            Debug.LogWarning("Selected encounter or player party is null");
        }
    }

    // Function to shuffle a list
    private void Shuffle<T>(List<T> list)
    {
        int n = list.Count;
        while (n > 1)
        {
            n--;
            int k = UnityEngine.Random.Range(0, n + 1);
            T value = list[k];
            list[k] = list[n];
            list[n] = value;
        }
    }
}
