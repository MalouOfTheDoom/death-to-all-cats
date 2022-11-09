using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DropSlot : MonoBehaviour, IDropHandler
{

    public void OnDrop(PointerEventData eventData)
    {
        GameObject dropped = eventData.pointerDrag;
        CardDragAndDrop cardDragAndDrop = dropped.GetComponent<CardDragAndDrop>();
        cardDragAndDrop.parentAfterDrag = transform;
        cardDragAndDrop.GetComponent<ActionCardDisplay>().minimize();
        // cardDragAndDrop.transform.localScale = new Vector3(5/4*0.01f,5/4*0.01f,5/4*0.01f);
    }
}
