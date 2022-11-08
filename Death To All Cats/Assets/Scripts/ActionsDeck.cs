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
        // ActionCard becomes a child of ActionsDeck
        actionCard.transform.SetParent(transform);
        Debug.Log(actionCard.transform);

        //we don't forget to maximize the cardDisplay
        actionCard.GetComponent<ActionCardDisplay>().maximize();

        // For some reason, the actionCard gets a scale of (2, 2, 2) when setting its parent to the ActionsDeck
        // so we reset it here.
        actionCard.transform.localScale = new Vector3(1,1,1);
    }

    public void removeActionCard(GameObject actionCard)
    {
        Destroy(actionCard);
    }

    //public void removeActionCardByIndex(int index)
    //{
    //    //GameObject actionCard = GetComponentInChildren<GameObject>();
    //    Transform transformChild = transform.GetChild(index);
    //    GameObject actionCard = transformChild.gameObject;
    //    Destroy(actionCard);
    //}

}
