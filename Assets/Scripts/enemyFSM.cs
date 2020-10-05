using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;
using UnityEngine.UI;

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
    public int initiative;

    public float maxHealth;
    public float currHealth;
    public int killXP;
    public int enemyClassNum;
    public bool defendStatus;
    
    // Movement and detection ranges.
    public float alertRange;
    public float engagedRange;
    public float movementRange;
    private float moveDistance;
    // Movement speed/turn attributes assigned through NavMesh properties.
    
    // NavMesh and Waypoint variables.
    private NavMeshAgent nav;
    public GameObject[] patrolPoints;
    public int currentWaypoint;
    private Vector3 destination;
    
    private float moveTimer = 6f;
    private float elapsedTime;

    // Connect to map control and characters.
    private GameObject mapControl;
    private GameObject[] playerCharacters;
    private GameObject[] enemyCharacters;
    
    // Allows for the players to be sorted by specific criteria.
    private List<GameObject> sortedPlayers = new List<GameObject>();

    // UI objects switch.
    private GameObject toggleUI;

    // Healthbar objects.
    public Image healthBar;
    float hbLength;
    float hbHeight;

    // Start is called before the first frame update
    // Start is called before the first frame update
    void Start()
    {
        // Initiate variables and connect to components.
        nav = GetComponent<NavMeshAgent>();
        mapControl = GameObject.Find("MapControl");
        patrolPoints = GameObject.FindGameObjectsWithTag("Waypoint");
        
        // Initiate and retrieve class specific values.
        GetComponent<enemyClassScript>().ClassSetUp();
        enemyClassNum = GetComponent<enemyClassScript>().enemyClassNum;
        maxHealth = GetComponent<enemyClassScript>().health;
        currHealth = maxHealth;
        initiative = GetComponent<enemyClassScript>().initiative;
        alertRange = GetComponent<enemyClassScript>().alertRange;
        engagedRange = GetComponent<enemyClassScript>().engagedRange;
        movementRange = GetComponent<enemyClassScript>().movement;
        
        // Retrieve Player characters, build a sortable list.
        playerCharacters = GameObject.FindGameObjectsWithTag("Player");
        if (playerCharacters.Length > 0)
        {
            foreach (GameObject character in playerCharacters)
            {
                sortedPlayers.Add(character);
            }
        }
        
        // Retrieve allied enemy characters
        enemyCharacters = GameObject.FindGameObjectsWithTag("Enemy");
        
        // Assign initial patrol waypoint.
        if (patrolPoints.Length > 0)
        {
            currentWaypoint = Random.Range(0, patrolPoints.Length);
            destination = patrolPoints[currentWaypoint].gameObject.transform.position;
        }
        
        // Import UI objects
        toggleUI = GetComponent<enemyClassScript>().enemyUI;
        toggleUI.SetActive(false);
        
        // Set to Wait State.
        currState = FSMstate.Wait;

        // Initiate healbar variables
        hbLength = healthBar.rectTransform.rect.width;
        hbHeight = healthBar.rectTransform.rect.height;
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
        
        if(!dead)
        {
            toggleUI.SetActive(active);
        }

        if (transform.position.y < 5f)
        {
            transform.position = transform.position + new Vector3(0f, 10f, 0f);
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
        // Timer to prevents locks from unreachable targets.
        elapsedTime += Time.deltaTime;
        
        // Checks to see if the movement range has been reached, or at the destination.
        if (moveDistance <= 0.0f | Vector3.Distance(transform.position, destination) <= 1f | elapsedTime >= moveTimer)
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
            if (Vector3.Distance(transform.position, destination) <= 1.25f | elapsedTime >= moveTimer)
            {
                currentWaypoint = Random.Range(0, patrolPoints.Length);
                destination = patrolPoints[currentWaypoint].gameObject.transform.position;
            }
            // DEBUG for state changes.
            //print(name + " moving.");
            elapsedTime = 0f;
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
            elapsedTime = 0f;
            currState = FSMstate.Moving;
        }
        
        // Defends if no players are in range.
        GetComponent<enemyClassScript>().Defend(defendStatus);
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
            elapsedTime = 0f;
            currState = FSMstate.Moving;
        }
        
        if (!move)
        {
            // DEBUG to skip turn.
            //action = false;
            EngagedAction();
        }
        
    }
    
    protected void UpdateDeadStatus()
    {
        // They're dead.
        
        if (active)
        {
            // Immediately ends its turn if activated.
            active = false;
            mapControl.SendMessage("ApplyActiveStatus", false);
        }
    }

    void EngagedAction()
    {
        /*
         * Action Logic
         * Switches for differing class types. 
         */
        
        switch (enemyClassNum)
        {
            case 0: //enemyWarrior
                if (Vector3.Distance(transform.position, sortedPlayers[2].transform.position) <= 3f)
                {
                    // If the closest three players are within range, utilise ability.
                    GetComponent<enemyClassScript>().WarriorAbility1();
                }
                if (Vector3.Distance(transform.position, sortedPlayers[0].transform.position) <= 1.25f)
                {
                    // Attacks the nearest player within melee range.
                    GetComponent<enemyClassScript>().Attack(sortedPlayers[0].transform.position);
                }
                else
                {
                    // Defends if it can't attack.
                    GetComponent<enemyClassScript>().Defend(defendStatus);
                }
                action = false;
                break;
            case 1: //enemyPriest
                foreach (GameObject ally in enemyCharacters)
                {
                    // Attempts to heal an injured allied character within range.
                    if ((ally.GetComponent<enemyFSM>().currHealth / ally.GetComponent<enemyFSM>().maxHealth) <= 0.5f & 
                        Vector3.Distance(transform.position, ally.transform.position) <= 6.0f)
                    {
                        GetComponent<enemyClassScript>().PriestAbility1(ally.transform.position);
                        break;
                    }
                }
                if (Vector3.Distance(transform.position, sortedPlayers[0].transform.position) <= 1.25f)
                {
                    // Attacks the nearest player within melee range.
                    GetComponent<enemyClassScript>().Attack(sortedPlayers[0].transform.position);
                }
                else
                {
                    // Defends if it can't attack.
                    GetComponent<enemyClassScript>().Defend(defendStatus);
                }
                action = false;
                break;
            case 2: //enemyMage
                bool attacked = false;
                for (int i = 0; i < sortedPlayers.Count; i++)
                {
                    for (int j = i+1; j < sortedPlayers.Count; j++)
                    {
                        if (Vector3.Distance(sortedPlayers[i].transform.position, sortedPlayers[j].transform.position) <= 4f)
                        {
                            if (Vector3.Distance(transform.position,(sortedPlayers[i].transform.position + (sortedPlayers[i].transform.position - sortedPlayers[j].transform.position) / 2)) <= 6f)
                            {
                                // Targets a point in range between two adjacent players.
                                GetComponent<enemyClassScript>().MageAbility1((sortedPlayers[i].transform.position + (sortedPlayers[i].transform.position -
                                        sortedPlayers[j].transform.position) / 2));
                                attacked = true;
                                break;
                            }
                        }
                    }
                    if (attacked)
                    {
                        break;
                    }
                }
                if (Vector3.Distance(transform.position, sortedPlayers[0].transform.position) <= 6f)
                {
                    // Attacks the nearest player within range.
                    GetComponent<enemyClassScript>().Attack(sortedPlayers[0].transform.position);
                }
                else
                {
                    // Defends if it can't attack.
                    GetComponent<enemyClassScript>().Defend(defendStatus);
                }
                action = false;
                break;
            case 3: //enemyRogue
                // Determines order of players by health.
                sortedPlayers.Sort(delegate(GameObject o, GameObject o1)
                {
                    return ((o.gameObject.GetComponent<classScript>().currHealth).CompareTo(o1.gameObject.GetComponent<classScript>().currHealth));
                });
                sortedPlayers.Reverse();
                foreach (GameObject player in sortedPlayers)
                {
                    if (Vector3.Distance(transform.position, player.transform.position) <= 1.25f)
                    {
                        // Targets highest health player in range.
                        GetComponent<enemyClassScript>().RogueAbility1(player.transform.position);
                        break;
                    }
                }
                
                // Determines order of players by proximity.
                sortedPlayers.Sort(delegate(GameObject o, GameObject o1)
                {
                    return (((transform.position - o.transform.position).sqrMagnitude).CompareTo((transform.position - o1.transform.position).sqrMagnitude));
                });
                if (Vector3.Distance(transform.position, sortedPlayers[0].transform.position) <= 1.25f)
                {
                    // Attacks the nearest player within melee range.
                    GetComponent<enemyClassScript>().Attack(sortedPlayers[0].transform.position);
                }
                else
                {
                    // Defends if it can't attack.
                    GetComponent<enemyClassScript>().Defend(defendStatus);
                }
                action = false;
                break;
            case 4: //enemyMarksman
                for (int i = (sortedPlayers.Count - 1); i >= 0; i--)
                {
                    if (Vector3.Distance(transform.position, sortedPlayers[i].transform.position) <= 8f)
                    {
                        // Targets farthest player in range.
                        GetComponent<enemyClassScript>().MarksmanAbility1(sortedPlayers[i].transform.position);
                        break;
                    }
                }
                if (Vector3.Distance(transform.position, sortedPlayers[0].transform.position) <= 8f)
                {
                    // Attacks the nearest player within range.
                    GetComponent<enemyClassScript>().Attack(sortedPlayers[0].transform.position);
                }
                else
                {
                    // Defends if it can't attack.
                    GetComponent<enemyClassScript>().Defend(defendStatus);
                }
                action = false;
                break;
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
            defendStatus = false;
            moveDistance = movementRange;
            // DEBUG for activation.
            //print(name + " activated");
        }
    }

    void ApplyDamage(float damage)
    {
        // Reciever for damage taken.
        
        if (!defendStatus)
        {
            // If not defending, take damage.
            currHealth -= damage;
        }
        if (defendStatus)
        {
            if (damage > 0)
            {
                // If defending, block the hit.
                defendStatus = false;
            }
            if (damage < 0)
            {
                // Allows healing if defending.
                currHealth -= damage;
                if (currHealth > maxHealth)
                {
                    currHealth = maxHealth;
                }
            }
        }

        // Change appearance of healthbar to reflect damage taken
        healthBar.rectTransform.sizeDelta = new Vector2(hbLength * (currHealth / 100.0f), hbHeight);

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
