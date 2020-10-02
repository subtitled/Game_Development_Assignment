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
    public int prevU1;
    public int prevU2;
    public int prevU3;
    public int prevU4;
    public int prevU5;


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
        prevU1 = unitOne;
        unitTwo = dropdowns[1].value;
        prevU2 = unitTwo;
        unitThree = dropdowns[2].value;
        prevU3 = unitThree;
        unitFour = dropdowns[3].value;
        prevU4 = unitFour;
        unitFive = dropdowns[4].value;
        prevU5 = unitFive;

        switch (unitOne)
        {
            case 0:
                clone1 = Instantiate(classModels[0], spawnPointList[0].transform.position, Quaternion.Euler(0f, 150f, 0f));
                break;
            case 1:
                clone1 = Instantiate(classModels[1], spawnPointList[0].transform.position, Quaternion.Euler(0f, 150f, 0f));
                break;
            case 2:
                clone1 = Instantiate(classModels[2], spawnPointList[0].transform.position, Quaternion.Euler(0f, 150f, 0f));
                break;
            case 3:
                clone1 = Instantiate(classModels[3], spawnPointList[0].transform.position, Quaternion.Euler(0f, 150f, 0f));
                break;
            case 4:
                clone1 = Instantiate(classModels[4], spawnPointList[0].transform.position, Quaternion.Euler(0f, 150f, 0f));
                break;
        }
        switch (unitTwo)
        {
            case 0:
                clone2 = Instantiate(classModels[0], spawnPointList[1].transform.position, Quaternion.Euler(0f, 150f, 0f));
                break;
            case 1:
                clone2 = Instantiate(classModels[1], spawnPointList[1].transform.position, Quaternion.Euler(0f, 150f, 0f));
                break;
            case 2:
                clone2 = Instantiate(classModels[2], spawnPointList[1].transform.position, Quaternion.Euler(0f, 150f, 0f));
                break;
            case 3:
                clone2 = Instantiate(classModels[3], spawnPointList[1].transform.position, Quaternion.Euler(0f, 150f, 0f));
                break;
            case 4:
                clone2 = Instantiate(classModels[4], spawnPointList[1].transform.position, Quaternion.Euler(0f, 150f, 0f));
                break;
        }
        switch (unitThree)
        {
            case 0:
                clone3 = Instantiate(classModels[0], spawnPointList[2].transform.position, Quaternion.Euler(0f, 180f, 0f));
                break;
            case 1:
                clone3 = Instantiate(classModels[1], spawnPointList[2].transform.position, Quaternion.Euler(0f, 180f, 0f));
                break;
            case 2:
                clone3 = Instantiate(classModels[2], spawnPointList[2].transform.position, Quaternion.Euler(0f, 180f, 0f));
                break;
            case 3:
                clone3 = Instantiate(classModels[3], spawnPointList[2].transform.position, Quaternion.Euler(0f, 180f, 0f));
                break;
            case 4:
                clone3 = Instantiate(classModels[4], spawnPointList[2].transform.position, Quaternion.Euler(0f, 180f, 0f));
                break;
        }
        switch (unitFour)
        {
            case 0:
                clone4 = Instantiate(classModels[0], spawnPointList[3].transform.position, Quaternion.Euler(0f, 190f, 0f));
                break;
            case 1:
                clone4 = Instantiate(classModels[1], spawnPointList[3].transform.position, Quaternion.Euler(0f, 190f, 0f));
                break;
            case 2:
                clone4 = Instantiate(classModels[2], spawnPointList[3].transform.position, Quaternion.Euler(0f, 190f, 0f));
                break;
            case 3:
                clone4 = Instantiate(classModels[3], spawnPointList[3].transform.position, Quaternion.Euler(0f, 190f, 0f));
                break;
            case 4:
                clone4 = Instantiate(classModels[4], spawnPointList[3].transform.position, Quaternion.Euler(0f, 190f, 0f));
                break;
        }
        switch (unitFive)
        {
            case 0:
                clone5 = Instantiate(classModels[0], spawnPointList[4].transform.position, Quaternion.Euler(0f, 200f, 0f));
                break;
            case 1:
                clone5 = Instantiate(classModels[1], spawnPointList[4].transform.position, Quaternion.Euler(0f, 200f, 0f));
                break;
            case 2:
                clone5 = Instantiate(classModels[2], spawnPointList[4].transform.position, Quaternion.Euler(0f, 200f, 0f));
                break;
            case 3:
                clone5 = Instantiate(classModels[3], spawnPointList[4].transform.position, Quaternion.Euler(0f, 200f, 0f));
                break;
            case 4:
                clone5 = Instantiate(classModels[4], spawnPointList[4].transform.position, Quaternion.Euler(0f, 200f, 0f));
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

        if (unitOne != prevU1)
        {
            prevU1 = unitOne;
            if (unitOne == 0)
            {
                Destroy(clone1);
                clone1 = Instantiate(classModels[0], spawnPointList[0].transform.position, Quaternion.Euler(0f, 150f, 0f));
            }
            else if (unitOne == 1)
            {
                Destroy(clone1);
                clone1 = Instantiate(classModels[1], spawnPointList[0].transform.position, Quaternion.Euler(0f, 150f, 0f));
            }
            else if (unitOne == 2)
            {
                Destroy(clone1);
                clone1 = Instantiate(classModels[2], spawnPointList[0].transform.position, Quaternion.Euler(0f, 150f, 0f));
            }
            else if (unitOne == 3)
            {
                Destroy(clone1);
                clone1 = Instantiate(classModels[3], spawnPointList[0].transform.position, Quaternion.Euler(0f, 150f, 0f));
            }
            else
            {
                Destroy(clone1);
                clone1 = Instantiate(classModels[4], spawnPointList[0].transform.position, Quaternion.Euler(0f, 150f, 0f));
            }
        }
        if (unitTwo != prevU2)
        {
            prevU2 = unitTwo;
            if (unitTwo == 0)
            {
                Destroy(clone2);
                clone2 = Instantiate(classModels[0], spawnPointList[1].transform.position, Quaternion.Euler(0f, 150f, 0f));
            }
            else if (unitTwo == 1)
            {
                Destroy(clone2);
                clone2 = Instantiate(classModels[1], spawnPointList[1].transform.position, Quaternion.Euler(0f, 150f, 0f));
            }
            else if (unitTwo == 2)
            {
                Destroy(clone2);
                clone2 = Instantiate(classModels[2], spawnPointList[1].transform.position, Quaternion.Euler(0f, 150f, 0f));
            }
            else if (unitTwo == 3)
            {
                Destroy(clone2);
                clone2 = Instantiate(classModels[3], spawnPointList[1].transform.position, Quaternion.Euler(0f, 150f, 0f));
            }
            else
            {
                Destroy(clone2);
                clone2 = Instantiate(classModels[4], spawnPointList[1].transform.position, Quaternion.Euler(0f, 150f, 0f));
            }
        }
        if (unitThree != prevU3)
        {
            prevU3 = unitThree;
            if (unitThree == 0)
            {
                Destroy(clone3);
                clone3 = Instantiate(classModels[0], spawnPointList[2].transform.position, Quaternion.Euler(0f, 180f, 0f));
            }
            else if (unitThree == 1)
            {
                Destroy(clone3);
                clone3 = Instantiate(classModels[1], spawnPointList[2].transform.position, Quaternion.Euler(0f, 180f, 0f));
            }
            else if (unitThree == 2)
            {
                Destroy(clone3);
                clone3 = Instantiate(classModels[2], spawnPointList[2].transform.position, Quaternion.Euler(0f, 180f, 0f));
            }
            else if (unitThree == 3)
            {
                Destroy(clone3);
                clone3 = Instantiate(classModels[3], spawnPointList[2].transform.position, Quaternion.Euler(0f, 180f, 0f));
            }
            else
            {
                Destroy(clone3);
                clone3 = Instantiate(classModels[4], spawnPointList[2].transform.position, Quaternion.Euler(0f, 180f, 0f));
            }
        }
        if (unitFour != prevU4)
        {
            prevU4 = unitFour;
            if (unitFour == 0)
            {
                Destroy(clone4);
                clone4 = Instantiate(classModels[0], spawnPointList[3].transform.position, Quaternion.Euler(0f, 190f, 0f));
            }
            else if (unitFour == 1)
            {
                Destroy(clone4);
                clone4 = Instantiate(classModels[1], spawnPointList[3].transform.position, Quaternion.Euler(0f, 190f, 0f));
            }
            else if (unitFour == 2)
            {
                Destroy(clone4);
                clone4 = Instantiate(classModels[2], spawnPointList[3].transform.position, Quaternion.Euler(0f, 190f, 0f));
            }
            else if (unitFour == 3)
            {
                Destroy(clone4);
                clone4 = Instantiate(classModels[3], spawnPointList[3].transform.position, Quaternion.Euler(0f, 190f, 0f));
            }
            else
            {
                Destroy(clone4);
                clone4 = Instantiate(classModels[4], spawnPointList[3].transform.position, Quaternion.Euler(0f, 190f, 0f));
            }
        }
        if (unitFive != prevU5)
        {
            prevU5 = unitFive;
            if (unitFive == 0)
            {
                Destroy(clone5);
                clone5 = Instantiate(classModels[0], spawnPointList[4].transform.position, Quaternion.Euler(0f, 200f, 0f));
            }
            else if (unitFive == 1)
            {
                Destroy(clone5);
                clone5 = Instantiate(classModels[1], spawnPointList[4].transform.position, Quaternion.Euler(0f, 200f, 0f));
            }
            else if (unitFive == 2)
            {
                Destroy(clone5);
                clone5 = Instantiate(classModels[2], spawnPointList[4].transform.position, Quaternion.Euler(0f, 200f, 0f));
            }
            else if (unitFive == 3)
            {
                Destroy(clone5);
                clone5 = Instantiate(classModels[3], spawnPointList[4].transform.position, Quaternion.Euler(0f, 200f, 0f));
            }
            else
            {
                Destroy(clone5);
                clone5 = Instantiate(classModels[4], spawnPointList[4].transform.position, Quaternion.Euler(0f, 200f, 0f));
            }
        }
    }
}
