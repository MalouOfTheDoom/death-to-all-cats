using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterActions : MonoBehaviour
{
    public GameObject character;
    public int numberOfActionCards = 0;

    public void Start()
    {
        character = GetCharacter();
        //playerController = this.GetComponentInParent<PlayerController>();
    }

    public void addActionCards(List<GameObject> actionCards)
    {
        foreach (GameObject actionCard in actionCards)
        {
            addActionCard(actionCard);
        }
    }

    public GameObject GetCharacter() //TODO: A MODIFIER C TRES MOCHE LA
    {
        //GameObject[] characters = GameObject.FindGameObjectsWithTag("Character");
        //foreach(GameObject character in characters)
        //{
        //    if (character.)
        //}
        return transform.parent.parent.parent.gameObject;
    }

    public GameObject GetActionCardByIndex(int index)
    {
        int count = 0;
        foreach (Transform child in transform)
        {
            if (count == index)
            {
                return child.transform.gameObject;
            }
            count += 1;
        }
        return null;
    }

    public void addActionCard(GameObject actionCard)
    {
        // ActionCard becomes a child of CharacterActions
        actionCard.transform.SetParent(transform);

        //we don't forget to minimize the cardDisplay
        actionCard.GetComponent<ActionCardDisplay>().minimize();

        // For some reason, the actionCard gets a scale of (2, 2, 2) when setting its parent to the ActionsDeck
        // so we reset it here.
        actionCard.transform.localScale = new Vector3(1, 1, 1);

        numberOfActionCards += 1;
    }

    public void removeActionCard(GameObject actionCard)
    {
        numberOfActionCards -= 1;
    }

    public void destroyActionCard(GameObject actionCard)
    {
        Destroy(actionCard);
        numberOfActionCards -= 1;
    }

    public void playNextActionCard()
    {
        GameObject nextActionCard = GetActionCardByIndex(0);

        if (nextActionCard)
        {
            ActionCardDisplay actionCardDisplay = nextActionCard.GetComponent<ActionCardDisplay>();

            string actionName = actionCardDisplay.actionName;
            Vector2 actionDirection = actionCardDisplay.actionDirection;

            //we get the currentStep of the card which equals inialDuration - remainingDuration
            int currentStep = actionCardDisplay.actionDuration - actionCardDisplay.remainingDuration;

            nextActionCard.GetComponent<Actions>().playAction(actionName, actionDirection, character, currentStep);
            actionCardDisplay.consumeOneDuration();

            //destroy the card if no duration left
            if (actionCardDisplay.remainingDuration <= 0)
            {
                destroyActionCard(nextActionCard);
            }
        }
    }

}
