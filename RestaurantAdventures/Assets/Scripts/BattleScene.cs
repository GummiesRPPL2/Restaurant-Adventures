using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleScene : MonoBehaviour
{

    public PartySO playerParty;

    // Start is called before the first frame update
    void Start()
    {
        // Retrieve selected encounter and player party Scriptable Object references
        string selectedEncounterName = PlayerPrefs.GetString("SelectedEncounter");
        string playerPartyName = PlayerPrefs.GetString("PlayerParty");

        // Load the party Scriptable Object based on its name
        playerParty = Resources.Load<PartySO>("Parties/" + playerPartyName);

        // Use the player party to access character Scriptable Objects in the battle
    }
}

