using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawning : MonoBehaviour
{
    public GameObject[] spawnPointList;
    public GameObject[] classModels;

    public int unitOne;
    public int unitTwo;
    public int unitThree;
    public int unitFour;
    public int unitFive;

    // Start is called before the first frame update
    public void PlayerSpawn()
    {
        //get value of class
        //switch
        //spawn depending on number
        //do 5 times
        unitOne = PlayerPrefs.GetInt("UnitOne");
        unitTwo = PlayerPrefs.GetInt("UnitTwo");
        unitThree = PlayerPrefs.GetInt("UnitThree");
        unitFour = PlayerPrefs.GetInt("UnitFour");
        unitFive = PlayerPrefs.GetInt("UnitFive");

        switch (unitOne)
        {
            case 0:
                classModels[0].GetComponent<classScript>().unitNum = 0;
                Instantiate(classModels[0], spawnPointList[0].transform.position, Quaternion.identity);
                break;
            case 1:
                classModels[1].GetComponent<classScript>().unitNum = 0;
                Instantiate(classModels[1], spawnPointList[0].transform.position, Quaternion.identity);
                break;
            case 2:
                classModels[2].GetComponent<classScript>().unitNum = 0;
                Instantiate(classModels[2], spawnPointList[0].transform.position, Quaternion.identity);
                break;
            case 3:
                classModels[3].GetComponent<classScript>().unitNum = 0;
                Instantiate(classModels[3], spawnPointList[0].transform.position, Quaternion.identity);
                break;
            case 4:
                classModels[4].GetComponent<classScript>().unitNum = 0;
                Instantiate(classModels[4], spawnPointList[0].transform.position, Quaternion.identity);
                break;
        }
        switch (unitTwo)
        {
            case 0:
                classModels[0].GetComponent<classScript>().unitNum = 1;
                Instantiate(classModels[0], spawnPointList[1].transform.position, Quaternion.identity);
                break;
            case 1:
                classModels[1].GetComponent<classScript>().unitNum = 1;
                Instantiate(classModels[1], spawnPointList[1].transform.position, Quaternion.identity);
                break;
            case 2:
                classModels[2].GetComponent<classScript>().unitNum = 1;
                Instantiate(classModels[2], spawnPointList[1].transform.position, Quaternion.identity);
                break;
            case 3:
                classModels[3].GetComponent<classScript>().unitNum = 1;
                Instantiate(classModels[3], spawnPointList[1].transform.position, Quaternion.identity);
                break;
            case 4:
                classModels[4].GetComponent<classScript>().unitNum = 1;
                Instantiate(classModels[4], spawnPointList[1].transform.position, Quaternion.identity);
                break;
        }
        switch (unitThree)
        {
            case 0:
                classModels[0].GetComponent<classScript>().unitNum = 2;
                Instantiate(classModels[0], spawnPointList[2].transform.position, Quaternion.identity);
                break;
            case 1:
                classModels[1].GetComponent<classScript>().unitNum = 2;
                Instantiate(classModels[1], spawnPointList[2].transform.position, Quaternion.identity);
                break;
            case 2:
                classModels[2].GetComponent<classScript>().unitNum = 2;
                Instantiate(classModels[2], spawnPointList[2].transform.position, Quaternion.identity);
                break;
            case 3:
                classModels[3].GetComponent<classScript>().unitNum = 2;
                Instantiate(classModels[3], spawnPointList[2].transform.position, Quaternion.identity);
                break;
            case 4:
                classModels[4].GetComponent<classScript>().unitNum = 2;
                Instantiate(classModels[4], spawnPointList[2].transform.position, Quaternion.identity);
                break;
        }
        switch (unitFour)
        {
            case 0:
                classModels[0].GetComponent<classScript>().unitNum = 3;
                Instantiate(classModels[0], spawnPointList[3].transform.position, Quaternion.identity);
                break;
            case 1:
                classModels[1].GetComponent<classScript>().unitNum = 3;
                Instantiate(classModels[1], spawnPointList[3].transform.position, Quaternion.identity);
                break;
            case 2:
                classModels[2].GetComponent<classScript>().unitNum = 3;
                Instantiate(classModels[2], spawnPointList[3].transform.position, Quaternion.identity);
                break;
            case 3:
                classModels[3].GetComponent<classScript>().unitNum = 3;
                Instantiate(classModels[3], spawnPointList[3].transform.position, Quaternion.identity);
                break;
            case 4:
                classModels[4].GetComponent<classScript>().unitNum = 3;
                Instantiate(classModels[4], spawnPointList[3].transform.position, Quaternion.identity);
                break;
        }
        switch (unitFive)
        {
            case 0:
                classModels[0].GetComponent<classScript>().unitNum = 4;
                Instantiate(classModels[0], spawnPointList[4].transform.position, Quaternion.identity);
                break;
            case 1:
                classModels[1].GetComponent<classScript>().unitNum = 4;
                Instantiate(classModels[1], spawnPointList[4].transform.position, Quaternion.identity);
                break;
            case 2:
                classModels[2].GetComponent<classScript>().unitNum = 4;
                Instantiate(classModels[2], spawnPointList[4].transform.position, Quaternion.identity);
                break;
            case 3:
                classModels[3].GetComponent<classScript>().unitNum = 4;
                Instantiate(classModels[3], spawnPointList[4].transform.position, Quaternion.identity);
                break;
            case 4:
                classModels[4].GetComponent<classScript>().unitNum = 4;
                Instantiate(classModels[4], spawnPointList[4].transform.position, Quaternion.identity);
                break;
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
