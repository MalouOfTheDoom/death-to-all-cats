using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public ActionsManager actionsManager;

    public bool isCycleStarted;
    public bool isGameWon;
    public bool allDecksAreConsumed;

    private GameObject[] characters;

    // Start is called before the first frame update
    void Start()
    {
        isCycleStarted = false;
        isGameWon = false;
        allDecksAreConsumed = false;

        characters = GameObject.FindGameObjectsWithTag("Character");
    }

    // Update is called once per frame
    void Update()
    {
        _updateCycle();
    }

    //Run one step of the cycle
    private void _updateCycle()
    {
        if (!isCycleStarted)
        {
            return;
        }

        if (isGameWon)
        {
            //TODO
            return;
        }

        if (allDecksAreConsumed)
        {
            //TODO
            return;
        }

        foreach (GameObject character in characters)
        {
            CharacterActions characterActions = character.GetComponentInChildren<CharacterActions>();
            characterActions.playNextActionCard();
        }
    }

    public void StartCycle()
    {
        isCycleStarted = true;
    }


}
