using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using System.Linq;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public ActionsManager actionsManager;

    public bool isCycleStarted;
    public bool allCharactersAreDead;
    public bool allDecksAreConsumed;

    public GameOverScreen gameOverScreen;
    public GameWonScreen gameWonScreen;

    private GameObject[] characters;

    // Start is called before the first frame update
    void Start()
    {
        isCycleStarted = false;
        allCharactersAreDead = false;
        allDecksAreConsumed = false;

        characters = GameObject.FindGameObjectsWithTag("Character");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //Run one step of the cycle
    IEnumerator _updateCycle()
    {
        int i = 0;
        while(true)
        {
            i += 1;
            if (i >= 100) { Debug.Log("100 rep"); break;  }

            if (!isCycleStarted)
            {
                yield break;
            }

            if (allCharactersAreDead)
            {
                GameWon();
                yield break;
            }

            if (allDecksAreConsumed)
            {
                GameOver();
                yield break;
            }

            bool[] emptyDecks = new bool[characters.Length]; //for each character, indicates if its characterActions has no action left
            bool[] deadCharacters = new bool[characters.Length];
            int index = 0;
            foreach (GameObject character in characters)
            {
                CharacterActions characterActions = character.GetComponentInChildren<CharacterActions>();
                characterActions.playNextActionCard();

                emptyDecks[index] = (characterActions.numberOfActionCards <= 0);
                PlayerController playerController = character.GetComponent<PlayerController>();
                deadCharacters[index] = playerController.getDead();

                index += 1;
            }

            //when all characters have played one step, we check if all decks are empty
            allDecksAreConsumed = (emptyDecks.All(x => x)); //check if all bool in emptyDecks are true
            allCharactersAreDead = (deadCharacters.All(x => x));

            //Wait for 1 seconds
            yield return new WaitForSeconds(1);
        }
    }

    public void StartCycle()
    {
        if (isCycleStarted) { return; }
        isCycleStarted = true;
        StartCoroutine(_updateCycle());
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); //Load scene called Game
    }
    public void NextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void GameOver()
    {
        gameOverScreen.Setup();
    }
    public void GameWon()
    {
        gameWonScreen.Setup();
    }

    public void loadLevelSelection()
    {
        SceneManager.LoadScene("LevelSelection");
    }


}
