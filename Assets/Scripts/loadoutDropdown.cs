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
        unitOne = PlayerPrefs.GetInt("UnitOne");
        unitTwo = PlayerPrefs.GetInt("UnitTwo");
        unitThree = PlayerPrefs.GetInt("UnitThree");
        unitFour = PlayerPrefs.GetInt("UnitFour");
        unitFive = PlayerPrefs.GetInt("UnitFive");
        //do this for every unit with switches for every class
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
        }

    }
    public void GetU1W1()
    {

    }
}
