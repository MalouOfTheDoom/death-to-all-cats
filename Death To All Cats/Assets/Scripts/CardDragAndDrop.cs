using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CardDragAndDrop : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    public Image image;
    [HideInInspector] public Transform parentAfterDrag;
    [HideInInspector] public Transform parentAfterWrongDrag;
    public bool firstTime = true;


    public void OnBeginDrag(PointerEventData eventData)
    {
        if(firstTime){
            
            parentAfterWrongDrag = transform.parent;
            firstTime = false;
        }
        parentAfterDrag = parentAfterWrongDrag;

        Debug.Log("OnBeginDrag");
        transform.SetParent(transform.parent.parent);
        transform.SetAsLastSibling();
        image.raycastTarget = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        Debug.Log("OnDrag");
        transform.position = Input.mousePosition;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        Debug.Log("OnEndDrag");
        Debug.Log(parentAfterDrag);
        transform.SetParent(parentAfterDrag);
        image.raycastTarget = true;

    }


}
