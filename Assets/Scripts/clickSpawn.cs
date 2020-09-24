using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class clickSpawn : MonoBehaviour
{
    Ray myRay;
    RaycastHit hit;
    public GameObject charModel;
    public List<int> team;

    void Start()
    {
        //adds class choices to list for spawning later
        team.Add(PlayerPrefs.GetInt("UnitOne"));
        team.Add(PlayerPrefs.GetInt("UnitTwo"));
        team.Add(PlayerPrefs.GetInt("UnitThree"));
        team.Add(PlayerPrefs.GetInt("UnitFour"));
        team.Add(PlayerPrefs.GetInt("UnitFive"));
    }
    // Update is called once per frame
    void Update()
    {
        //CHECK AMMO SCRIPT FOR IDEA HOW TO SPAWN LIMITED AMOUNT OF UNITS
        myRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(myRay, out hit))
            {
                if (Input.GetMouseButtonDown(0))
                {
                    Instantiate(charModel, hit.point, Quaternion.identity);
                }
            }
    }

}
