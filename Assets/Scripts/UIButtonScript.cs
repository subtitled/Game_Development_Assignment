using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIButtonScript : MonoBehaviour
{
    public GameObject[] buttonList;
    public GameObject model;

    public int classNum;
    public int wep1;
    public int wep2;
    public int abil1;
    public int abil2;

    // Start is called before the first frame update
    void Start()
    {
        classNum = model.GetComponent<classScript>().classNum;
        wep1 = model.GetComponent<classScript>().wep_1;
        wep2 = model.GetComponent<classScript>().wep_2;
        abil1 = model.GetComponent<classScript>().abil_1;
        abil2 = model.GetComponent<classScript>().abil_2;

        switch (classNum)
        {
            case 0:
                switch (wep1)
                {
                    case 0:
                        buttonList[0].GetComponentInChildren<Text>().text = "War Wep 1.1";
                        break;
                    case 1:
                        buttonList[0].GetComponentInChildren<Text>().text = "War Wep 1.2";
                        break;
                }
                switch (wep2)
                {
                    case 0:
                        buttonList[1].GetComponentInChildren<Text>().text = "War Wep 2.1";
                        break;
                    case 1:
                        buttonList[1].GetComponentInChildren<Text>().text = "War Wep 2.2";
                        break;
                }
                switch (abil1)
                {
                    case 0:
                        buttonList[2].GetComponentInChildren<Text>().text = "War Abil 1.1";
                        break;
                    case 1:
                        buttonList[2].GetComponentInChildren<Text>().text = "War Abil 1.2";
                        break;
                }
                switch (abil2)
                {
                    case 0:
                        buttonList[3].GetComponentInChildren<Text>().text = "War Abil 2.1";
                        break;
                    case 1:
                        buttonList[3].GetComponentInChildren<Text>().text = "War Abil 2.2";
                        break;
                }
                break;
            case 1:
                switch (wep1)
                {
                    case 0:
                        buttonList[0].GetComponentInChildren<Text>().text = "Pri Wep 1.1";
                        break;
                    case 1:
                        buttonList[0].GetComponentInChildren<Text>().text = "Pri Wep 1.2";
                        break;
                }
                switch (wep2)
                {
                    case 0:
                        buttonList[1].GetComponentInChildren<Text>().text = "Pri Wep 2.1";
                        break;
                    case 1:
                        buttonList[1].GetComponentInChildren<Text>().text = "Pri Wep 2.2";
                        break;
                }
                switch (abil1)
                {
                    case 0:
                        buttonList[2].GetComponentInChildren<Text>().text = "Pri Abil 1.1";
                        break;
                    case 1:
                        buttonList[2].GetComponentInChildren<Text>().text = "Pri Abil 1.2";
                        break;
                }
                switch (abil2)
                {
                    case 0:
                        buttonList[3].GetComponentInChildren<Text>().text = "Pri Abil 2.1";
                        break;
                    case 1:
                        buttonList[3].GetComponentInChildren<Text>().text = "Pri Abil 2.2";
                        break;
                }
                break;
            case 2:
                switch (wep1)
                {
                    case 0:
                        buttonList[0].GetComponentInChildren<Text>().text = "Mag Wep 1.1";
                        break;
                    case 1:
                        buttonList[0].GetComponentInChildren<Text>().text = "Mag Wep 1.2";
                        break;
                }
                switch (wep2)
                {
                    case 0:
                        buttonList[1].GetComponentInChildren<Text>().text = "Mag Wep 2.1";
                        break;
                    case 1:
                        buttonList[1].GetComponentInChildren<Text>().text = "Mag Wep 2.2";
                        break;
                }
                switch (abil1)
                {
                    case 0:
                        buttonList[2].GetComponentInChildren<Text>().text = "Mag Abil 1.1";
                        break;
                    case 1:
                        buttonList[2].GetComponentInChildren<Text>().text = "Mag Abil 1.2";
                        break;
                }
                switch (abil2)
                {
                    case 0:
                        buttonList[3].GetComponentInChildren<Text>().text = "Mag Abil 2.1";
                        break;
                    case 1:
                        buttonList[3].GetComponentInChildren<Text>().text = "Mag Abil 2.2";
                        break;
                }
                break;
            case 3:
                switch (wep1)
                {
                    case 0:
                        buttonList[0].GetComponentInChildren<Text>().text = "Rog Wep 1.1";
                        break;
                    case 1:
                        buttonList[0].GetComponentInChildren<Text>().text = "Rog Wep 1.2";
                        break;
                }
                switch (wep2)
                {
                    case 0:
                        buttonList[1].GetComponentInChildren<Text>().text = "Rog Wep 2.1";
                        break;
                    case 1:
                        buttonList[1].GetComponentInChildren<Text>().text = "Rog Wep 2.2";
                        break;
                }
                switch (abil1)
                {
                    case 0:
                        buttonList[2].GetComponentInChildren<Text>().text = "Rog Abil 1.1";
                        break;
                    case 1:
                        buttonList[2].GetComponentInChildren<Text>().text = "Rog Abil 1.2";
                        break;
                }
                switch (abil2)
                {
                    case 0:
                        buttonList[3].GetComponentInChildren<Text>().text = "Rog Abil 2.1";
                        break;
                    case 1:
                        buttonList[3].GetComponentInChildren<Text>().text = "Rog Abil 2.2";
                        break;
                }
                break;
            case 4:
                switch (wep1)
                {
                    case 0:
                        buttonList[0].GetComponentInChildren<Text>().text = "Mar Wep 1.1";
                        break;
                    case 1:
                        buttonList[0].GetComponentInChildren<Text>().text = "Mar Wep 1.2";
                        break;
                }
                switch (wep2)
                {
                    case 0:
                        buttonList[1].GetComponentInChildren<Text>().text = "Mar Wep 2.1";
                        break;
                    case 1:
                        buttonList[1].GetComponentInChildren<Text>().text = "Mar Wep 2.2";
                        break;
                }
                switch (abil1)
                {
                    case 0:
                        buttonList[2].GetComponentInChildren<Text>().text = "Mar Abil 1.1";
                        break;
                    case 1:
                        buttonList[2].GetComponentInChildren<Text>().text = "Mar Abil 1.2";
                        break;
                }
                switch (abil2)
                {
                    case 0:
                        buttonList[3].GetComponentInChildren<Text>().text = "Mar Abil 2.1";
                        break;
                    case 1:
                        buttonList[3].GetComponentInChildren<Text>().text = "Mar Abil 2.2";
                        break;
                }
                break;
        }

    }

    // Update is called once per frame
    void Update()
    {
        //SHOULD IT BE IN UPDATE? MY BRAIN IS DIE
        //Check whether or not is player turn
        //if not player turn, hide playerTurnUI object
        //if player turn, show playerTUrnUI object

       
    }
}
