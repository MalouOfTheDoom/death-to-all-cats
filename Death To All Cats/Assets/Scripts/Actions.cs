using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Actions : MonoBehaviour
{
    public UnityEvent FunctionsToCall;
    public ElementaryActions elementaryActions;

    private void Start()
    {
        elementaryActions = new ElementaryActions();
    }

    public void playAction(string actionName, Vector2 actionDirection, GameObject character, int currentStep)
    {
        switch(actionName)
        {
            case "moveCharacter":
                _moveCharacterByX(actionDirection, character, currentStep, 1);
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

    //TODO: these functions are called each step, but step creation process should only happen once (performance issues)
    private void _moveCharacterByX(Vector2 actionDirection, GameObject character, int currentStep, int x)
    {
        List<Action> steps = new List<Action>(); //we use a concept called Delegates
        for(int i=0; i<=x; i++)
        {
            steps.Add(() => elementaryActions.moveCharacterBy1(actionDirection, character));
        }

        steps[currentStep].DynamicInvoke(actionDirection, character);

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
