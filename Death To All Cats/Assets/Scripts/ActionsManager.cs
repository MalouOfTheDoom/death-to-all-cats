using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionsManager : MonoBehaviour
{
    public List<ActionCard> allActionCards;
    public List<GameObject> allActionCardsInstances;
    public ActionsDeck actionsDeck;

    public GameObject actionCardTemplate;

    // Start is called before the first frame update
    void Start()
    {
        instanciateAllActionCards(allActionCards);
        foreach(GameObject actionCard in allActionCardsInstances)
        {
            actionsDeck.addActionCard(actionCard);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void instanciateAllActionCards(List<ActionCard> allActionCards)
    {

        foreach (ActionCard actionCard in allActionCards)
        {
            GameObject cardActionInstance = GameObject.Instantiate(actionCardTemplate);
            cardActionInstance.GetComponent<ActionCardDisplay>().actionCard = allActionCards[0];
            allActionCardsInstances.Add(cardActionInstance);
        }

    }
}
