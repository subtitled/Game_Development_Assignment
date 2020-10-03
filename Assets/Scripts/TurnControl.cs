using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnControl : MonoBehaviour
{
    // FSM state values.
    public enum FSMturn
    {
        None,
        Wait,
        Activate,
        EndTurn,
        Victory,
        Defeat
    }
    // FSM switch.
    public FSMturn currState;
    
    // Import Map objects.
    public GameObject[] mapObjects;
    public GameObject spawnPoints;
    public GameObject enemySpawns;
    
    // Import characters.
    public GameObject[] enemyCharacters;
    public GameObject[] playerCharacters;
    private List<GameObject> initiativeOrder = new List<GameObject>();
    
    // Game state values.
    private int turnCount = 0;
    private bool activated;
    private int characterOrder = 0;
    private GameObject activeCharacter;
    
    // Death tally.
    private int playersSlain = 0;
    private int enemiesSlain = 0;
    
    // Experience Point collectors.
    public int victoryBonus = 150;
    private int totalScore = 0;
    private int player1XP = 0;
    private int player2XP = 0;
    private int player3XP = 0;
    private int player4XP = 0;
    private int player5XP = 0;

    // Loss and Victory UI
    public GameObject lossUI;
    public GameObject victoryUI;
    
    
    // Start is called before the first frame update
    void Start()
    {
        
        spawnPoints = GameObject.Find("spawnPoints");
        spawnPoints.GetComponent<spawning>().PlayerSpawn();
        enemySpawns = GameObject.Find("enemySpawns");
        enemySpawns.GetComponent<enemySpawning>().enemySpawn();
        

        // Imports player and enemy characters.
        enemyCharacters = GameObject.FindGameObjectsWithTag("Enemy");
        playerCharacters = GameObject.FindGameObjectsWithTag("Player");
        
        
        // For randomised spawn placements
        // Prevents a spawn point being used twice.
        //HashSet<int> usedSpawns = new HashSet<int>();
        
        //For random placement of interactable objects at randomised points.
        /*
        foreach (GameObject placeable in mapObjects)
        {
            while(true)
            {
                int spawnPosition = Random.Range(0, spawnPoints.Length);
                if (!usedSpawns.Contains(spawnPosition))
                {
                    placeable.transform.position = spawnPoints[spawnPosition].transform.position;
                    usedSpawns.Add(spawnPosition);
                    break;
                }
            }
        } 
        */
        
        if (enemyCharacters.Length > 0)
        {
            foreach (GameObject character in enemyCharacters)
            {
                // Get and randomise enemy initiative, add to initiativeOrder for ordering.
                character.gameObject.GetComponent<enemyFSM>().turnInitiative =
                    character.gameObject.GetComponent<enemyFSM>().baseInitiative * Random.Range(0.7f, 1.3f);
                initiativeOrder.Add(character);

                // For random placement of enemies across designated points.
                /*while(true)
                {
                    int spawnPosition = Random.Range(0, spawnPoints.Length);
                    if (!usedSpawns.Contains(spawnPosition))
                    {
                        character.transform.position = spawnPoints[spawnPosition].transform.position;
                        usedSpawns.Add(spawnPosition);
                        break;
                    }
                }*/
            }
        }
        
        if (playerCharacters.Length > 0)
        {
            foreach (GameObject character in playerCharacters)
            {

                // Get character initiative, add to initiativeOrder for ordering.
                //character.gameObject.GetComponent<classScript>().turnInitiative = 
                //character.gameObject.GetComponent<classScript>().baseInitiative * Random.Range(0.7f, 1.3f);
                initiativeOrder.Add(character);

            }
        }
        
        // Sorts initiativeOrder by ascending initiative values.
        if (initiativeOrder.Count > 0)
        {
            initiativeOrder.Sort(delegate(GameObject o, GameObject o1)
            {
                float oInit = 0f;
                float o1Init = 0f;
                
                // Confirms if enemy or player.
                if (o.CompareTag("Enemy"))
                {
                    oInit += o.GetComponent<enemyFSM>().turnInitiative;
                }
                else if (o.CompareTag("Player"))
                {
                    oInit += o.GetComponent<classScript>().initiative;
                }
                
                // Confirms if enemy or player.
                if (o1.CompareTag("Enemy"))
                {
                    o1Init += o1.GetComponent<enemyFSM>().turnInitiative;
                }
                else if (o1.CompareTag("Player"))
                {
                    o1Init += o1.GetComponent<classScript>().initiative;
                }
                
                return (oInit.CompareTo(o1Init));
            });
            // Reverses order, so highest initiatives first.
            initiativeOrder.Reverse();
        }
        
        // Sets initial FSM state.
        turnCount = 1;
        // DEBUG for game start
        //print("Start Turn " + turnCount);
        currState = FSMturn.Wait;

    }

    // Update is called once per frame
    void Update()
    {
        // FSM switch.
        switch (currState)
        {
            case FSMturn.Wait: UpdateWaitState(); break;
            case FSMturn.Activate: UpdateActivateState(); break;
            case FSMturn.EndTurn: UpdateEndTurnState(); break;
            case FSMturn.Victory: UpdateVictoryState(); break;
            case FSMturn.Defeat: UpdateDefeatState(); break;

        }
        
    }

    protected void UpdateWaitState()
    {
        // Holding state for TurnControl FSM while an activated character takes its turn.
        // Ends when signalled by receiver.
        if (!activated)
        {

            // Checks if all characters have had their turn.
            if (characterOrder >= initiativeOrder.Count)
            {
                currState = FSMturn.EndTurn;
            }
            
            currState = FSMturn.Activate;
        }
        
    }

    protected void UpdateActivateState()
    {
        // State to activate the next character in the initiative order to take its turn.
        
        // Sends to the wait state while a character is active.
        if (activated)
        {
            currState = FSMturn.Wait;
        }
        
        // Determines and activates the next character.
        if (!activated)
        {
            // Checks if all characters have had their turn.
            if (characterOrder >= initiativeOrder.Count)
            {
                currState = FSMturn.EndTurn;
            }
            
            // Retrieves and activates the next character.
            if (characterOrder < initiativeOrder.Count)
            {
                // DEBUG for character activation.
                //print("Activating " + initiativeOrder[characterOrder].name);
                initiativeOrder[characterOrder].SendMessage("ApplyActiveStatus", true);
                activated = true;
                activeCharacter = initiativeOrder[characterOrder];
                characterOrder += 1;
                currState = FSMturn.Wait;
                //code to show UI when unit's turn
                if (activeCharacter.CompareTag("Player"))
                {
                    activeCharacter.GetComponent<classScript>().classUI.gameObject.SetActive(true);
                }
                else if (activeCharacter.CompareTag("Enemy"))
                {
                    activeCharacter.GetComponent<enemyClassScript>().enemyUI.gameObject.SetActive(true);
                }
            }
            
        }
        
    }

    protected void UpdateEndTurnState()
    {
        // Turn End state.
        
        if (activated)
        {
            currState = FSMturn.Wait;

        }
        
        // Increments or resets values.
        characterOrder = 0;
        turnCount += 1;
        currState = FSMturn.Wait;
        // DEBUG for turn end.
        //print("Start Turn " + turnCount);

        // UI End Turn and Turn Start Effects.
        //code needs to be fixed to hide at end of turn
        if (activeCharacter.CompareTag("Player"))
        {
            activeCharacter.GetComponent<classScript>().classUI.gameObject.SetActive(false);
        }
        else if (activeCharacter.CompareTag("Enemy"))
        {
            activeCharacter.GetComponent<enemyClassScript>().enemyUI.gameObject.SetActive(false);
        }

    }

    protected void UpdateVictoryState()
    {
        // Victory UI effects
        victoryUI.gameObject.SetActive(true);
        
        // Distribute victory bonus and calculate total scores.
        player1XP += victoryBonus;
        player2XP += victoryBonus;
        player3XP += victoryBonus;
        player4XP += victoryBonus;
        player5XP += victoryBonus;
        totalScore = player1XP + player2XP + player3XP + player4XP + player5XP;

    }

    protected void UpdateDefeatState()
    {
        // Defeat UI effects
        lossUI.gameObject.SetActive(true);

        // No victory bonus, calculate total score.
        totalScore = player1XP + player2XP + player3XP + player4XP + player5XP;
        
    }

    void ApplyXP(int addXP)
    {
        // Receiver to apply earned XP to the player character on a kill/action.
        if (activeCharacter.CompareTag("Player"))
        {
            switch (activeCharacter.GetComponent<classScript>().unitNum)
            {
                case 0:
                    player1XP += addXP;
                    break;
                case 1:
                    player2XP += addXP;
                    break;
                case 2:
                    player3XP += addXP;
                    break;
                case 3:
                    player4XP += addXP;
                    break;
                case 4:
                    player5XP += addXP;
                    break;
            }
        }
    }
    
    void ApplyActiveStatus(bool message)
    {
        // Receiver to toggle active status at the end of a characters turn.
        activated = message;
    }
    
    void ApplyPlayerSlain()
    {
        // Reciever to count players slain and check defeat condition.
        playersSlain += 1;
        if (playersSlain >= playerCharacters.Length)
        {
            currState = FSMturn.Defeat;
        }
            
    }
    
    void ApplyEnemySlain()
    {
        // Reciever to count enemies slain and check victory condition.
        enemiesSlain += 1;
        if (enemiesSlain >= enemyCharacters.Length)
        {
            currState = FSMturn.Victory;
        }
    }
    
}