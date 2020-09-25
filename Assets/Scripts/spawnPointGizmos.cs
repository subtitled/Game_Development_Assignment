using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnPointGizmos: MonoBehaviour
{

    void OnDrawGizmos()
    {
        Gizmos.DrawIcon(new Vector3(transform.position.x, transform.position.y, transform.position.z), "wayPoint");
    }
}
