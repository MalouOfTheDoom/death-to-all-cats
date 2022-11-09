using System.Collections;
using System.Collections.Generic;
using System.Linq;
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
                isCycleStarted = false;
                //TODO: gameOver function
                yield break;
            }

            bool[] emptyDecks = new bool[characters.Length]; //for each character, indicates if its characterActions has no action left
            int index = 0;
            foreach (GameObject character in characters)
            {
                CharacterActions characterActions = character.GetComponentInChildren<CharacterActions>();
                characterActions.playNextActionCard();

                emptyDecks[index] = (characterActions.numberOfActionCards <= 0);

                index += 1;
            }

            //when all characters have played one step, we check if all decks are empty
            allDecksAreConsumed = (emptyDecks.All(x => x)); //check if all bool in emptyDecks are true

            //Wait for 1 seconds
            yield return new WaitForSeconds(1);
        }
    }

    public void StartCycle()
    {
        if (isCycleStarted) { return; }
        isCycleStarted = true;
        StartCoroutine(_updateCycle());
    }


}
