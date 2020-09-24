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
    private bool dead = false;
    private bool action = false;
    private bool move = false;

    public float alertRange = 50.0f;
    public float engagedRange = 35.0f;
    //public float movementRange = 10.0f;
    //public float moveSpeed = 12.0f;
    //public float rotSpeed = 4.0f;

    private GameObject mapControl;
    private GameObject[] playerCharacters;

    private NavMeshAgent nav;
    private Vector3 destination;
    
    // Start is called before the first frame update
    void Start()
    {
        currHealth = maxHealth;
        nav = GetComponent<NavMeshAgent>();
        mapControl = GameObject.Find("MapControl");
        playerCharacters = GameObject.FindGameObjectsWithTag("Player");
        currState = FSMstate.Wait;
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
            
            foreach (var character in playerCharacters)
            {
                if (Vector3.Distance(transform.position, character.transform.position) <= engagedRange)
                {
                    currState = FSMstate.Engaged;
                } 
                else if (Vector3.Distance(transform.position, character.transform.position) <= alertRange)
                {
                    currState = FSMstate.Alert;
                }
                else
                {
                    currState = FSMstate.Idle;
                }
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

        nav.SetDestination(destination);
        
        if (transform.position == destination)
        {
            currState = FSMstate.Wait;
            move = false;
        }
    }

    protected void UpdateIdleStatus()
    {
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
        // destination = Random A* grid within movementRange / 4
        //else
        if (move)
        {
            destination = transform.position;
            currState = FSMstate.Moving;
        }
        
        // So that it doesn't lock trying to use abilities with no target.
        action = false;
    }

    protected void UpdateAlertStatus()
    {
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
        // destination = A* grid within movementRange / 2 towards nearest player.
        //else
        if (move)
        {
            destination = transform.position;
            currState = FSMstate.Moving;
        }
        
        // So that it doesn't lock trying to use abilities with no target.
        action = false;
    }

    protected void UpdateEngagedStatus()
    {
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
        // destination = A* grid within movementRange. Enemy type variance for attack/ability range.
        //else
        if (move)
        {
            destination = transform.position;
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
    
}
