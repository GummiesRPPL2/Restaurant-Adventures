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

    [SerializeField] int minNumberOfMonstersToEncounter = 1;
    [SerializeField] int maxNumberOfMonstersToEncounter = 4;

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
        foreach (var areaEncounterTable in areaEncounterTables)
        {
            if (areaEncounterTable.areaName == areaName)
            {
                List<EncounterSO> encounterTable = areaEncounterTable.encounterTable;
                int numberOfMonsters = UnityEngine.Random.Range(minNumberOfMonstersToEncounter, maxNumberOfMonstersToEncounter + 1);
                List<EncounterSO> selectedMonsters = SelectRandomMonsters(encounterTable, numberOfMonsters);
                StartBattleEncounter(selectedMonsters);
                return;
            }
        }

        // If no encounter table is found for the area
        Debug.LogWarning("Encounter table not found for area: " + areaName);
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
    private void StartBattleEncounter(List<EncounterSO> selectedMonsters)
    {
        if (selectedMonsters.Count > 0)
        {
            // Initiate battle encounter with the selected monsters
            // This could involve loading a battle scene or initiating a battle manager
            Debug.Log("Starting battle encounter with " + selectedMonsters.Count + " monsters.");
            // SceneManager.LoadScene("BattleScene"); // Example: Load battle scene
            // BattleManager.Instance.StartBattle(selectedMonsters); // Example: Start battle with selected monsters
        }
        else
        {
            Debug.LogWarning("No monsters selected for the encounter.");
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
