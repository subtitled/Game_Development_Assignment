using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class loadoutDropdown : MonoBehaviour
{
    //sets up variables for storing what class every unit is
    public int unitOne;
    public int unitTwo;
    public int unitThree;
    public int unitFour;
    public int unitFive;

    //Warrior weapons/abilities/descriptions
    List<string> war_wep1 = new List<string> { "Sword", "Warhammer" };
    List<string> war_wep1_desc = new List<string> { "Flat damage attack.", "Less flat damage but it's multiplied by your strength stat." };
    List<string> war_ab1 = new List<string> { "Cleave", "Stun" };
    List<string> war_ab1_desc = new List<string> { "Deal damage in an area around the Warrior.", "Deal a small amount of damage but target skips next turn. " };
    //Priest weapons/abilities/descriptions
    List<string> pri_wep1 = new List<string> { "Mace", "Morning Star" };
    List<string> pri_wep1_desc = new List<string> { "Flat damage attack.", "Less flat damage but it's multiplied by your intelligence stat." };
    List<string> pri_ab1 = new List<string> { "Heal", "Buff" };
    List<string> pri_ab1_desc = new List<string> { "Increase a units health by an amount. Health can not go above the maximum for that unit.", "Increases a unit's base stat by 1 for 2 turns." };
    //Mage weapons/abilities/descriptions
    List<string> mag_wep1 = new List<string> { "Staff", "Wand" };
    List<string> mag_wep1_desc = new List<string> { "Flat damage attack.", "Less flat damage but it's multiplied by your intelligence stat." };
    List<string> mag_ab1 = new List<string> { "Fireball", "Magic Missile" };
    List<string> mag_ab1_desc = new List<string> { "Does some damage.", "Shoots out 3 attacks that deal a small amount of damage* intelligence." };
    //Rogue weapons/abilites/descriptions
    List<string> rog_wep1 = new List<string> { "Dagger", "Dual Daggers" };
    List<string> rog_wep1_desc = new List<string> { "Flat damage attack.", "Less flat damage but it's multiplied by your agility stat." };
    List<string> rog_ab1 = new List<string> { "Stab", "Slice" };
    List<string> rog_ab1_desc = new List<string> { "Does more damage than a regular attack but in a smaller area.", "Does a small amount of damage * agility in an area in front of the unit." };
    //Marksman weapons/abilities/descriptions
    List<string> mar_wep1 = new List<string> { "Crossbow", "Long Bow" };
    List<string> mar_wep1_desc = new List<string> { "Flat damage attack.", "Less flat damage but it's multiplied by your agility stat." };
    List<string> mar_ab1 = new List<string> { "Snipe", "Rapid Shot" };
    List<string> mar_ab1_desc = new List<string> { "Long range attack that does more damage the further the unit is away from the target.", "Shoots out 3 attacks that deal a small amount of damage* agility." };

    //storing weapon description boxes
    public Text[] wepDesc;
    //storing ability description boxes
    public Text[] abilDesc;

    //for storing values for unit 1
    public Dropdown u1w1;
    public Dropdown u1a1;
    //for storing values for unit 2
    public Dropdown u2w1;
    public Dropdown u2a1;
    //for storing values for unit 3
    public Dropdown u3w1;
    public Dropdown u3a1;
    //for storing values for unit 4
    public Dropdown u4w1;
    public Dropdown u4a1;
    //for storing values for unit 5
    public Dropdown u5w1;
    public Dropdown u5a1;

    void Start()
    {
        //loading ints for what classes were chose for displaying ability choices
        unitOne = PlayerPrefs.GetInt("UnitOne");
        unitTwo = PlayerPrefs.GetInt("UnitTwo");
        unitThree = PlayerPrefs.GetInt("UnitThree");
        unitFour = PlayerPrefs.GetInt("UnitFour");
        unitFive = PlayerPrefs.GetInt("UnitFive");
       
        //switch statements to find what abilities to load into the dropdown menus based on the values stored in playerprefs
        switch (unitOne)
        {
            case 0:
                u1w1.ClearOptions();
                u1w1.AddOptions(war_wep1);
                u1a1.ClearOptions();
                u1a1.AddOptions(war_ab1);
                break;
            case 1:
                u1w1.ClearOptions();
                u1w1.AddOptions(pri_wep1);
                u1a1.ClearOptions();
                u1a1.AddOptions(pri_ab1);
                break;
            case 2:
                u1w1.ClearOptions();
                u1w1.AddOptions(mag_wep1);
                u1a1.ClearOptions();
                u1a1.AddOptions(mag_ab1);
                break;
            case 3:
                u1w1.ClearOptions();
                u1w1.AddOptions(rog_wep1);
                u1a1.ClearOptions();
                u1a1.AddOptions(rog_ab1);
                break;
            case 4:
                u1w1.ClearOptions();
                u1w1.AddOptions(mar_wep1);
                u1a1.ClearOptions();
                u1a1.AddOptions(mar_ab1);
                break;
        }
        switch (unitTwo)
        {
            case 0:
                u2w1.ClearOptions();
                u2w1.AddOptions(war_wep1);
                u2a1.ClearOptions();
                u2a1.AddOptions(war_ab1);
                break;
            case 1:
                u2w1.ClearOptions();
                u2w1.AddOptions(pri_wep1);
                u2a1.ClearOptions();
                u2a1.AddOptions(pri_ab1);
                break;
            case 2:
                u2w1.ClearOptions();
                u2w1.AddOptions(mag_wep1);
                u2a1.ClearOptions();
                u2a1.AddOptions(mag_ab1);
                break;
            case 3:
                u2w1.ClearOptions();
                u2w1.AddOptions(rog_wep1);
                u2a1.ClearOptions();
                u2a1.AddOptions(rog_ab1);
                break;
            case 4:
                u2w1.ClearOptions();
                u2w1.AddOptions(mar_wep1);
                u2a1.ClearOptions();
                u2a1.AddOptions(mar_ab1);
                break;
        }
        switch (unitThree)
        {
            case 0:
                u3w1.ClearOptions();
                u3w1.AddOptions(war_wep1);
                u3a1.ClearOptions();
                u3a1.AddOptions(war_ab1);
                break;
            case 1:
                u3w1.ClearOptions();
                u3w1.AddOptions(pri_wep1);
                u3a1.ClearOptions();
                u3a1.AddOptions(pri_ab1);
                break;
            case 2:
                u3w1.ClearOptions();
                u3w1.AddOptions(mag_wep1);
                u3a1.ClearOptions();
                u3a1.AddOptions(mag_ab1);
                break;
            case 3:
                u3w1.ClearOptions();
                u3w1.AddOptions(rog_wep1);
                u3a1.ClearOptions();
                u3a1.AddOptions(rog_ab1);
                break;
            case 4:
                u3w1.ClearOptions();
                u3w1.AddOptions(mar_wep1);
                u3a1.ClearOptions();
                u3a1.AddOptions(mar_ab1);
                break;
        }
        switch (unitFour)
        {
            case 0:
                u4w1.ClearOptions();
                u4w1.AddOptions(war_wep1);
                u4a1.ClearOptions();
                u4a1.AddOptions(war_ab1);
                break;
            case 1:
                u4w1.ClearOptions();
                u4w1.AddOptions(pri_wep1);
                u4a1.ClearOptions();
                u4a1.AddOptions(pri_ab1);
                break;
            case 2:
                u4w1.ClearOptions();
                u4w1.AddOptions(mag_wep1);
                u4a1.ClearOptions();
                u4a1.AddOptions(mag_ab1);
                break;
            case 3:
                u4w1.ClearOptions();
                u4w1.AddOptions(rog_wep1);
                u4a1.ClearOptions();
                u4a1.AddOptions(rog_ab1);
                break;
            case 4:
                u4w1.ClearOptions();
                u4w1.AddOptions(mar_wep1);
                u4a1.ClearOptions();
                u4a1.AddOptions(mar_ab1);
                break;
        }
        switch (unitFive)
        {
            case 0:
                u5w1.ClearOptions();
                u5w1.AddOptions(war_wep1);
                u5a1.ClearOptions();
                u5a1.AddOptions(war_ab1);
                break;
            case 1:
                u5w1.ClearOptions();
                u5w1.AddOptions(pri_wep1);
                u5a1.ClearOptions();
                u5a1.AddOptions(pri_ab1);
                break;
            case 2:
                u5w1.ClearOptions();
                u5w1.AddOptions(mag_wep1);
                u5a1.ClearOptions();
                u5a1.AddOptions(mag_ab1);
                break;
            case 3:
                u5w1.ClearOptions();
                u5w1.AddOptions(rog_wep1);
                u5a1.ClearOptions();
                u5a1.AddOptions(rog_ab1);
                break;
            case 4:
                u5w1.ClearOptions();
                u5w1.AddOptions(mar_wep1);
                u5a1.ClearOptions();
                u5a1.AddOptions(mar_ab1);
                break;
        }
    }
    public void FixedUpdate()
    {
        switch (unitOne)
        {
            case 0:
                switch (u1w1.value)
                {
                    case 0:
                        wepDesc[0].text = war_wep1_desc[0];
                        break;
                    case 1:
                        wepDesc[0].text = war_wep1_desc[1];
                        break;
                }
                switch (u1a1.value)
                {
                    case 0:
                        abilDesc[0].text = war_ab1_desc[0];
                        break;
                    case 1:
                        abilDesc[0].text = war_ab1_desc[1];
                        break;
                }
                break;
            case 1:
                switch (u1w1.value)
                {
                    case 0:
                        wepDesc[0].text = pri_wep1_desc[0];
                        break;
                    case 1:
                        wepDesc[0].text = pri_wep1_desc[1];
                        break;
                }
                switch (u1a1.value)
                {
                    case 0:
                        abilDesc[0].text = pri_ab1_desc[0];
                        break;
                    case 1:
                        abilDesc[0].text = pri_ab1_desc[1];
                        break;
                }
                break;
            case 2:
                switch (u1w1.value)
                {
                    case 0:
                        wepDesc[0].text = mag_wep1_desc[0];
                        break;
                    case 1:
                        wepDesc[0].text = mag_wep1_desc[1];
                        break;
                }
                switch (u1a1.value)
                {
                    case 0:
                        abilDesc[0].text = mag_ab1_desc[0];
                        break;
                    case 1:
                        abilDesc[0].text = mag_ab1_desc[1];
                        break;
                }
                break;
            case 3:
                switch (u1w1.value)
                {
                    case 0:
                        wepDesc[0].text = rog_wep1_desc[0];
                        break;
                    case 1:
                        wepDesc[0].text = rog_wep1_desc[1];
                        break;
                }
                switch (u1a1.value)
                {
                    case 0:
                        abilDesc[0].text = rog_ab1_desc[0];
                        break;
                    case 1:
                        abilDesc[0].text = rog_ab1_desc[1];
                        break;
                }
                break;
            case 4:
                switch (u1w1.value)
                {
                    case 0:
                        wepDesc[0].text = mar_wep1_desc[0];
                        break;
                    case 1:
                        wepDesc[0].text = mar_wep1_desc[1];
                        break;
                }
                switch (u1a1.value)
                {
                    case 0:
                        abilDesc[0].text = mar_ab1_desc[0];
                        break;
                    case 1:
                        abilDesc[0].text = mar_ab1_desc[1];
                        break;
                }
                break;
        }
        switch (unitTwo)
        {
            case 0:
                switch (u2w1.value)
                {
                    case 0:
                        wepDesc[1].text = war_wep1_desc[0];
                        break;
                    case 1:
                        wepDesc[1].text = war_wep1_desc[1];
                        break;
                }
                switch (u2a1.value)
                {
                    case 0:
                        abilDesc[1].text = war_ab1_desc[0];
                        break;
                    case 1:
                        abilDesc[1].text = war_ab1_desc[1];
                        break;
                }
                break;
            case 1:
                switch (u2w1.value)
                {
                    case 0:
                        wepDesc[1].text = pri_wep1_desc[0];
                        break;
                    case 1:
                        wepDesc[1].text = pri_wep1_desc[1];
                        break;
                }
                switch (u2a1.value)
                {
                    case 0:
                        abilDesc[1].text = pri_ab1_desc[0];
                        break;
                    case 1:
                        abilDesc[1].text = pri_ab1_desc[1];
                        break;
                }
                break;
            case 2:
                switch (u2w1.value)
                {
                    case 0:
                        wepDesc[1].text = mag_wep1_desc[0];
                        break;
                    case 1:
                        wepDesc[1].text = mag_wep1_desc[1];
                        break;
                }
                switch (u2a1.value)
                {
                    case 0:
                        abilDesc[1].text = mag_ab1_desc[0];
                        break;
                    case 1:
                        abilDesc[1].text = mag_ab1_desc[1];
                        break;
                }
                break;
            case 3:
                switch (u2w1.value)
                {
                    case 0:
                        wepDesc[1].text = rog_wep1_desc[0];
                        break;
                    case 1:
                        wepDesc[1].text = rog_wep1_desc[1];
                        break;
                }
                switch (u2a1.value)
                {
                    case 0:
                        abilDesc[1].text = rog_ab1_desc[0];
                        break;
                    case 1:
                        abilDesc[1].text = rog_ab1_desc[1];
                        break;
                }
                break;
            case 4:
                switch (u2w1.value)
                {
                    case 0:
                        wepDesc[1].text = mar_wep1_desc[0];
                        break;
                    case 1:
                        wepDesc[1].text = mar_wep1_desc[1];
                        break;
                }
                switch (u2a1.value)
                {
                    case 0:
                        abilDesc[1].text = mar_ab1_desc[0];
                        break;
                    case 1:
                        abilDesc[1].text = mar_ab1_desc[1];
                        break;
                }
                break;
        }
        switch (unitThree)
        {
            case 0:
                switch (u3w1.value)
                {
                    case 0:
                        wepDesc[2].text = war_wep1_desc[0];
                        break;
                    case 1:
                        wepDesc[2].text = war_wep1_desc[1];
                        break;
                }
                switch (u3a1.value)
                {
                    case 0:
                        abilDesc[2].text = war_ab1_desc[0];
                        break;
                    case 1:
                        abilDesc[2].text = war_ab1_desc[1];
                        break;
                }
                break;
            case 1:
                switch (u3w1.value)
                {
                    case 0:
                        wepDesc[2].text = pri_wep1_desc[0];
                        break;
                    case 1:
                        wepDesc[2].text = pri_wep1_desc[1];
                        break;
                }
                switch (u3a1.value)
                {
                    case 0:
                        abilDesc[2].text = pri_ab1_desc[0];
                        break;
                    case 1:
                        abilDesc[2].text = pri_ab1_desc[1];
                        break;
                }
                break;
            case 2:
                switch (u3w1.value)
                {
                    case 0:
                        wepDesc[2].text = mag_wep1_desc[0];
                        break;
                    case 1:
                        wepDesc[2].text = mag_wep1_desc[1];
                        break;
                }
                switch (u3a1.value)
                {
                    case 0:
                        abilDesc[2].text = mag_ab1_desc[0];
                        break;
                    case 1:
                        abilDesc[2].text = mag_ab1_desc[1];
                        break;
                }
                break;
            case 3:
                switch (u3w1.value)
                {
                    case 0:
                        wepDesc[2].text = rog_wep1_desc[0];
                        break;
                    case 1:
                        wepDesc[2].text = rog_wep1_desc[1];
                        break;
                }
                switch (u3a1.value)
                {
                    case 0:
                        abilDesc[2].text = rog_ab1_desc[0];
                        break;
                    case 1:
                        abilDesc[2].text = rog_ab1_desc[1];
                        break;
                }
                break;
            case 4:
                switch (u3w1.value)
                {
                    case 0:
                        wepDesc[2].text = mar_wep1_desc[0];
                        break;
                    case 1:
                        wepDesc[2].text = mar_wep1_desc[1];
                        break;
                }
                switch (u3a1.value)
                {
                    case 0:
                        abilDesc[2].text = mar_ab1_desc[0];
                        break;
                    case 1:
                        abilDesc[2].text = mar_ab1_desc[1];
                        break;
                }
                break;
        }
        switch (unitFour)
        {
            case 0:
                switch (u4w1.value)
                {
                    case 0:
                        wepDesc[3].text = war_wep1_desc[0];
                        break;
                    case 1:
                        wepDesc[3].text = war_wep1_desc[1];
                        break;
                }
                switch (u4a1.value)
                {
                    case 0:
                        abilDesc[3].text = war_ab1_desc[0];
                        break;
                    case 1:
                        abilDesc[3].text = war_ab1_desc[1];
                        break;
                }
                break;
            case 1:
                switch (u4w1.value)
                {
                    case 0:
                        wepDesc[3].text = pri_wep1_desc[0];
                        break;
                    case 1:
                        wepDesc[3].text = pri_wep1_desc[1];
                        break;
                }
                switch (u4a1.value)
                {
                    case 0:
                        abilDesc[3].text = pri_ab1_desc[0];
                        break;
                    case 1:
                        abilDesc[3].text = pri_ab1_desc[1];
                        break;
                }
                break;
            case 2:
                switch (u4w1.value)
                {
                    case 0:
                        wepDesc[3].text = mag_wep1_desc[0];
                        break;
                    case 1:
                        wepDesc[3].text = mag_wep1_desc[1];
                        break;
                }
                switch (u4a1.value)
                {
                    case 0:
                        abilDesc[3].text = mag_ab1_desc[0];
                        break;
                    case 1:
                        abilDesc[3].text = mag_ab1_desc[1];
                        break;
                }
                break;
            case 3:
                switch (u4w1.value)
                {
                    case 0:
                        wepDesc[3].text = rog_wep1_desc[0];
                        break;
                    case 1:
                        wepDesc[3].text = rog_wep1_desc[1];
                        break;
                }
                switch (u4a1.value)
                {
                    case 0:
                        abilDesc[3].text = rog_ab1_desc[0];
                        break;
                    case 1:
                        abilDesc[3].text = rog_ab1_desc[1];
                        break;
                }
                break;
            case 4:
                switch (u4w1.value)
                {
                    case 0:
                        wepDesc[3].text = mar_wep1_desc[0];
                        break;
                    case 1:
                        wepDesc[3].text = mar_wep1_desc[1];
                        break;
                }
                switch (u4a1.value)
                {
                    case 0:
                        abilDesc[3].text = mar_ab1_desc[0];
                        break;
                    case 1:
                        abilDesc[3].text = mar_ab1_desc[1];
                        break;
                }
                break;
        }
        switch (unitFive)
        {
            case 0:
                switch (u5w1.value)
                {
                    case 0:
                        wepDesc[4].text = war_wep1_desc[0];
                        break;
                    case 1:
                        wepDesc[4].text = war_wep1_desc[1];
                        break;
                }
                switch (u5a1.value)
                {
                    case 0:
                        abilDesc[4].text = war_ab1_desc[0];
                        break;
                    case 1:
                        abilDesc[4].text = war_ab1_desc[1];
                        break;
                }
                break;
            case 1:
                switch (u5w1.value)
                {
                    case 0:
                        wepDesc[4].text = pri_wep1_desc[0];
                        break;
                    case 1:
                        wepDesc[4].text = pri_wep1_desc[1];
                        break;
                }
                switch (u5a1.value)
                {
                    case 0:
                        abilDesc[4].text = pri_ab1_desc[0];
                        break;
                    case 1:
                        abilDesc[4].text = pri_ab1_desc[1];
                        break;
                }
                break;
            case 2:
                switch (u5w1.value)
                {
                    case 0:
                        wepDesc[4].text = mag_wep1_desc[0];
                        break;
                    case 1:
                        wepDesc[4].text = mag_wep1_desc[1];
                        break;
                }
                switch (u5a1.value)
                {
                    case 0:
                        abilDesc[4].text = mag_ab1_desc[0];
                        break;
                    case 1:
                        abilDesc[4].text = mag_ab1_desc[1];
                        break;
                }
                break;
            case 3:
                switch (u5w1.value)
                {
                    case 0:
                        wepDesc[4].text = rog_wep1_desc[0];
                        break;
                    case 1:
                        wepDesc[4].text = rog_wep1_desc[1];
                        break;
                }
                switch (u5a1.value)
                {
                    case 0:
                        abilDesc[4].text = rog_ab1_desc[0];
                        break;
                    case 1:
                        abilDesc[4].text = rog_ab1_desc[1];
                        break;
                }
                break;
            case 4:
                switch (u5w1.value)
                {
                    case 0:
                        wepDesc[4].text = mar_wep1_desc[0];
                        break;
                    case 1:
                        wepDesc[4].text = mar_wep1_desc[1];
                        break;
                }
                switch (u5a1.value)
                {
                    case 0:
                        abilDesc[4].text = mar_ab1_desc[0];
                        break;
                    case 1:
                        abilDesc[4].text = mar_ab1_desc[1];
                        break;
                }
                break;
        }
    }
    //getting values of dropdown menu to save for later for Unit 1
    public void GetU1W1(int w1num)
    {
        switch (w1num)
        {
            case 0:
                u1w1.value = 0;
                break;
            case 1:
                u1w1.value = 1;
                break;
        }
    }
    public void GetU1A1(int a1num)
    {
        switch (a1num)
        {
            case 0:
                u1a1.value = 0;
                break;
            case 1:
                u1a1.value = 1;
                break;
        }
    }


    //getting values of dropdown menu to save for later for Unit 2
    public void GetU2W1(int w1num)
    {
        switch (w1num)
        {
            case 0:
                u2w1.value = 0;
                break;
            case 1:
                u2w1.value = 1;
                break;
        }
    }

    public void GetU2A1(int a1num)
    {
        switch (a1num)
        {
            case 0:
                u2a1.value = 0;
                break;
            case 1:
                u2a1.value = 1;
                break;
        }
    }


    //getting values of dropdown menu to save for later for Unit 3
    public void GetU3W1(int w1num)
    {
        switch (w1num)
        {
            case 0:
                u3w1.value = 0;
                break;
            case 1:
                u3w1.value = 1;
                break;
        }
    }

    public void GetU3A1(int a1num)
    {
        switch (a1num)
        {
            case 0:
                u3a1.value = 0;
                break;
            case 1:
                u3a1.value = 1;
                break;
        }
    }


    //getting values of dropdown menu to save for later for Unit 4
    public void GetU4W1(int w1num)
    {
        switch (w1num)
        {
            case 0:
                u4w1.value = 0;
                break;
            case 1:
                u4w1.value = 1;
                break;
        }
    }

    public void GetU4A1(int a1num)
    {
        switch (a1num)
        {
            case 0:
                u4a1.value = 0;
                break;
            case 1:
                u4a1.value = 1;
                break;
        }
    }


    //getting values of dropdown menu to save for later for Unit 5
    public void GetU5W1(int w1num)
    {
        switch (w1num)
        {
            case 0:
                u5w1.value = 0;
                break;
            case 1:
                u5w1.value = 1;
                break;
        }
    }

    public void GetU5A1(int a1num)
    {
        switch (a1num)
        {
            case 0:
                u5a1.value = 0;
                break;
            case 1:
                u5a1.value = 1;
                break;
        }
    }


    //Code for saving ability choices as an int to load when the game starts
    public void SaveLoadout()
    {
        PlayerPrefs.SetInt("U1W1", u1w1.value);
        PlayerPrefs.SetInt("U1A1", u1a1.value);
        PlayerPrefs.SetInt("U2W1", u2w1.value);
        PlayerPrefs.SetInt("U2A1", u2a1.value);
        PlayerPrefs.SetInt("U3W1", u3w1.value);
        PlayerPrefs.SetInt("U3A1", u3a1.value);
        PlayerPrefs.SetInt("U4W1", u4w1.value);
        PlayerPrefs.SetInt("U4A1", u4a1.value);
        PlayerPrefs.SetInt("U5W1", u5w1.value);
        PlayerPrefs.SetInt("U5A1", u5a1.value);

    }
}
