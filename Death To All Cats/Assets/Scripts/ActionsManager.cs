using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionsManager : MonoBehaviour
{
    public List<ActionCard> allActionCards;
    public List<GameObject> allActionCardsInstances;
    public ActionsDeck actionsDeck;

    public GameObject actionCardPrefab;

    // Start is called before the first frame update
    void Start()
    {
        this.allActionCardsInstances = instanciateAllActionCards(allActionCards);
        actionsDeck.addActionCards(allActionCardsInstances);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //Instanciate all the Action Cards by using a prefab and applying an actionCard ScriptableObject to each one.
    private List<GameObject> instanciateAllActionCards(List<ActionCard> allActionCards)
    {
        List<GameObject> instanciatedObjects = new List<GameObject>();

        foreach (ActionCard actionCard in allActionCards)
        {
            GameObject cardActionInstance = GameObject.Instantiate(actionCardPrefab, Vector3.zero, Quaternion.identity);
            cardActionInstance.GetComponent<ActionCardDisplay>().actionCard = allActionCards[0];
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

}
