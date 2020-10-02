using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class menuSpawning : MonoBehaviour
{
    public GameObject[] spawnPointList;
    public GameObject[] classModels;
    public Dropdown[] dropdowns;

    public int unitOne;
    public int unitTwo;
    public int unitThree;
    public int unitFour;
    public int unitFive;

    private GameObject clone1;
    private GameObject clone2;
    private GameObject clone3;
    private GameObject clone4;
    private GameObject clone5;

    // Start is called before the first frame update
    void Start()
    {
        //get value of class
        //switch
        //spawn depending on number
        //do 5 times
        unitOne = dropdowns[0].value;
        unitTwo = dropdowns[1].value;
        unitThree = dropdowns[2].value;
        unitFour = dropdowns[3].value;
        unitFive = dropdowns[4].value;

        switch (unitOne)
        {
            case 0:
                clone1 = Instantiate(classModels[0], spawnPointList[0].transform.position, Quaternion.identity);
                break;
            case 1:
                clone1 = Instantiate(classModels[1], spawnPointList[0].transform.position, Quaternion.identity);
                break;
            case 2:
                clone1 = Instantiate(classModels[2], spawnPointList[0].transform.position, Quaternion.identity);
                break;
            case 3:
                clone1 = Instantiate(classModels[3], spawnPointList[0].transform.position, Quaternion.identity);
                break;
            case 4:
                clone1 = Instantiate(classModels[4], spawnPointList[0].transform.position, Quaternion.identity);
                break;
        }
        switch (unitTwo)
        {
            case 0:
                clone2 = Instantiate(classModels[0], spawnPointList[1].transform.position, Quaternion.identity);
                break;
            case 1:
                clone2 = Instantiate(classModels[1], spawnPointList[1].transform.position, Quaternion.identity);
                break;
            case 2:
                clone2 = Instantiate(classModels[2], spawnPointList[1].transform.position, Quaternion.identity);
                break;
            case 3:
                clone2 = Instantiate(classModels[3], spawnPointList[1].transform.position, Quaternion.identity);
                break;
            case 4:
                clone2 = Instantiate(classModels[4], spawnPointList[1].transform.position, Quaternion.identity);
                break;
        }
        switch (unitThree)
        {
            case 0:
                clone3 = Instantiate(classModels[0], spawnPointList[2].transform.position, Quaternion.identity);
                break;
            case 1:
                clone3 = Instantiate(classModels[1], spawnPointList[2].transform.position, Quaternion.identity);
                break;
            case 2:
                clone3 = Instantiate(classModels[2], spawnPointList[2].transform.position, Quaternion.identity);
                break;
            case 3:
                clone3 = Instantiate(classModels[3], spawnPointList[2].transform.position, Quaternion.identity);
                break;
            case 4:
                clone3 = Instantiate(classModels[4], spawnPointList[2].transform.position, Quaternion.identity);
                break;
        }
        switch (unitFour)
        {
            case 0:
                clone4 = Instantiate(classModels[0], spawnPointList[3].transform.position, Quaternion.identity);
                break;
            case 1:
                clone4 = Instantiate(classModels[1], spawnPointList[3].transform.position, Quaternion.identity);
                break;
            case 2:
                clone4 = Instantiate(classModels[2], spawnPointList[3].transform.position, Quaternion.identity);
                break;
            case 3:
                clone4 = Instantiate(classModels[3], spawnPointList[3].transform.position, Quaternion.identity);
                break;
            case 4:
                clone4 = Instantiate(classModels[4], spawnPointList[3].transform.position, Quaternion.identity);
                break;
        }
        switch (unitFive)
        {
            case 0:
                clone5 = Instantiate(classModels[0], spawnPointList[4].transform.position, Quaternion.identity);
                break;
            case 1:
                clone5 = Instantiate(classModels[1], spawnPointList[4].transform.position, Quaternion.identity);
                break;
            case 2:
                clone5 = Instantiate(classModels[2], spawnPointList[4].transform.position, Quaternion.identity);
                break;
            case 3:
                clone5 = Instantiate(classModels[3], spawnPointList[4].transform.position, Quaternion.identity);
                break;
            case 4:
                clone5 = Instantiate(classModels[4], spawnPointList[4].transform.position, Quaternion.identity);
                break;
        }

    }

    // Update is called once per frame
    void Update()
    {
        unitOne = dropdowns[0].value;
        unitTwo = dropdowns[1].value;
        unitThree = dropdowns[2].value;
        unitFour = dropdowns[3].value;
        unitFive = dropdowns[4].value;


    }
}
