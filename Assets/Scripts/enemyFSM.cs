using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;

public class enemyFSM : MonoBehaviour
{
    // FSM state values.
    public enum FSMstate
    {
        None,
        Wait,
        Moving,
        Idle,
        Alert,
        Engaged,
        Dead
    }
    // FSM switch.
    public FSMstate currState;
    
    // FSM Activity status.
    private bool active = false;
    public bool dead = false;
    public bool action = false;
    public bool move = false;
    
    // Character base values.
    public int baseInitiative = 10;
    public float turnInitiative;

    public int maxHealth;
    private int currHealth;
    public int killXP;

    // Movement and detection ranges.
    public float alertRange = 18.0f;
    public float engagedRange = 12.0f;
    public float movementRange = 6.0f;
    private float moveDistance;
    // Movement speed/turn attributes assigned through NavMesh properties.
    
    // NavMesh and Waypoint variables.
    private NavMeshAgent nav;
    public GameObject[] patrolPoints;
    public int currentWaypoint;
    private Vector3 destination;

    // Connect to map control and players.
    private GameObject mapControl;
    private GameObject[] playerCharacters;
    
    // Allows for the players to be sorted by specific criteria.
    private List<GameObject> sortedPlayers = new List<GameObject>();
    
    
    // Start is called before the first frame update
    void Start()
    {
        // Initiate variables and connect to components.
        currHealth = maxHealth;
        nav = GetComponent<NavMeshAgent>();
        mapControl = GameObject.Find("MapControl");
        // Retrieve Player characters, build a sortable list.
        playerCharacters = GameObject.FindGameObjectsWithTag("Player");
        if (playerCharacters.Length > 0)
        {
            foreach (GameObject character in playerCharacters)
            {
                sortedPlayers.Add(character);
            }
        }
        // Assign initial patrol waypoint.
        if (patrolPoints.Length > 0)
        {
            currentWaypoint = Random.Range(0, patrolPoints.Length);
            destination = patrolPoints[currentWaypoint].gameObject.transform.position;
        }
        // Set to Wait State.
        currState = FSMstate.Wait;
    }

    // Update is called once per frame
    void Update()
    {
        // FSM switch.
        switch (currState)
        {
            case FSMstate.Wait: UpdateWaitStatus(); break;
            case FSMstate.Moving: UpdateMovingStatus(); break;
            case FSMstate.Idle: UpdateIdleStatus(); break;
            case FSMstate.Alert: UpdateAlertStatus(); break;
            case FSMstate.Engaged: UpdateEngagedStatus(); break;
            case FSMstate.Dead: UpdateDeadStatus(); break;
        }
        
    }

    protected void UpdateWaitStatus()
    {
        // Primary stand-by state between turns, Central state for recalculating activity status and states.
        
        if (dead)
        {
            currState = FSMstate.Dead;
        }
        
        // Calculates state to enter when becoming the active character.
        if (active)
        {
            
            if (move == false & action == false)
            {
                active = false;
                mapControl.SendMessage("ApplyActiveStatus", false);
            }
            
            // Check if player characters are within range thresholds.
            foreach (GameObject character in playerCharacters)
            {
                if (Vector3.Distance(transform.position, character.transform.position) <= engagedRange)
                {
                    currState = FSMstate.Engaged;
                    break;
                    // If a character is within the Engaged range, end loop to transition immediately.
                } 
                if (Vector3.Distance(transform.position, character.transform.position) <= alertRange)
                {
                    currState = FSMstate.Alert;
                    // If a character is within the Alert range, do not end loop.
                    // Keep loop to check if a later character is within the engaged radius.
                    
                }
            }
            // If no characters are with in the Engaged or Alert Range, transition to the Idling state.
            if (currState == FSMstate.Wait)
            {
                currState = FSMstate.Idle;
            }

        }
    }

    protected void UpdateMovingStatus()
    {
        // Dedicated Moving State, so the AI cannot also make an action at the same time.
        
        // Enable NavMesh interactions to set destination.
        nav.enabled = true;
        nav.isStopped = false;
        nav.SetDestination(destination);
        
        // Limits movement to within the movement range.
        moveDistance = moveDistance - (nav.speed * Time.deltaTime);
        
        // Checks to see if the movement range has been reached, or at the destination.
        if (moveDistance <= 0.0f | Vector3.Distance(transform.position, destination) <= 1f)
        {
            nav.isStopped = true;
            nav.enabled = false;
            move = false;
            currState = FSMstate.Wait;
            // Transition to the Wait state to recalculate distances to players.
        }
    }

    protected void UpdateIdleStatus()
    {
        // Patrolling state.
        
        // DEBUG for state changes.
        //print(name + " idle.");
        if (dead)
        {
            currState = FSMstate.Dead;
        }
        
        // Checks if the character has any actions or movements to make, ends turn if none.
        if (move == false & action == false)
        {
            active = false;
            mapControl.SendMessage("ApplyActiveStatus", false);
            currState = FSMstate.Wait;
        }
        
        // NavMesh destination logic finding.
        if (move)
        {
            // Determines next waypoint if current way point has been reached.
            if (Vector3.Distance(transform.position, destination) <= 1f)
            {
                currentWaypoint = Random.Range(0, patrolPoints.Length);
                destination = patrolPoints[currentWaypoint].gameObject.transform.position;
            }
            // DEBUG for state changes.
            //print(name + " moving.");
            currState = FSMstate.Moving;
        }
        
        // Does not utilise actions if no players are nearby.
        action = false;
    }

    protected void UpdateAlertStatus()
    {
        // State for approaching the players, but not in attack or ability usage range.
        
        // DEBUG for state changes.
        //print(name + " alert.");
        if (dead)
        {
            currState = FSMstate.Dead;
        }
        
        // Checks if the character has any actions or movements to make, ends turn if none.
        if (move == false & action == false)
        {
            active = false;
            mapControl.SendMessage("ApplyActiveStatus", false);
            currState = FSMstate.Wait;
        }
        
        // NavMesh destination logic finding.
        if (move)
        {
            // Determines order of players by proximity.
            sortedPlayers.Sort(delegate(GameObject o, GameObject o1)
            {
                return (((transform.position - o.transform.position).sqrMagnitude).CompareTo((transform.position - o1.transform.position).sqrMagnitude));
            });

            // Sets target to nearest living player.
            foreach (GameObject character in sortedPlayers)
            {
                if (!character.GetComponent<classScript>().dead)
                {
                    destination = character.transform.position;
                    break;
                }
            }
            
            // DEBUG for state changes.
            //print(name + " moving.");
            currState = FSMstate.Moving;
        }
        
        // Does not utilise actions if no players are in range.
        action = false;
    }

    protected void UpdateEngagedStatus()
    {
        // State for when actively engaged in combat.
        
        // DEBUG for state changes.
        //print(name + " engaged.");
        if (dead)
        {
            currState = FSMstate.Dead;
        }
        
        // Checks if the character has any actions or movements to make, ends turn if none.
        if (move == false & action == false)
        {
            active = false;
            mapControl.SendMessage("ApplyActiveStatus", false);
            currState = FSMstate.Wait;
        }
        
        // NavMesh destination logic finding.
        if (move)
        {
            // Determines order of players by proximity.
            sortedPlayers.Sort(delegate(GameObject o, GameObject o1)
            {
                return (((transform.position - o.transform.position).sqrMagnitude).CompareTo((transform.position - o1.transform.position).sqrMagnitude));
            });

            // Sets target to nearest living player.
            foreach (GameObject character in sortedPlayers)
            {
                if (!character.GetComponent<classScript>().dead)
                {
                    destination = character.transform.position;
                    break;
                }
            }
            
            // DEBUG for state changes.
            //print(name + " moving.");
            currState = FSMstate.Moving;
        }
        
        /*
         * Action Logic
         * Customised for individual enemy types, performing and action makes
         * "action = false" to be within the chosen action function. 
         */
        action = false;
    }
    
    protected void UpdateDeadStatus()
    {
        // It's dead.
        
        if (active)
        {
            // Immediately ends its turn if activated.
            active = false;
            mapControl.SendMessage("ApplyActiveStatus", false);
        }
    }
    
    void ApplyActiveStatus(bool message)
    {
        // Receiver to activate character on its turn.
        
        if (message)
        {
            // Toggles active and refreshes action and movement.
            active = true;
            action = true;
            move = true;
            moveDistance = movementRange;
            // DEBUG for activation.
            //print(name + " activated");
        }
    }

    void ApplyDamage(int damage)
    {
        // Reciever for damage taken.
        
        currHealth -= damage;
        
        // Death check.
        if (currHealth <= 0)
        {
            /*
             * DEATH EFFECTS
             * UI, Visual, Transformative.
            */
            
            // Disables character functions.
            mapControl.SendMessage("ApplyXP", killXP);
            mapControl.SendMessage("ApplyEnemySlain");
            nav.isStopped = true;
            nav.enabled = false;
            dead = true;
            currState = FSMstate.Dead;
        }
    }

    private void OnDrawGizmos()
    {
        // DEBUG for range thresholds.
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, alertRange);
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, engagedRange);
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, movementRange);
        
    }
}
