//File used to store enemyWarrior AI, stats and abilities
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyWarrior : MonoBehaviour
{
    public enum FSMState
    {
        None,
        Idle,
        Move,
        Defend,
        Wep1,
        Wep2,
        Abil1,
        Abil2,
        Dead
    }

    public FSMState curState;

    protected bool isDead;
    protected GameObject[] playerUnits;

    //Stat setup (might change later)
    public int strength;
    public int agility;
    public int intelligence;
    public int health;
    public int movement;
    public int initiative;



    // Start is called before the first frame update
    void Start()
    {
        curState = FSMState.Idle;

        isDead = false;

        //TODO find closest player unit
        playerUnits = GameObject.FindGameObjectsWithTag("Player");
        getClosestPlayer();

        //Setting stat values
        strength = Random.Range(7, 9);
        agility = Random.Range(5, 7);
        intelligence = Random.Range(2, 5);
        health = Random.Range(110, 130);
        movement = 3;
        initiative = Random.Range(1, 11) + agility;
    }

    // Update is called once per frame
    void Update()
    {
        switch (curState)
        {
            case FSMState.Idle: UpdateIdleState(); break;
            case FSMState.Move: UpdateMoveState(); break;
            case FSMState.Defend: UpdateDefendState(); break;
            case FSMState.Wep1: UpdateWep1State(); break;
            case FSMState.Wep2: UpdateWep2State(); break;
            case FSMState.Abil1: UpdateAbil1State(); break;
            case FSMState.Abil2: UpdateAbil2State(); break;
            case FSMState.Dead: UpdateDeadState(); break;
        }


    }

    //TODO find closest player unit
    Transform getClosestPlayer(Transform[] players)
    {
        Transform transformMin = null;
        float minDist = Mathf.Infinity;
        Vector3 currentPos = transform.position;
        foreach (Transform t in players)
        {
            float dist = Vector3.Distance(t.position, currentPos);
            if (dist < minDist)
            {
                transformMin = t;
                minDist = dist;
            }
        }
        return transformMin;
    }

    void UpdateIdleState() 
    {
        
    }

    void UpdateMoveState()
    {

    }

    void UpdateDefendState()
    {

    }

    void UpdateWep1State()
    {

    }

    void UpdateWep2State()
    {

    }

    void UpdateAbil1State()
    {

    }

    void UpdateAbil2State()
    {

    }

    void UpdateDeadState()
    {

    }
}
