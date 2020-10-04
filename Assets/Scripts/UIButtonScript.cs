using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIButtonScript : MonoBehaviour
{
    public GameObject[] buttonList; //used for storing button objects on the game UI
    public GameObject model; //used for storing the model that is spawned to get the values from their class number, weapon and ability
    public GameObject[] unitTexts;
    //used for storing unit values
    public int classNum;
    public int wep1;
    public int abil1;
    public int unitNum;


    void Start()
    {
        //sets the values for class number, weapon and ability
        classNum = model.GetComponent<classScript>().classNum;
        unitNum = model.GetComponent<classScript>().unitNum;
        wep1 = model.GetComponent<classScript>().wep_1;
        abil1 = model.GetComponent<classScript>().abil_1;

        //changes button text based on what class/weapon/ability has been chosen
        switch (classNum)
        {
            case 0:
                switch (wep1)
                {
                    case 0:
                        buttonList[0].GetComponentInChildren<Text>().text = "Sword";
                        break;
                    case 1:
                        buttonList[0].GetComponentInChildren<Text>().text = "Warhammer";
                        break;
                }
                switch (abil1)
                {
                    case 0:
                        buttonList[1].GetComponentInChildren<Text>().text = "Cleave";
                        break;
                    case 1:
                        buttonList[1].GetComponentInChildren<Text>().text = "Stun";
                        break;
                }
                break;
            case 1:
                switch (wep1)
                {
                    case 0:
                        buttonList[0].GetComponentInChildren<Text>().text = "Mace";
                        break;
                    case 1:
                        buttonList[0].GetComponentInChildren<Text>().text = "Morning Star";
                        break;
                }
                switch (abil1)
                {
                    case 0:
                        buttonList[1].GetComponentInChildren<Text>().text = "Heal";
                        break;
                    case 1:
                        buttonList[1].GetComponentInChildren<Text>().text = "Buff";
                        break;
                }
                break;
            case 2:
                switch (wep1)
                {
                    case 0:
                        buttonList[0].GetComponentInChildren<Text>().text = "Staff";
                        break;
                    case 1:
                        buttonList[0].GetComponentInChildren<Text>().text = "Wand";
                        break;
                }
                switch (abil1)
                {
                    case 0:
                        buttonList[1].GetComponentInChildren<Text>().text = "Fireball";
                        break;
                    case 1:
                        buttonList[1].GetComponentInChildren<Text>().text = "Magic Missile";
                        break;
                }
                break;
            case 3:
                switch (wep1)
                {
                    case 0:
                        buttonList[0].GetComponentInChildren<Text>().text = "Dagger";
                        break;
                    case 1:
                        buttonList[0].GetComponentInChildren<Text>().text = "Dual Daggers";
                        break;
                }
                switch (abil1)
                {
                    case 0:
                        buttonList[1].GetComponentInChildren<Text>().text = "Stab";
                        break;
                    case 1:
                        buttonList[1].GetComponentInChildren<Text>().text = "Slice";
                        break;
                }
                break;
            case 4:
                switch (wep1)
                {
                    case 0:
                        buttonList[0].GetComponentInChildren<Text>().text = "Crossbow";
                        break;
                    case 1:
                        buttonList[0].GetComponentInChildren<Text>().text = "Long Bow";
                        break;
                }
                switch (abil1)
                {
                    case 0:
                        buttonList[1].GetComponentInChildren<Text>().text = "Snipe";
                        break;
                    case 1:
                        buttonList[1].GetComponentInChildren<Text>().text = "Rapid Shot";
                        break;
                }
                break;
        }

        switch (unitNum)
        {
            case 0:
                unitTexts[0].gameObject.SetActive(true);
                break;
            case 1:
                unitTexts[1].gameObject.SetActive(true);
                break;
            case 2:
                unitTexts[2].gameObject.SetActive(true);
                break;
            case 3:
                unitTexts[3].gameObject.SetActive(true);
                break;
            case 4:
                unitTexts[4].gameObject.SetActive(true);
                break;
        }

    }

}
