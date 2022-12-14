using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionsManager : MonoBehaviour
{
    public List<ActionCard> allActionCards;
    public List<GameObject> allActionCardsInstances;
    public ActionsDeck actionsDeck;

    public GameObject actionCardPrefab;
    public bool allDecksAreConsumed = false;

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

    public void cardFromDeckToCharacter(GameObject character, int index)
    {
        //get the actionCard from the actionsDeck
        GameObject actionCardToMove = actionsDeck.GetActionCardByIndex(index);

        if (!actionCardToMove) { return; }

        //add the actionCard to the characterActions
        CharacterActions characterActions = character.GetComponentInChildren<CharacterActions>();
        characterActions.addActionCard(actionCardToMove);
    }

    public void cardFromCharacterToDeck(GameObject character, int index)
    {
        //get the actionCard from the characterActions
        CharacterActions characterActions = character.GetComponent<PlayerController>().characterActions;
        GameObject actionCardToMove = characterActions.GetActionCardByIndex(index);

        if (!actionCardToMove) { return; }

        //add the actionCard to the characterActions
        actionsDeck.addActionCard(actionCardToMove);
    }

}
