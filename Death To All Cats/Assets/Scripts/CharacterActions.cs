using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterActions : MonoBehaviour
{
    PlayerController playerController;
    public GameObject minimizedActionCardPrefab;

    public void Start()
    {
        playerController = this.GetComponentInParent<PlayerController>();
    }

    public void addActionCards(List<GameObject> actionCards)
    {
        foreach (GameObject actionCard in actionCards)
        {
            addActionCard(actionCard);
        }

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
    }



    public void removeActionCard(GameObject actionCard)
    {
        Destroy(actionCard);
    }

    private ActionCardDisplay? _getNextActionCard()
    {
        ActionCardDisplay nextActionCardDisplay = this.GetComponentInChildren<ActionCardDisplay>();

        if (!nextActionCardDisplay) { return null; } //if no next action we return null

        return nextActionCardDisplay;
    }

    public void playNextActionCard()
    {
        ActionCardDisplay? nextActionCard = _getNextActionCard();
        if (nextActionCard)
        {
            _actionMove(playerController, new Vector3(1, 0, 0));
            //nextActionCard.consumeOneDuration();
        }
    }

    private void _actionMove(PlayerController playerController, Vector3 moveVector3)
    {
        Debug.Log("moving");
        //PlayerController playerController = character.GetComponent<PlayerController>();
        playerController.move(moveVector3);
    }

}
