using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionsDeck : MonoBehaviour
{
    private RectTransform rectTransform;

    public void addActionCard(GameObject actionCard)
    {
        actionCard.transform.SetParent(transform);

    }
}
