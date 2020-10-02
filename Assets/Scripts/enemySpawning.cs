using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemySpawning : MonoBehaviour
{
    public GameObject[] spawnPointList;
    public GameObject[] enemyModels;

    // Start is called before the first frame update
    public void enemySpawn()
    {
        Instantiate(enemyModels[0], spawnPointList[0].transform.position, Quaternion.Euler(0f, 180f, 0f));
        Instantiate(enemyModels[1], spawnPointList[1].transform.position, Quaternion.Euler(0f, 180f, 0f));
        Instantiate(enemyModels[2], spawnPointList[2].transform.position, Quaternion.Euler(0f, 180f, 0f));
        Instantiate(enemyModels[3], spawnPointList[3].transform.position, Quaternion.Euler(0f, 180f, 0f));
        Instantiate(enemyModels[4], spawnPointList[4].transform.position, Quaternion.Euler(0f, 180f, 0f));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
