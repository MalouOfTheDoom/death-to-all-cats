using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Actions : MonoBehaviour
{

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
}
