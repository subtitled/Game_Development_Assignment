using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class loadoutDropdown : MonoBehaviour
{
    public int unitOne;
    public int unitTwo;
    public int unitThree;
    public int unitFour;
    public int unitFive;

    //Warrior weapons/abilities
    List<string> war_wep1 = new List<string> { "War Wep 1.1", "War Wep 1.2" };
    List<string> war_wep2 = new List<string> { "War Wep 2.1", "War Wep 2.2" };
    List<string> war_ab1 = new List<string> { "War ab 1.1", "War ab 1.2" };
    List<string> war_ab2 = new List<string> { "War ab 2.1", "War ab 2.2" };
    //Priest weapons/abilities
    List<string> pri_wep1 = new List<string> { "pri Wep 1.1", "pri Wep 1.2" };
    List<string> pri_wep2 = new List<string> { "pri Wep 2.1", "pri Wep 2.2" };
    List<string> pri_ab1 = new List<string> { "pri ab 1.1", "pri ab 1.2" };
    List<string> pri_ab2 = new List<string> { "pri ab 2.1", "pri ab 2.2" };
    //Mage weapons/abilities
    List<string> mag_wep1 = new List<string> { "mag Wep 1.1", "mag Wep 1.2" };
    List<string> mag_wep2 = new List<string> { "mag Wep 2.1", "mag Wep 2.2" };
    List<string> mag_ab1 = new List<string> { "mag ab 1.1", "mag ab 1.2" };
    List<string> mag_ab2 = new List<string> { "mag ab 2.1", "mag ab 2.2" };
    //Rogue weapons/abilites
    List<string> rog_wep1 = new List<string> { "rog Wep 1.1", "rog Wep 1.2" };
    List<string> rog_wep2 = new List<string> { "rog Wep 2.1", "rog Wep 2.2" };
    List<string> rog_ab1 = new List<string> { "rog ab 1.1", "rog ab 1.2" };
    List<string> rog_ab2 = new List<string> { "rog ab 2.1", "rog ab 2.2" };
    //Marksman weapons/abilities
    List<string> mar_wep1 = new List<string> { "mar Wep 1.1", "mar Wep 1.2" };
    List<string> mar_wep2 = new List<string> { "mar Wep 2.1", "mar Wep 2.2" };
    List<string> mar_ab1 = new List<string> { "mar ab 1.1", "mar ab 1.2" };
    List<string> mar_ab2 = new List<string> { "mar ab 2.1", "mar ab 2.2" };

    //for storing values for unit 1
    public Dropdown u1w1;
    public Dropdown u1w2;
    public Dropdown u1a1;
    public Dropdown u1a2;
    //for storing values for unit 2
    public Dropdown u2w1;
    public Dropdown u2w2;
    public Dropdown u2a1;
    public Dropdown u2a2;
    //for storing values for unit 3
    public Dropdown u3w1;
    public Dropdown u3w2;
    public Dropdown u3a1;
    public Dropdown u3a2;
    //for storing values for unit 4
    public Dropdown u4w1;
    public Dropdown u4w2;
    public Dropdown u4a1;
    public Dropdown u4a2;
    //for storing values for unit 5
    public Dropdown u5w1;
    public Dropdown u5w2;
    public Dropdown u5a1;
    public Dropdown u5a2;

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
                u1w2.ClearOptions();
                u1w2.AddOptions(war_wep2);
                u1a1.ClearOptions();
                u1a1.AddOptions(war_ab1);
                u1a2.ClearOptions();
                u1a2.AddOptions(war_ab2);
                break;
            case 1:
                u1w1.ClearOptions();
                u1w1.AddOptions(pri_wep1);
                u1w2.ClearOptions();
                u1w2.AddOptions(pri_wep2);
                u1a1.ClearOptions();
                u1a1.AddOptions(pri_ab1);
                u1a2.ClearOptions();
                u1a2.AddOptions(pri_ab2);
                break;
            case 2:
                u1w1.ClearOptions();
                u1w1.AddOptions(mag_wep1);
                u1w2.ClearOptions();
                u1w2.AddOptions(mag_wep2);
                u1a1.ClearOptions();
                u1a1.AddOptions(mag_ab1);
                u1a2.ClearOptions();
                u1a2.AddOptions(mag_ab2);
                break;
            case 3:
                u1w1.ClearOptions();
                u1w1.AddOptions(rog_wep1);
                u1w2.ClearOptions();
                u1w2.AddOptions(rog_wep2);
                u1a1.ClearOptions();
                u1a1.AddOptions(rog_ab1);
                u1a2.ClearOptions();
                u1a2.AddOptions(rog_ab2);
                break;
            case 4:
                u1w1.ClearOptions();
                u1w1.AddOptions(mar_wep1);
                u1w2.ClearOptions();
                u1w2.AddOptions(mar_wep2);
                u1a1.ClearOptions();
                u1a1.AddOptions(mar_ab1);
                u1a2.ClearOptions();
                u1a2.AddOptions(mar_ab2);
                break;
        }
        switch (unitTwo)
        {
            case 0:
                u2w1.ClearOptions();
                u2w1.AddOptions(war_wep1);
                u2w2.ClearOptions();
                u2w2.AddOptions(war_wep2);
                u2a1.ClearOptions();
                u2a1.AddOptions(war_ab1);
                u2a2.ClearOptions();
                u2a2.AddOptions(war_ab2);
                break;
            case 1:
                u2w1.ClearOptions();
                u2w1.AddOptions(pri_wep1);
                u2w2.ClearOptions();
                u2w2.AddOptions(pri_wep2);
                u2a1.ClearOptions();
                u2a1.AddOptions(pri_ab1);
                u2a2.ClearOptions();
                u2a2.AddOptions(pri_ab2);
                break;
            case 2:
                u2w1.ClearOptions();
                u2w1.AddOptions(mag_wep1);
                u2w2.ClearOptions();
                u2w2.AddOptions(mag_wep2);
                u2a1.ClearOptions();
                u2a1.AddOptions(mag_ab1);
                u2a2.ClearOptions();
                u2a2.AddOptions(mag_ab2);
                break;
            case 3:
                u2w1.ClearOptions();
                u2w1.AddOptions(rog_wep1);
                u2w2.ClearOptions();
                u2w2.AddOptions(rog_wep2);
                u2a1.ClearOptions();
                u2a1.AddOptions(rog_ab1);
                u2a2.ClearOptions();
                u2a2.AddOptions(rog_ab2);
                break;
            case 4:
                u2w1.ClearOptions();
                u2w1.AddOptions(mar_wep1);
                u2w2.ClearOptions();
                u2w2.AddOptions(mar_wep2);
                u2a1.ClearOptions();
                u2a1.AddOptions(mar_ab1);
                u2a2.ClearOptions();
                u2a2.AddOptions(mar_ab2);
                break;
        }
        switch (unitThree)
        {
            case 0:
                u3w1.ClearOptions();
                u3w1.AddOptions(war_wep1);
                u3w2.ClearOptions();
                u3w2.AddOptions(war_wep2);
                u3a1.ClearOptions();
                u3a1.AddOptions(war_ab1);
                u3a2.ClearOptions();
                u3a2.AddOptions(war_ab2);
                break;
            case 1:
                u3w1.ClearOptions();
                u3w1.AddOptions(pri_wep1);
                u3w2.ClearOptions();
                u3w2.AddOptions(pri_wep2);
                u3a1.ClearOptions();
                u3a1.AddOptions(pri_ab1);
                u3a2.ClearOptions();
                u3a2.AddOptions(pri_ab2);
                break;
            case 2:
                u3w1.ClearOptions();
                u3w1.AddOptions(mag_wep1);
                u3w2.ClearOptions();
                u3w2.AddOptions(mag_wep2);
                u3a1.ClearOptions();
                u3a1.AddOptions(mag_ab1);
                u3a2.ClearOptions();
                u3a2.AddOptions(mag_ab2);
                break;
            case 3:
                u3w1.ClearOptions();
                u3w1.AddOptions(rog_wep1);
                u3w2.ClearOptions();
                u3w2.AddOptions(rog_wep2);
                u3a1.ClearOptions();
                u3a1.AddOptions(rog_ab1);
                u3a2.ClearOptions();
                u3a2.AddOptions(rog_ab2);
                break;
            case 4:
                u3w1.ClearOptions();
                u3w1.AddOptions(mar_wep1);
                u3w2.ClearOptions();
                u3w2.AddOptions(mar_wep2);
                u3a1.ClearOptions();
                u3a1.AddOptions(mar_ab1);
                u3a2.ClearOptions();
                u3a2.AddOptions(mar_ab2);
                break;
        }
        switch (unitFour)
        {
            case 0:
                u4w1.ClearOptions();
                u4w1.AddOptions(war_wep1);
                u4w2.ClearOptions();
                u4w2.AddOptions(war_wep2);
                u4a1.ClearOptions();
                u4a1.AddOptions(war_ab1);
                u4a2.ClearOptions();
                u4a2.AddOptions(war_ab2);
                break;
            case 1:
                u4w1.ClearOptions();
                u4w1.AddOptions(pri_wep1);
                u4w2.ClearOptions();
                u4w2.AddOptions(pri_wep2);
                u4a1.ClearOptions();
                u4a1.AddOptions(pri_ab1);
                u4a2.ClearOptions();
                u4a2.AddOptions(pri_ab2);
                break;
            case 2:
                u4w1.ClearOptions();
                u4w1.AddOptions(mag_wep1);
                u4w2.ClearOptions();
                u4w2.AddOptions(mag_wep2);
                u4a1.ClearOptions();
                u4a1.AddOptions(mag_ab1);
                u4a2.ClearOptions();
                u4a2.AddOptions(mag_ab2);
                break;
            case 3:
                u4w1.ClearOptions();
                u4w1.AddOptions(rog_wep1);
                u4w2.ClearOptions();
                u4w2.AddOptions(rog_wep2);
                u4a1.ClearOptions();
                u4a1.AddOptions(rog_ab1);
                u4a2.ClearOptions();
                u4a2.AddOptions(rog_ab2);
                break;
            case 4:
                u4w1.ClearOptions();
                u4w1.AddOptions(mar_wep1);
                u4w2.ClearOptions();
                u4w2.AddOptions(mar_wep2);
                u4a1.ClearOptions();
                u4a1.AddOptions(mar_ab1);
                u4a2.ClearOptions();
                u4a2.AddOptions(mar_ab2);
                break;
        }
        switch (unitFive)
        {
            case 0:
                u5w1.ClearOptions();
                u5w1.AddOptions(war_wep1);
                u5w2.ClearOptions();
                u5w2.AddOptions(war_wep2);
                u5a1.ClearOptions();
                u5a1.AddOptions(war_ab1);
                u5a2.ClearOptions();
                u5a2.AddOptions(war_ab2);
                break;
            case 1:
                u5w1.ClearOptions();
                u5w1.AddOptions(pri_wep1);
                u5w2.ClearOptions();
                u5w2.AddOptions(pri_wep2);
                u5a1.ClearOptions();
                u5a1.AddOptions(pri_ab1);
                u5a2.ClearOptions();
                u5a2.AddOptions(pri_ab2);
                break;
            case 2:
                u5w1.ClearOptions();
                u5w1.AddOptions(mag_wep1);
                u5w2.ClearOptions();
                u5w2.AddOptions(mag_wep2);
                u5a1.ClearOptions();
                u5a1.AddOptions(mag_ab1);
                u5a2.ClearOptions();
                u5a2.AddOptions(mag_ab2);
                break;
            case 3:
                u5w1.ClearOptions();
                u5w1.AddOptions(rog_wep1);
                u5w2.ClearOptions();
                u5w2.AddOptions(rog_wep2);
                u5a1.ClearOptions();
                u5a1.AddOptions(rog_ab1);
                u5a2.ClearOptions();
                u5a2.AddOptions(rog_ab2);
                break;
            case 4:
                u5w1.ClearOptions();
                u5w1.AddOptions(mar_wep1);
                u5w2.ClearOptions();
                u5w2.AddOptions(mar_wep2);
                u5a1.ClearOptions();
                u5a1.AddOptions(mar_ab1);
                u5a2.ClearOptions();
                u5a2.AddOptions(mar_ab2);
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
    public void GetU1W2(int w2num)
    {
        switch (w2num)
        {
            case 0:
                u1w2.value = 0;
                break;
            case 1:
                u1w2.value = 1;
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
    public void GetU1A2(int a2num)
    {
        switch (a2num)
        {
            case 0:
                u1a2.value = 0;
                break;
            case 1:
                u1a2.value = 1;
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
    public void GetU2W2(int w2num)
    {
        switch (w2num)
        {
            case 0:
                u2w2.value = 0;
                break;
            case 1:
                u2w2.value = 1;
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
    public void GetU2A2(int a2num)
    {
        switch (a2num)
        {
            case 0:
                u2a2.value = 0;
                break;
            case 1:
                u2a2.value = 1;
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
    public void GetU3W2(int w2num)
    {
        switch (w2num)
        {
            case 0:
                u3w2.value = 0;
                break;
            case 1:
                u3w2.value = 1;
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
    public void GetU3A2(int a2num)
    {
        switch (a2num)
        {
            case 0:
                u3a2.value = 0;
                break;
            case 1:
                u3a2.value = 1;
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
    public void GetU4W2(int w2num)
    {
        switch (w2num)
        {
            case 0:
                u4w2.value = 0;
                break;
            case 1:
                u4w2.value = 1;
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
    public void GetU4A2(int a2num)
    {
        switch (a2num)
        {
            case 0:
                u4a2.value = 0;
                break;
            case 1:
                u4a2.value = 1;
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
    public void GetU5W2(int w2num)
    {
        switch (w2num)
        {
            case 0:
                u5w2.value = 0;
                break;
            case 1:
                u5w2.value = 1;
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
    public void GetU5A2(int a2num)
    {
        switch (a2num)
        {
            case 0:
                u5a2.value = 0;
                break;
            case 1:
                u5a2.value = 1;
                break;
        }
    }

    //Code for saving ability choices as an int to load when the game starts
    public void SaveLoadout()
    {
        PlayerPrefs.SetInt("U1W1", u1w1.value);
        PlayerPrefs.SetInt("U1W2", u1w2.value);
        PlayerPrefs.SetInt("U1A1", u1a1.value);
        PlayerPrefs.SetInt("U1A2", u1a2.value);
        PlayerPrefs.SetInt("U2W1", u2w1.value);
        PlayerPrefs.SetInt("U2W2", u2w2.value);
        PlayerPrefs.SetInt("U2A1", u2a1.value);
        PlayerPrefs.SetInt("U2A2", u2a2.value);
        PlayerPrefs.SetInt("U3W1", u3w1.value);
        PlayerPrefs.SetInt("U3W2", u3w2.value);
        PlayerPrefs.SetInt("U3A1", u3a1.value);
        PlayerPrefs.SetInt("U3A2", u3a2.value);
        PlayerPrefs.SetInt("U4W1", u4w1.value);
        PlayerPrefs.SetInt("U4W2", u4w2.value);
        PlayerPrefs.SetInt("U4A1", u4a1.value);
        PlayerPrefs.SetInt("U4A2", u4a2.value);
        PlayerPrefs.SetInt("U5W1", u5w1.value);
        PlayerPrefs.SetInt("U5W2", u5w2.value);
        PlayerPrefs.SetInt("U5A1", u5a1.value);
        PlayerPrefs.SetInt("U5A2", u5a2.value);

    }
}
