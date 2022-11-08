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

    public void Awake()
    {
        remainingDuration = actionDuration;
    }

}
