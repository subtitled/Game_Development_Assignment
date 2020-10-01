using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;

public class enemyFSM : MonoBehaviour
{
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

    public FSMstate currState;
    
    public int baseInitiative = 10;
    public float turnInitiative;

    public int maxHealth;
    private int currHealth;
    
    private bool active = false;
    public bool dead = false;
    public bool action = false;
    public bool move = false;

    public float alertRange = 18.0f;
    public float engagedRange = 12.0f;
    public float movementRange = 6.0f;
    private float moveDistance;
    //public float moveSpeed = 12.0f;
    //public float rotSpeed = 4.0f;

    private GameObject mapControl;
    private GameObject[] playerCharacters;
    private List<GameObject> sortedPlayers = new List<GameObject>();

    private NavMeshAgent nav;
    public GameObject[] patrolPoints;
    public int currentWaypoint;
    private Vector3 destination;
    
    
    // Start is called before the first frame update
    void Start()
    {
        currHealth = maxHealth;
        nav = GetComponent<NavMeshAgent>();
        mapControl = GameObject.Find("MapControl");
        playerCharacters = GameObject.FindGameObjectsWithTag("Player");
        if (playerCharacters.Length > 0)
        {
            foreach (GameObject character in playerCharacters)
            {
                sortedPlayers.Add(character);
            }
        }
        currState = FSMstate.Wait;
        if (patrolPoints.Length > 0)
        {
            currentWaypoint = Random.Range(0, patrolPoints.Length);
            destination = patrolPoints[currentWaypoint].gameObject.transform.position;
        }
    }

    // Update is called once per frame
    void Update()
    {
        /*
         * FSM
         * if active == false
         *     waitFSM
         * if active == true
         *     if dead == true
         *        deadFSM
         *        send message end turn
         *     if conditions
         *        activeFSM
         * 
         */
        
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
        if (dead)
        {
            currState = FSMstate.Dead;
        }
        if (active)
        {
            
            if (move == false & action == false)
            {
                active = false;
                mapControl.SendMessage("ApplyActiveStatus", false);
            }
            
            foreach (GameObject character in playerCharacters)
            {
                if (Vector3.Distance(transform.position, character.transform.position) <= engagedRange)
                {
                    currState = FSMstate.Engaged;
                    break;
                } 
                if (Vector3.Distance(transform.position, character.transform.position) <= alertRange)
                {
                    currState = FSMstate.Alert;
                }
            }

            if (currState == FSMstate.Wait)
            {
                currState = FSMstate.Idle;
            }

        }
    }

    protected void UpdateMovingStatus()
    {
        // Dedicated Moving State, so the AI cannot also make an action at the same time.
        if (dead)
        {
            currState = FSMstate.Dead;
        }
        if (move == false & action == false)
        {
            active = false;
            mapControl.SendMessage("ApplyActiveStatus", false);
        }

        nav.enabled = true;
        nav.isStopped = false;
        nav.SetDestination(destination);

        moveDistance = moveDistance - (nav.speed * Time.deltaTime);
        
        if (moveDistance <= 0.0f | Vector3.Distance(transform.position, destination) <= 1f)
        {
            nav.isStopped = true;
            nav.enabled = false;
            move = false;
            currState = FSMstate.Wait;
        }
    }

    protected void UpdateIdleStatus()
    {
        print(name + " idle.");
        if (dead)
        {
            currState = FSMstate.Dead;
        }
        if (move == false & action == false)
        {
            active = false;
            mapControl.SendMessage("ApplyActiveStatus", false);
            currState = FSMstate.Wait;
        }
        
        // Move then re-assess proximity to players.
        // NavMesh destination logic finding.
        if (move)
        {
            // Generate next waypoint if already at current
            if (Vector3.Distance(transform.position, destination) <= 1f)
            {
                currentWaypoint = Random.Range(0, patrolPoints.Length);
                destination = patrolPoints[currentWaypoint].gameObject.transform.position;
            }

            print(name + " moving.");
            currState = FSMstate.Moving;
        }
        
        // So that it doesn't lock trying to use abilities with no target.
        action = false;
    }

    protected void UpdateAlertStatus()
    {
        print(name + " alert.");
        if (dead)
        {
            currState = FSMstate.Dead;
        }
        if (move == false & action == false)
        {
            active = false;
            mapControl.SendMessage("ApplyActiveStatus", false);
            currState = FSMstate.Wait;
        }
        
        // Move then re-assess proximity to players.
        // NavMesh destination logic finding.
        if (move)
        {
            // Determine nearest 
            sortedPlayers.Sort(delegate(GameObject o, GameObject o1)
            {
                return (((transform.position - o.transform.position).sqrMagnitude).CompareTo((transform.position - o1.transform.position).sqrMagnitude));
            });

            foreach (GameObject character in sortedPlayers)
            {
                // if (!character.GetComponent<classScript>().dead)
                // {
                //     destination = character.transform.position;
                //     break;
                // }
                destination = character.transform.position;
                break;
            }
            
            print(name + " moving.");
            currState = FSMstate.Moving;
        }
        
        // So that it doesn't lock trying to use abilities with no target.
        action = false;
    }

    protected void UpdateEngagedStatus()
    {
        print(name + " engaged.");
        if (dead)
        {
            currState = FSMstate.Dead;
        }
        if (move == false & action == false)
        {
            active = false;
            mapControl.SendMessage("ApplyActiveStatus", false);
            currState = FSMstate.Wait;
        }
        
        // Move then re-assess proximity to players.
        // NavMesh destination logic finding.
        if (move)
        {
            
            sortedPlayers.Sort(delegate(GameObject o, GameObject o1)
            {
                return (((transform.position - o.transform.position).sqrMagnitude).CompareTo((transform.position - o1.transform.position).sqrMagnitude));
            });

            foreach (GameObject character in sortedPlayers)
            {
                // if (!character.GetComponent<classScript>().dead)
                // {
                //     destination = character.transform.position;
                //     break;
                // }
                destination = character.transform.position;
                break;
            }


            print(name + " moving.");
            currState = FSMstate.Moving;
        }
        /*
         * Action Logic
         * Customised for individual enemy types, performing and action makes
         */
        action = false;
    }
    
    protected void UpdateDeadStatus()
    {
        if (active == true)
        {
            active = false;
            mapControl.SendMessage("ApplyActiveStatus", false);
        }
    }
    
    void ApplyActiveStatus(bool message)
    {
        active = message;
        if (message == true)
        {
            action = true;
            move = true;
            moveDistance = movementRange;
            print(name + " activated");
        }
    }

    void ApplyDamage(int damage)
    {
        currHealth -= damage;
        if (currHealth <= 0)
        {
            // DEATH EFFECTS
            mapControl.SendMessage("ApplyEnemySlain");
            nav.isStopped = true;
            nav.enabled = false;
            dead = true;
            currState = FSMstate.Dead;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, alertRange);
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, engagedRange);
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, movementRange);
        
    }
}
