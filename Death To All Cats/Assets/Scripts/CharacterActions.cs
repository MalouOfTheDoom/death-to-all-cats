using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterActions : MonoBehaviour
{
    PlayerController playerController;

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

    public void addActionCard(GameObject actionCard)
    {
        // ActionCard becomes a child of ActionsDeck
        actionCard.transform.SetParent(transform);

        // For some reason, the actionCard gets a scale of (2, 2, 2) when setting its parent to the ActionsDeck
        // so we reset it here.
        actionCard.transform.localScale = new Vector3(1,1,1); 

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
