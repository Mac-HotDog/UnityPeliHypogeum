using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBlast : AbilityEffect
{
    public override void UseAbility(float potency, float area)
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");

        foreach (var item in enemies)
        {
            EnemyStats enemy = item.GetComponent<EnemyStats>();
            enemy.TakeDamage(potency);
        }
    }
}
