using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class classScript : MonoBehaviour
{
    
    //Setup for switch statements (might change later)
    public int wep_1 = 0;
    public int wep_2 = 0;
    public int abil_1 = 0;
    public int abil_2 = 0;

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
                //Enter code to set this weapon
                break;
        }
    }
}
