using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class dropdown : MonoBehaviour
{
   
    public Dropdown unitOne;
    public Dropdown unitTwo;
    public Dropdown unitThree;
    public Dropdown unitFour;
    public Dropdown unitFive;


    public void GetUnitOne(int classNum)
    {
        //sets the value based on class picked
        switch (classNum)
        {
            case 0: //warrior
                unitOne.value = 0;
                break;
            case 1: //priest
                unitOne.value = 1;
                break;
            case 2: //mage
                unitOne.value = 2;
                break;
            case 3: //Rogue
                unitOne.value = 3;
                break;
            case 4: //Marksman
                unitOne.value = 4;
                break;
        }
    }

    public void GetUnitTwo(int classNum)
    {
        //sets the value based on class picked
        switch (classNum)
        {
            case 0: //warrior
                unitTwo.value = 0;
                break;
            case 1: //priest
                unitTwo.value = 1;
                break;
            case 2: //mage
                unitTwo.value = 2;
                break;
            case 3: //Rogue
                unitTwo.value = 3;
                break;
            case 4: //Marksman
                unitTwo.value = 4;
                break;
        }
    }

    public void GetUnitThree(int classNum)
    {
        //sets the value based on class picked
        switch (classNum)
        {
            case 0: //warrior
                unitThree.value = 0;
                break;
            case 1: //priest
                unitThree.value = 1;
                break;
            case 2: //mage
                unitThree.value = 2;
                break;
            case 3: //Rogue
                unitThree.value = 3;
                break;
            case 4: //Marksman
                unitThree.value = 4;
                break;
        }
    }

    public void GetUnitFour(int classNum)
    {
        //sets the value based on class picked
        switch (classNum)
        {
            case 0: //warrior
                unitFour.value = 0;
                break;
            case 1: //priest
                unitFour.value = 1;
                break;
            case 2: //mage
                unitFour.value = 2;
                break;
            case 3: //Rogue
                unitFour.value = 3;
                break;
            case 4: //Marksman
                unitFour.value = 4;
                break;
        }
    }

    public void GetUnitFive(int classNum)
    {
        //sets the value based on class picked
        switch (classNum)
        {
            case 0: //warrior
                unitFive.value = 0;
                break;
            case 1: //priest
                unitFive.value = 1;
                break;
            case 2: //mage
                unitFive.value = 2;
                break;
            case 3: //Rogue
                unitFive.value = 3;
                break;
            case 4: //Marksman
                unitFive.value = 4;
                break;
        }
    }

    //used for saving teams choices to PlayerPrefs to load when the game starts
    public void SaveTeam()
    {
        PlayerPrefs.SetInt("UnitOne", unitOne.value);
        PlayerPrefs.SetInt("UnitTwo", unitTwo.value);
        PlayerPrefs.SetInt("UnitThree", unitThree.value);
        PlayerPrefs.SetInt("UnitFour", unitFour.value);
        PlayerPrefs.SetInt("UnitFive", unitFive.value);
    }
}

