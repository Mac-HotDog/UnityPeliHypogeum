using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealAll : AbilityEffect
{
    public override void UseAbility(float potency, float area)
    {
        GameObject[] players = GameObject.FindGameObjectsWithTag("Player");

        foreach (var item in players)
        {
            GladiatorStats gladiator = item.GetComponent<GladiatorStats>();
            if ((gladiator.startHp - gladiator.hp) <= potency)
            {
                gladiator.hp = gladiator.startHp;
            }
            else
            {
                gladiator.hp += potency;
                gladiator.healthBar.fillAmount = gladiator.startHp / gladiator.hp;
            }
        }
    }
}
