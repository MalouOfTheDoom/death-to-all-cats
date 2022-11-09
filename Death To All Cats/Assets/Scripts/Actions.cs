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
            case "moveCharacter2":
                _moveCharacter2(actionDirection, character);
                return;
            case "moveCharacter3":
                _moveCharacter3(actionDirection, character);
                return;
            case "killCharacter":
                _killCharacter(character);
                return;
            case "wait":
                _wait();
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
    private void _moveCharacter2(Vector2 actionDirection, GameObject character)
    {
        PlayerController playerController = character.GetComponent<PlayerController>();
        playerController.move(new Vector3(2*actionDirection.x, 2*actionDirection.y , 0));
    }
    private void _moveCharacter3(Vector2 actionDirection, GameObject character)
    {
        PlayerController playerController = character.GetComponent<PlayerController>();
        playerController.move(new Vector3(3*actionDirection.x, 3*actionDirection.y , 0));
    }
    private void _killCharacter(GameObject character)
    {
        PlayerController playerController = character.GetComponent<PlayerController>();
        playerController.die();
    }
    private void _wait()
    {

    }

}
