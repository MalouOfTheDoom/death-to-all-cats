using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public ActionsManager actionsManager;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartCycle()
    {
        //GameObject[] characters = GameObject.FindGameObjectsWithTag("Character");

        //foreach (GameObject character in characters)
        //{
        //    CharacterActions characterActions = character.GetComponentInChildren<CharacterActions>();
        //    characterActions.playNextActionCard();
        //}

        actionsManager.StartCycle();
    }
}
