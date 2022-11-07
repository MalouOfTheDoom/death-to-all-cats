using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionsDeck : MonoBehaviour
{

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

    
}
