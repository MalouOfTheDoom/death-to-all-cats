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
        
    }

    //Run one step of the cycle
    IEnumerator _updateCycle()
    {
        int i = 0;
        while(true)
        {
            i += 1;
            if (i >= 100) { Debug.Log("100 rep"); break;  }
            if (!isCycleStarted)
            {
                yield break;
            }

            if (isGameWon)
            {
                //TODO
                yield break;
            }

            if (allDecksAreConsumed)
            {
                //TODO
                yield break;
            }

            foreach (GameObject character in characters)
            {
                CharacterActions characterActions = character.GetComponentInChildren<CharacterActions>();
                characterActions.playNextActionCard();
            }

            //Wait for 2 seconds
            yield return new WaitForSeconds(2);
        }
    }

    public void StartCycle()
    {
        isCycleStarted = true;
        StartCoroutine(_updateCycle());
    }


}
