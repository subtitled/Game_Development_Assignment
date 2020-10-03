using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//THIS SCRIPT IS JUST USED FOR SHOWING THE SPAWN POINTS IN SCENE VIEW
public class spawnPointGizmos: MonoBehaviour
{

    void OnDrawGizmos()
    {
        Gizmos.DrawIcon(new Vector3(transform.position.x, transform.position.y, transform.position.z), "wayPoint");
    }
}
