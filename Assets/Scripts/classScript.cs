
//use this to store stats/abilities for classes/enemies change depending on class/enemy, save as for that class

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class classScript : MonoBehaviour
{
    // FSM state values.
    public enum FSMstate
    {
        None,
        Wait,
        Active,
        Moving,
        Dead
    }
    // FSM switch.
    public FSMstate currState;

    //TODO: TAKE VALUE FROM ABILITY SELECTION SET ints TO VALUE FOR SWITCH STATEMENTS
    //Setup for switch statements (might change later)
    public int wep_1;
    public int abil_1;

    //setup up for damage numbers
    public int w1dmg;
    public int a1dmg;

    //Stat setup (might change later)
    public int strength;
    public int agility;
    public int intelligence;
    public int health;
    public int movement;
    public int initiative; //change depending on class

    //extra setup for referencing
    public int classNum;
    public int unitNum;

    public bool dead;
    public bool active;
    public bool action;
    public bool move;
    
    // Connect to map control.
    private GameObject mapControl;
    private NavMeshAgent nav;
    private Vector3 destination;
    public float movementRange = 6.0f;
    private float moveDistance;

    //Holder for UI to be enabled/disabled
    public GameObject classUI;

    //healthbar
    public Image healthBar;
    float hbLength;
    float hbHeight;

    // Start is called before the first frame update
    void Start()
    {
        // Connect to map control and components.
        mapControl = GameObject.Find("MapControl");
        nav = GetComponent<NavMeshAgent>();
        
        //gets weapon and ability that was saved on the loadout selection screen
        switch (unitNum)
        {
            case 0:
                wep_1 = PlayerPrefs.GetInt("U1W1");
                abil_1 = PlayerPrefs.GetInt("U1A1");
                break;
            case 1:
                wep_1 = PlayerPrefs.GetInt("U2W1");
                abil_1 = PlayerPrefs.GetInt("U2A1");
                break;
            case 2:
                wep_1 = PlayerPrefs.GetInt("U3W1");
                abil_1 = PlayerPrefs.GetInt("U3A1");
                break;
            case 3:
                wep_1 = PlayerPrefs.GetInt("U4W1");
                abil_1 = PlayerPrefs.GetInt("U4A1");
                break;
            case 4:
                wep_1 = PlayerPrefs.GetInt("U5W1");
                abil_1 = PlayerPrefs.GetInt("U5A1");
                break;
        }

        //generates stats for classes (change value ranges based on class)
        switch (classNum) 
        {
            case 0: //warrior
                strength = Random.Range(7, 9);
                agility = Random.Range(5, 7);
                intelligence = Random.Range(2, 5);
                health = Random.Range(110, 130);
                movement = 3;
                initiative = Random.Range(1, 11) + agility;
                switch (wep_1)
                {
                    case 0:
                        w1dmg = 30;
                        break;
                    case 1:
                        w1dmg = 30;
                        break;
                }
                switch (abil_1)
                {
                    case 0:
                        a1dmg = 30;
                        break;
                    case 1:
                        a1dmg = 30;
                        break;
                }
                break;
            case 1: //priest
                strength = Random.Range(5, 7);
                agility = Random.Range(5, 7);
                intelligence = Random.Range(6, 8);
                health = Random.Range(100, 120);
                movement = 3;
                initiative = Random.Range(1, 11) + agility;
                switch (wep_1)
                {
                    case 0:
                        w1dmg = 30;
                        break;
                    case 1:
                        w1dmg = 30;
                        break;
                }
                switch (abil_1)
                {
                    case 0:
                        a1dmg = 30;
                        break;
                    case 1:
                        a1dmg = 30;
                        break;
                }
                break;
            case 2: //mage
                strength = Random.Range(2, 5);
                agility = Random.Range(6, 8);
                intelligence = Random.Range(7, 9);
                health = Random.Range(90, 110);
                movement = 3;
                initiative = Random.Range(1, 11) + agility;
                switch (wep_1)
                {
                    case 0:
                        w1dmg = 30;
                        break;
                    case 1:
                        w1dmg = 30;
                        break;
                }
                switch (abil_1)
                {
                    case 0:
                        a1dmg = 30;
                        break;
                    case 1:
                        a1dmg = 30;
                        break;
                }
                break;
            case 3: //rogue
                strength = Random.Range(6, 8);
                agility = Random.Range(7, 9);
                intelligence = Random.Range(5, 6);
                health = Random.Range(100, 110);
                movement = 3;
                initiative = Random.Range(1, 11) + agility;
                switch (wep_1)
                {
                    case 0:
                        w1dmg = 30;
                        break;
                    case 1:
                        w1dmg = 30;
                        break;
                }
                switch (abil_1)
                {
                    case 0:
                        a1dmg = 30;
                        break;
                    case 1:
                        a1dmg = 30;
                        break;
                }
                break;
            case 4: //marksman
                strength = Random.Range(2, 5);
                agility = Random.Range(6, 8);
                intelligence = Random.Range(2, 5);
                health = Random.Range(90, 110);
                movement = 3;
                initiative = Random.Range(1, 11) + agility;
                switch (wep_1)
                {
                    case 0:
                        w1dmg = 30;
                        break;
                    case 1:
                        w1dmg = 30;
                        break;
                }
                switch (abil_1)
                {
                    case 0:
                        a1dmg = 30;
                        break;
                    case 1:
                        a1dmg = 30;
                        break;
                }
                break;
        }

        // Setting to wait states.
        classUI.SetActive(active);
        currState = FSMstate.Wait;
    }

    // Update is called once per frame
    void Update()
    {
        // FSM switch.
        switch (currState)
        {
            case FSMstate.Wait: UpdateWaitStatus(); break;
            case FSMstate.Active: UpdateActiveStatus(); break;
            case FSMstate.Moving: UpdateMovingStatus(); break;
            case FSMstate.Dead: UpdateDeadStatus(); break;
        }
        
        if(!dead)
        {
            classUI.SetActive(active);
        }
        
    }
    
    protected void UpdateWaitStatus()
    {
        // Primary stand-by state between turns, Central state for recalculating activity status.
        
        if (dead)
        {
            currState = FSMstate.Dead;
        }
        
        // Calculates state to enter when becoming the active character.
        if (active)
        {
            currState = FSMstate.Active;
        }
    }

    protected void UpdateActiveStatus()
    {
        
        
        
        // // DEBUG skip player.
        // active = false;
        // mapControl.SendMessage("ApplyActiveStatus", false);
        // currState = FSMstate.Wait;
        
            
        if (move == false & action == false)
        {
            active = false;
            mapControl.SendMessage("ApplyActiveStatus", false);
            currState = FSMstate.Wait;
        }
    }
    
    
    protected void UpdateMovingStatus()
    {
        // Dedicated Moving State, so the player cannot also make an action at the same time.
        
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

    public void Attack(Vector3 target)
    {
        // Basic attack, hits targets in a small area.
        Collider[] hits = Physics.OverlapSphere(target, 1f);
        foreach (Collider hit in hits)
        {
            if (hit.CompareTag("Player"))
            {
                hit.SendMessage("ApplyDamage", w1dmg);
            }
        }
    }
    
    public void WarriorAbility1()
    {
        // Damages nearby players.
        Collider[] hits = Physics.OverlapSphere(transform.position, 3.0f);
        foreach (Collider hit in hits)
        {
            if (hit.CompareTag("Player"))
            {
                hit.SendMessage("ApplyDamage", a1dmg);
            }
        }
    }
    
    public void PriestAbility1(Vector3 target)
    {
        // Heals allies within a target area.
        Collider[] hits = Physics.OverlapSphere(target, 3.0f);
        foreach (Collider hit in hits)
        {
            if (hit.CompareTag("Enemy"))
            {
                hit.SendMessage("ApplyDamage", -a1dmg);
            }
        }
    }

    public void MageAbility1(Vector3 target)
    {
        // Damage all targets in a targeted area.
        Collider[] hits = Physics.OverlapSphere(target, 3.0f);
        foreach (Collider hit in hits)
        {
            if (hit.CompareTag("Player"))
            {
                hit.SendMessage("ApplyDamage", a1dmg);
            }
        }
    }
    
    public void RogueAbility1(Vector3 target)
    {
        // Deals high damage to a single target.
        Collider[] hits = Physics.OverlapSphere(target, 0.5f);
        foreach (Collider hit in hits)
        {
            if (hit.CompareTag("Player"))
            {
                hit.SendMessage("ApplyDamage", a1dmg*1.75f);
            }
        }
    }

    public void MarksmanAbility1(Vector3 target)
    {
        // Deals more damage to targets further away, less to close targets.
        Collider[] hits = Physics.OverlapSphere(target, 1.0f);
        foreach (Collider hit in hits)
        {
            if (hit.CompareTag("Player"))
            {
                float scaledDamage = a1dmg * (Vector3.Distance(transform.position, target) / 3);
                hit.SendMessage("ApplyDamage", scaledDamage);
            }
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
        // // Reciever for damage taken.
        //
        // currHealth -= damage;
        //
        // // Death check.
        // if (currHealth <= 0)
        // {
        //     /*
        //      * DEATH EFFECTS
        //      * UI, Visual, Transformative.
        //     */
        //     
        //     // Disables character functions.
        //     mapControl.SendMessage("ApplyPlayerSlain");
        //     nav.isStopped = true;
        //     nav.enabled = false;
        //     dead = true;
        // }
        healthBar.rectTransform.sizeDelta = new Vector2(hbLength * (health / 100.0f), hbHeight);
    }

    private void OnDrawGizmos()
    {
        // // DEBUG for range thresholds.
        // Gizmos.color = Color.yellow;
        // Gizmos.DrawWireSphere(transform.position, alertRange);
        // Gizmos.color = Color.red;
        // Gizmos.DrawWireSphere(transform.position, engagedRange);
        // Gizmos.color = Color.green;
        // Gizmos.DrawWireSphere(transform.position, movementRange);
        
    }
    
}
