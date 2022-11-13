using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "New Action Card")] //so we can create a new ActionCard through the asset create menu
public class ActionCard : ScriptableObject
{
    public string title;
    public string description;
    // the card has a direction or not
    public bool hasDirection;
    public int actionDuration;
    public int remainingDuration;
    public Sprite icone;
    

    public string actionName;
    public Vector2 actionDirection = new Vector2(1, 0);

    public void Awake()
    {
        remainingDuration = actionDuration;
    }

    public GameObject instanciateFromPrefab(GameObject prefab)
    {
        GameObject cardActionInstance = GameObject.Instantiate(prefab, Vector3.zero, Quaternion.identity);
        cardActionInstance.GetComponent<ActionCardDisplay>().actionCard = this;
        return cardActionInstance;
    }

}
