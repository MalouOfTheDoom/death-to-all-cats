using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Action Card")] //so we can create a new ActionCard through the asset create menu
public class ActionCard : ScriptableObject
{
    public string title;
    public string description;

    public int actionDuration;
    public int remainingDuration;

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
