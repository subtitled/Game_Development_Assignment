using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyClassScript : MonoBehaviour
{
    //damage setup
    public float w1dmg;
    public float a1dmg;

    //Stat setup
    public int strength;
    public int agility;
    public int intelligence;
    public float health;
    public float movement;
    public float alertRange;
    public float engagedRange;
    public int initiative; //change depending on class

    //extra setup for referencing
    public int enemyClassNum;

    //setup for UI holder
    public GameObject enemyUI;
    // Start is called before the first frame update
    
    public void ClassSetUp()
    {
        //generates stats for classes (change value ranges based on class)
        switch (enemyClassNum)
        {
            case 0: //enemyWarrior
                strength = Random.Range(7, 9);
                agility = Random.Range(5, 7);
                intelligence = Random.Range(2, 5);
                health = Random.Range(110, 130);
                movement = 6;
                alertRange = 14.0f;
                engagedRange = 7.0f;
                initiative = Random.Range(1, 11) + agility;
                w1dmg = 30;
                a1dmg = 20;
                break;
            case 1: //enemyPriest
                strength = Random.Range(5, 7);
                agility = Random.Range(5, 7);
                intelligence = Random.Range(6, 8);
                health = Random.Range(100, 120);
                movement = 5;
                alertRange = 13.0f;
                engagedRange = 6.0f;
                initiative = Random.Range(1, 11) + agility;
                w1dmg = 30;
                a1dmg = 30;
                break;
            case 2: //enemyMage
                strength = Random.Range(2, 5);
                agility = Random.Range(6, 8);
                intelligence = Random.Range(7, 9);
                health = Random.Range(90, 110);
                movement = 5;
                alertRange = 13.0f;
                engagedRange = 8.0f;
                initiative = Random.Range(1, 11) + agility;
                w1dmg = 30;
                a1dmg = 20;
                break;
            case 3: //enemyRogue
                strength = Random.Range(6, 8);
                agility = Random.Range(7, 9);
                intelligence = Random.Range(5, 6);
                health = Random.Range(100, 110);
                movement = 6;
                alertRange = 14.0f;
                engagedRange = 7.0f;
                initiative = Random.Range(1, 11) + agility;
                w1dmg = 30;
                a1dmg = 20;
                break;
            case 4: //enemyMarksman
                strength = Random.Range(2, 5);
                agility = Random.Range(6, 8);
                intelligence = Random.Range(2, 5);
                health = Random.Range(90, 110);
                movement = 4;
                alertRange = 15.0f;
                engagedRange = 10.0f;
                initiative = Random.Range(1, 11) + agility;
                w1dmg = 30;
                a1dmg = 20;
                break;
        }
    }

    public void Attack(Vector3 target)
    {
        // Basic attack, hits targets in a small area.
        Collider[] hits = Physics.OverlapSphere(target, 1f);
        foreach (Collider hit in hits)
        {
            if (hit.CompareTag("Player"))
            {
                hit.SendMessage("ApplyDamage", w1dmg);
            }
        }
    }

    public void Defend(bool defendStatus)
    {
        // Blocks the first hit until the next turn.
        defendStatus = true;
    }
    
    public void WarriorAbility1()
    {
        // Damages nearby players.
        Collider[] hits = Physics.OverlapSphere(transform.position, 3.0f);
        foreach (Collider hit in hits)
        {
            if (hit.CompareTag("Player"))
            {
                hit.SendMessage("ApplyDamage", a1dmg);
            }
        }
    }
    
    public void PriestAbility1(Vector3 target)
    {
        // Heals allies within a target area.
        Collider[] hits = Physics.OverlapSphere(target, 2.0f);
        foreach (Collider hit in hits)
        {
            if (hit.CompareTag("Enemy"))
            {
                hit.SendMessage("ApplyDamage", -a1dmg);
            }
        }
    }

    public void MageAbility1(Vector3 target)
    {
        // Damage all targets in a targeted area.
        Collider[] hits = Physics.OverlapSphere(target, 2.0f);
        foreach (Collider hit in hits)
        {
            if (hit.CompareTag("Player"))
            {
                hit.SendMessage("ApplyDamage", a1dmg);
            }
        }
    }
    
    public void RogueAbility1(Vector3 target)
    {
        // Deals high damage to a single target.
        Collider[] hits = Physics.OverlapSphere(target, 0.5f);
        foreach (Collider hit in hits)
        {
            if (hit.CompareTag("Player"))
            {
                hit.SendMessage("ApplyDamage", a1dmg*1.75f);
            }
        }
    }

    public void MarksmanAbility1(Vector3 target)
    {
        // Deals more damage to targets further away, less to close targets.
        Collider[] hits = Physics.OverlapSphere(target, 0.5f);
        foreach (Collider hit in hits)
        {
            if (hit.CompareTag("Player"))
            {
                float scaledDamage = a1dmg * (Vector3.Distance(transform.position, target) / 5f);
                hit.SendMessage("ApplyDamage", scaledDamage);
            }
        }
    }



}