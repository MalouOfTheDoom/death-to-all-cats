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

    public ActionsDeck actionsDeck; 


    public void OnBeginDrag(PointerEventData eventData)
    {
        if(firstTime){
            
            parentAfterWrongDrag = transform.parent;
            firstTime = false;
        }
        parentAfterDrag = parentAfterWrongDrag;
        transform.SetParent(transform.parent.parent);
        transform.SetAsLastSibling();
        image.raycastTarget = false;
        GetComponent<ActionCardDisplay>().maximize();
        transform.localScale = new Vector3(0.5f,0.5f,0.5f);



    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = Input.mousePosition;
        transform.localScale = new Vector3(0.5f,0.5f,0.5f);
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        transform.SetParent(parentAfterDrag);
        image.raycastTarget = true;
        transform.localScale = new Vector3(1f,1f,1f);

    }


}