using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElementaryActions : MonoBehaviour
{

    //Move the character by one case
    public void moveCharacterBy1(Vector2 actionDirection, GameObject character)
    {
        PlayerController playerController = character.GetComponent<PlayerController>();
        playerController.move(new Vector3(actionDirection.x, actionDirection.y , 0));
    }

    //Wait for one step
    public void wait(GameObject character)
    {
        //do nothing
    }

    public void killCharacter(GameObject character)
    {
        PlayerController playerController = character.GetComponent<PlayerController>();
        playerController.die();
    }
}
