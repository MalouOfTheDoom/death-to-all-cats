using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Actions : MonoBehaviour
{
    public UnityEvent FunctionsToCall;
    public void playAction(string actionName, Vector2 actionDirection, GameObject character)
    {
        switch(actionName)
        {
            case "moveCharacter":
                _moveCharacter(actionDirection, character);
                return;
            default:
                Debug.Log("actionName not found");
                    break;
        }
    }

    private void _moveCharacter(Vector2 actionDirection, GameObject character)
    {
        PlayerController playerController = character.GetComponent<PlayerController>();
        playerController.move(new Vector3(actionDirection.x, actionDirection.y , 0));
    }
    public void moveCharacter(Vector2 actionDirection, GameObject character)
    {
        PlayerController playerController = character.GetComponent<PlayerController>();
        playerController.move(new Vector3(actionDirection.x, actionDirection.y , 0));
    }
}
