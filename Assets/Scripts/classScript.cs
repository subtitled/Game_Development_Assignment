
//use this to store stats/abilities for classes/enemies change depending on class/enemy, save as for that class

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class classScript : MonoBehaviour
{
    //TODO: TAKE VALUE FROM ABILITY SELECTION SET ints TO VALUE FOR SWITCH STATEMENTS
    //Setup for switch statements (might change later)
    public static int wep_1 = 0;
    public static int wep_2 = 0;
    public static int abil_1 = 0;
    public static int abil_2 = 0;

    //Stat setup (might change later)
    public int strength;
    public int agility;
    public int health;
    public int movement = 3; //change depending on class

    // Start is called before the first frame update
    void Start()
    {
        //generates stats for classes (change value ranges based on class)
        strength = Random.Range(6,9);
        agility = Random.Range(5,7);
        health = Random.Range(100, 130);
        
    }

    // Update is called once per frame
    void Update()
    {
  
    }

    void primaryWeapon()
    {
        switch (wep_1)
        {
            case 2:
                //Enter code to set this weapon
                break;
            case 1:
                //Enter code to set this weapon
                break;
            default:
                //deal strength in dmg
                int range = 1;
                int dmg = strength * 1;
                break;
        }
        switch (wep_2)
        {
            case 2:
                //Enter code to set this weapon
                break;
            case 1:
                //Enter code to set this weapon
                break;
            default:
                //deal strength in dmg
                int dmg = strength * 1;
                break;
        }
        switch (abil_1)
        {
            case 2:
                //Enter code to set this weapon
                break;
            case 1:
                //Enter code to set this weapon
                break;
            default:
                //deal strength in dmg
                int dmg = strength * 1;
                break;
        }
        switch (abil_2)
        {
            case 2:
                //Enter code to set this weapon
                break;
            case 1:
                //Enter code to set this weapon
                break;
            default:
                //deal strength in dmg
                int dmg = strength * 1;
                break;
        }
    }
}
