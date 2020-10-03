
//use this to store stats/abilities for classes/enemies change depending on class/enemy, save as for that class

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class classScript : MonoBehaviour
{
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

    //Holder for UI to be enabled/disabled
    public GameObject classUI;

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

        
    }

    // Update is called once per frame
    void Update()
    {
        if (active)
        {
            if (dead)
            {
                active = false;
                mapControl.SendMessage("ApplyActiveStatus", false);
            }
            
            /*
             * ACTIVATE PLAYER CONTROLS FOR CHARACTER
             */
            
            // DEBUG skip player.
            active = false;
            mapControl.SendMessage("ApplyActiveStatus", false);
            
            /*
             * DEACTIVATE PLAYER CONTROLS FOR CHARACTER
             */
            
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
            //moveDistance = movementRange;
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
