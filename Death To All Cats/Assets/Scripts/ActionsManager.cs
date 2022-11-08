using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionsManager : MonoBehaviour
{
    public List<ActionCard> allActionCards;
    public List<GameObject> allActionCardsInstances;
    public ActionsDeck actionsDeck;

    public GameObject actionCardPrefab;
    public GameObject minimizedActionCardPrefab;

    // Start is called before the first frame update
    void Start()
    {
        this.allActionCardsInstances = instanciateAllActionCards(allActionCards);
        actionsDeck.addActionCards(allActionCardsInstances);
    }

    //Instanciate all the Action Cards by using a prefab and applying an actionCard ScriptableObject to each one.
    private List<GameObject> instanciateAllActionCards(List<ActionCard> allActionCards)
    {
        List<GameObject> instanciatedObjects = new List<GameObject>();

        foreach (ActionCard actionCard in allActionCards)
        {
            GameObject cardActionInstance = actionCard.instanciateFromPrefab(actionCardPrefab);
            instanciatedObjects.Add(cardActionInstance);
        }

        return instanciatedObjects;
    }

    public void StartCycle()
    {
        GameObject[] characters = GameObject.FindGameObjectsWithTag("Character");

        foreach (GameObject character in characters)
        {
            CharacterActions characterActions = character.GetComponentInChildren<CharacterActions>();
            characterActions.playNextActionCard();
        }

    }

    public void temporaryAddCard(int index=0) //this function is temporary and should be rewrited 
    {
        //get the actionCard from the actionsDeck
        GameObject actionCardToMove = actionsDeck.GetActionCardByIndex(index);

        if (!actionCardToMove) { return; }

        //add the actionCard to the characterActions
        GameObject[] characters = GameObject.FindGameObjectsWithTag("Character");
        GameObject character = characters[0];
        CharacterActions characterActions = character.GetComponentInChildren<CharacterActions>();
        characterActions.addActionCard(actionCardToMove);
    }

}
