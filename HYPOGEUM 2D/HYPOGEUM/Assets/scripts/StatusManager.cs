using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatusManager : MonoBehaviour
{

    #region Singleton
    public static StatusManager instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    #endregion

    public void UpdateGladiatorStats(Equipment newItem, Equipment oldItem, GladiatorStats gladiatorStats)
    {
        if(oldItem != null)
        {
            gladiatorStats.hp -= oldItem.hp;
            gladiatorStats.startHp -= oldItem.hp;
            gladiatorStats.damage -= oldItem.damage;
            gladiatorStats.attackSpeed -= oldItem.damage;
            gladiatorStats.range -= oldItem.range;
            gladiatorStats.baseRange -= oldItem.range;
            gladiatorStats.movementSpeed -= oldItem.movementSpeed;
            gladiatorStats.armor -= oldItem.armor;
        }
        if (newItem != null)
        {
            gladiatorStats.hp += newItem.hp;
            gladiatorStats.startHp += newItem.hp;
            gladiatorStats.damage += newItem.damage;
            gladiatorStats.attackSpeed += newItem.damage;
            gladiatorStats.range += newItem.range;
            gladiatorStats.baseRange += newItem.range;
            gladiatorStats.movementSpeed += newItem.movementSpeed;
            gladiatorStats.armor += newItem.armor;
        }
    }
}
