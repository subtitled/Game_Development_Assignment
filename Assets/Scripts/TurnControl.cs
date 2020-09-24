using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnControl : MonoBehaviour
{
    //Turn Control FSM AI
    public enum FSMturn
    {
        None,
        Wait,
        Activate,
        EndTurn,
        Victory,
        Defeat
    }
    
    public FSMturn currState;
    
    // Import Map-based values.
    public GameObject[] mapObjects;
    public GameObject[] spawnPoints;
    // public DATA_TYPE navigationMechanism;
    private int turnCount = 0;
    
    // Experience Point collectors.
    private int generalXP = 0;
    private int class1XP = 0;
    private int class2XP = 0;
    private int class3XP = 0;
    private int class4XP = 0;
    private int class5XP = 0;
    
    // Character listings.
    private GameObject[] enemyCharacters;
    private GameObject[] playerCharacters;
    private List<GameObject> initiativeOrder;
    private bool activeCharacter = false;
    private int characterOrder = 0;

    private int playersSlain = 0;
    private int enemiesSlain = 0;
    

    // Start is called before the first frame update
    void Start()
    {
        enemyCharacters = GameObject.FindGameObjectsWithTag("Enemy");
        playerCharacters = GameObject.FindGameObjectsWithTag("Player");
        HashSet<int> usedSpawns = new HashSet<int>();
        
        //For random placement of objects at across designated points.
        foreach (var placeable in mapObjects)
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
        
        
        foreach (var character in enemyCharacters)
        {
            // Get and randomise initiative, add to initiativeOrder.
            character.gameObject.GetComponent<enemyFSM>().turnInitiative = 
                character.gameObject.GetComponent<enemyFSM>().baseInitiative * Random.Range(0.7f, 1.3f); 
            initiativeOrder.Add(character);
            
            // For random placement of enemies across designated points.
            while(true)
            {
                int spawnPosition = Random.Range(0, spawnPoints.Length);
                if (!usedSpawns.Contains(spawnPosition))
                {
                    character.transform.position = spawnPoints[spawnPosition].transform.position;
                    usedSpawns.Add(spawnPosition);
                    break;
                }
            }
        }

        foreach (var character in playerCharacters)
        { 
            // Need to add the initiative to the classScript, or from a common basic values script.
            
            // Get and randomise initiative, add to initiativeOrder.
            //character.gameObject.GetComponent<classScript>().turnInitiative = 
                //character.gameObject.GetComponent<classScript>().baseInitiative * Random.Range(0.7f, 1.3f);
            //initiativeOrder.Add(character);
            
        }
        
        // Sort initiativeOrder by initiative values
        // Can only compare from specified components,
        // Either use an if() to differentiate by tag, or have a common script containing variable.
        
        if (initiativeOrder.Count > 0)
        {
            initiativeOrder.Sort(delegate(GameObject o, GameObject o1)
            {
                return (o.GetComponent<enemyFSM>().turnInitiative).CompareTo(o1.GetComponent<enemyFSM>()
                    .turnInitiative);
            });
        }
        
        
        /*
         * Player Character Placement Phase
         * Highly UI related.
         * Maybe just make these in a fixed position?
        */
        
        turnCount = 1;
        currState = FSMturn.Wait;

    }

    // Update is called once per frame
    void Update()
    {
        switch (currState)
        {
            case FSMturn.Wait: UpdateWaitState(); break;
            case FSMturn.Activate: UpdateActivateState(); break;
            case FSMturn.EndTurn: UpdateEndTurnState(); break;
            case FSMturn.Victory: UpdateVictoryState(); break;
            case FSMturn.Defeat: UpdateDefeatState(); break;

        }
        /*
         *FSM
         *
         * if activeCharacter == true
         *     waitFSM
         * if activeCharacter == false & characterOrder < initiativeOrder.Length
         *     activateFSM
         *         send activation message
         *         characterOrder += 1
         *         activeCharacter = true
         * if characterOrder == initiativeOrder.Length
         *     endturnFSM
         *         characterOrder = 0
         *         turnCount += 1
         *
         * Forced states, may need to put at start?
         *     victoryFSM
         *     defeatFSM
         * 
         * reciever function to flip activeCharacter from true to false
         * receiver function to add dead characters to a list
         *     function checks if all of one side are in the list
         *     force state change to victory/defeat if true.
         */
    }

    protected void UpdateWaitState()
    {
        if (activeCharacter == false)
        {
            if (characterOrder >= initiativeOrder.Count)
            {
                currState = FSMturn.EndTurn;
            }
            
            currState = FSMturn.Activate;
        }
        
    }

    protected void UpdateActivateState()
    {
        if (activeCharacter == true)
        {
            currState = FSMturn.Wait;
        }
        
        if (activeCharacter == false)
        {
            if (characterOrder >= initiativeOrder.Count)
            {
                currState = FSMturn.EndTurn;
            }

            if (characterOrder < initiativeOrder.Count)
            {
                initiativeOrder[characterOrder].SendMessage("ApplyActiveStatus", true);
                activeCharacter = true;
                characterOrder += 1;
                currState = FSMturn.Wait;
            }
            
        }
        
    }

    protected void UpdateEndTurnState()
    {
        if (activeCharacter == true)
        {
            currState = FSMturn.Wait;
        }
        
        characterOrder = 0;
        turnCount += 1;
        
        // UI End Turn and Turn Start Effects.
        
    }

    protected void UpdateVictoryState()
    {
        // Victory UI effects
        

        // Bonus XP for victory?
        generalXP += 300;
        
        // Method of determining which classes are present, and dividing only among them?
        class1XP += generalXP / 5;
        class2XP += generalXP / 5;
        class3XP += generalXP / 5;
        class4XP += generalXP / 5;
        class5XP += generalXP / 5;

    }

    protected void UpdateDefeatState()
    {
        // Defeat UI effects
        
        
        // No bonus XP?
        // Method of determining which classes are present, and dividing only among them?
        class1XP += generalXP / 5;
        class2XP += generalXP / 5;
        class3XP += generalXP / 5;
        class4XP += generalXP / 5;
        class5XP += generalXP / 5;
    }

    void ApplyGeneralXP(int addXP)
    {
        generalXP += addXP;
    }
    
    void ApplyClassXP(int classNo, int addXP)
    // SendMessage can only contain 1 variable, but it can be a list/array...
    {
        switch (classNo)
        {
            case 1: class1XP += addXP; break;
            case 2: class2XP += addXP; break;
            case 3: class3XP += addXP; break;
            case 4: class4XP += addXP; break;
            case 5: class5XP += addXP; break;
        }
    }
    
    void ApplyClass1XP(int addXP)
    {
        class1XP += addXP;
    }

    void ApplyClass2XP(int addXP)
    {
        class2XP += addXP;
    }

    void ApplyClass3XP(int addXP)
    {
        class3XP += addXP;
    }

    void ApplyClass4XP(int addXP)
    {
        class4XP += addXP;
    }

    void ApplyClass5XP(int addXP)
    {
        class5XP += addXP;
    }

    void ApplyActiveStatus(bool message)
    {
        activeCharacter = message;
    }
    
    void ApplyPlayerSlain()
    {
        playersSlain += 1;
        if (playersSlain >= playerCharacters.Length)
        {
            currState = FSMturn.Defeat;
        }
            
    }
    
    void ApplyEnemySlain()
    {
        enemiesSlain += 1;
        if (enemiesSlain >= enemyCharacters.Length)
        {
            currState = FSMturn.Victory;
        }
    }
    
    

/*
Pseudocoding:

Map level controller:
START
    Transition in from SETUP
    Obtain waypoints
    Obtain random features
    Obtain creatures, create list
    Obtain players, create list
    Place random features
    Place creatures
    Determine initiative of each (value +/- randomiser)
    Order the initiative list
    Turn = 0
    Enable player placement in predetermined area
    On placement finish, enter turn mode
TURN
    Turn += 1
    For character (Active creature/player) in initiative:
        PLAYER/CREATURE ACTIONS
        Receive messages from killed characters, store in killed list, experience tally += value
            If no more live creatures - Victory
            If no more live players - Defeat
    Clean up, remove killed characters from initiative list
    Next turn 
END
    Message out total experience, class experience
    Transition out to RESULTS
 
*/
}