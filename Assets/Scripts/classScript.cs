
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
        Dead,
        MoveTarget,
        AttackTarget,
        AbilityTarget
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
    public float maxHealth;
    public float currHealth;
    public int movement;
    public int initiative; //change depending on class

    //extra setup for referencing
    public int classNum;
    public int unitNum;

    public bool dead;
    public bool active;
    public bool action;
    public bool move;
    public bool defendStatus = false;

    private float elapsedTime;
    private float moveTimer = 6f;
    
    // Connect to map control.
    private GameObject mapControl;
    private NavMeshAgent nav;
    private Vector3 destination;
    public float movementRange = 6.0f;
    private float moveDistance;

    //Holder for UI to be enabled/disabled
    public GameObject classUI;
    
    // Mouse targeting.
    private Ray myRay;
    private RaycastHit hit;
    public GameObject mousePointer;
    float validRange;
    bool validTarget;

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
        mousePointer.SetActive(false);
       
        // Initiate healbar variables
        hbLength = healthBar.rectTransform.rect.width;
        hbHeight = healthBar.rectTransform.rect.height;

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
                maxHealth = Random.Range(110, 130);
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
                maxHealth = Random.Range(100, 120);
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
                maxHealth = Random.Range(90, 110);
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
                maxHealth = Random.Range(100, 110);
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
                maxHealth = Random.Range(90, 110);
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
        
        currHealth = maxHealth;

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
            case FSMstate.MoveTarget: UpdateMoveTarget(); break;
            case FSMstate.AttackTarget: UpdateAttackTarget(); break;
            case FSMstate.AbilityTarget: UpdateAbilityTarget(); break;
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
        // Timer to prevent locks from unreachable targets.
        elapsedTime += Time.deltaTime;
        
        // Checks to see if the movement range has been reached, or at the destination.
        if (moveDistance <= 0.0f | Vector3.Distance(transform.position, destination) <= 0.5f | elapsedTime >= moveTimer)
        {
            elapsedTime = 0f;
            nav.isStopped = true;
            nav.enabled = false;
            move = false;
            currState = FSMstate.Active;
            // Return to active state for input.
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

    protected void UpdateMoveTarget()
    {
        myRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(myRay, out hit))
        {
            mousePointer.transform.localScale = new Vector3 (0.5f, 0.5f, 0.5f);
            mousePointer.GetComponent<Renderer>().material.color = Color.green;
            mousePointer.transform.position = hit.point;
            mousePointer.SetActive(true);
            
            if (Input.GetButtonDown("Fire1"))
            {
                destination = hit.point;
                mousePointer.SetActive(false);
                currState = FSMstate.Moving;
            }
        }
        
    }
    
    protected void UpdateAttackTarget()
    {
        switch (classNum)
        {
            case 0: validRange = 1.25f; break;
            case 1: validRange = 1.25f; break;
            case 2: validRange = 6f; break;
            case 3: validRange = 1.25f; break;
            case 4: validRange = 8f; break;
        }
        
        if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit))
        {
            if (Vector3.Distance(transform.position, hit.point) <= validRange)
            {
                mousePointer.GetComponent<Renderer>().material.color = Color.green;
                validTarget = true;
            }
            if (Vector3.Distance(transform.position, hit.point) > validRange)
            {
                mousePointer.GetComponent<Renderer>().material.color = Color.red;
                validTarget = false;
            }
            
            mousePointer.transform.localScale = new Vector3 (2f, 2f, 2f);
            mousePointer.transform.position = hit.point;
            mousePointer.SetActive(true);

            if (Input.GetMouseButtonDown(0) & validTarget)
            {
                Attack(hit.point);
                mousePointer.SetActive(false);
                currState = FSMstate.Active;
            }
        }
    }
    
    protected void UpdateAbilityTarget()
    {
        switch (classNum)
        {
            case 0: WarriorAbility1();
                currState = FSMstate.Active;
                validRange = 0f; break;
            case 1: validRange = 1.25f; break;
            case 2: validRange = 6f; break;
            case 3: validRange = 1.25f; break;
            case 4: validRange = 8f; break;
        }
        
        if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit))
        {
            mousePointer.transform.position = hit.point;
            if (Vector3.Distance(transform.position, hit.point) <= validRange)
            {
                mousePointer.GetComponent<Renderer>().material.color = Color.green;
                validTarget = true;
            }
            if (Vector3.Distance(transform.position, hit.point) > validRange)
            {
                mousePointer.GetComponent<Renderer>().material.color = Color.red;
                validTarget = false;
            }
            switch (classNum)
            {
                case 0: break;
                case 1: mousePointer.transform.localScale = new Vector3 (4f, 4f, 4f); break;
                case 2: mousePointer.transform.localScale = new Vector3 (4f, 4f, 4f); break;
                case 3: mousePointer.transform.localScale = new Vector3 (1f, 1f, 1f); break;
                case 4: mousePointer.transform.localScale = new Vector3 (1f, 1f, 1f); break;
            }
            if (classNum != 0)
            {
                mousePointer.SetActive(true);
            }
            if (Input.GetMouseButtonDown(0) & validTarget)
            {
                switch (classNum)
                {
                    case 0: break;
                    case 1: PriestAbility1(hit.point); break;
                    case 2: MageAbility1(hit.point); break;
                    case 3: RogueAbility1(hit.point); break;
                    case 4: MarksmanAbility1(hit.point); break;
                }
                mousePointer.SetActive(false);
                currState = FSMstate.Active;
            }
        }
    }
    
    public void Attack(Vector3 target)
    {
        // Basic attack, hits targets in a small area.
        Collider[] hits = Physics.OverlapSphere(target, 1f);
        foreach (Collider hit in hits)
        {
            if (hit.CompareTag("Enemy"))
            {
                hit.SendMessage("ApplyDamage", w1dmg);
            }
        }
        action = false;
    }

    public void Defend()
    {
        // Blocks the first hit until the next turn.
        defendStatus = true;
        action = false;
    }
    
    public void WarriorAbility1()
    {
        // Damages nearby players.
        Collider[] hits = Physics.OverlapSphere(transform.position, 3.0f);
        foreach (Collider hit in hits)
        {
            if (hit.CompareTag("Enemy"))
            {
                hit.SendMessage("ApplyDamage", a1dmg);
            }
        }
        action = false;
    }
    
    public void PriestAbility1(Vector3 target)
    {
        // Heals allies within a target area.
        Collider[] hits = Physics.OverlapSphere(target, 2.0f);
        foreach (Collider hit in hits)
        {
            if (hit.CompareTag("Player"))
            {
                hit.SendMessage("ApplyDamage", -a1dmg);
            }
        }
        action = false;
    }

    public void MageAbility1(Vector3 target)
    {
        // Damage all targets in a targeted area.
        Collider[] hits = Physics.OverlapSphere(target, 2.0f);
        foreach (Collider hit in hits)
        {
            if (hit.CompareTag("Enemy"))
            {
                hit.SendMessage("ApplyDamage", a1dmg);
            }
        }
        action = false;
    }
    
    public void RogueAbility1(Vector3 target)
    {
        // Deals high damage to a single target.
        Collider[] hits = Physics.OverlapSphere(target, 0.5f);
        foreach (Collider hit in hits)
        {
            if (hit.CompareTag("Enemy"))
            {
                hit.SendMessage("ApplyDamage", a1dmg*1.75f);
            }
        }
        action = false;
    }

    public void MarksmanAbility1(Vector3 target)
    {
        // Deals more damage to targets further away, less to close targets.
        Collider[] hits = Physics.OverlapSphere(target, 0.5f);
        foreach (Collider hit in hits)
        {
            if (hit.CompareTag("Enemy"))
            {
                float scaledDamage = a1dmg * (Vector3.Distance(transform.position, target) / 5f);
                hit.SendMessage("ApplyDamage", scaledDamage);
            }
        }
        action = false;
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
        healthBar.rectTransform.sizeDelta = new Vector2(hbLength * (currHealth / 100.0f), hbHeight);
        
        // Death check.
        if (currHealth <= 0)
        {
            /*
             * DEATH EFFECTS
             * UI, Visual, Transformative.
            */
            
            // Disables character functions.
            mapControl.SendMessage("ApplyPlayerSlain");
            nav.isStopped = true;
            nav.enabled = false;
            dead = true;
            currState = FSMstate.Dead;
        }
    }

    public void ApplyMoveTargeting()
    {
        if (move)
        {
            currState = FSMstate.MoveTarget;
        }
    }

    public void ApplyAttackTargeting()
    {
        if (action)
        {
            currState = FSMstate.AttackTarget;
        }
    }

    public void ApplyAbilityTargeting()
    {
        if (action)
        {
            currState = FSMstate.AbilityTarget;
        }
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
