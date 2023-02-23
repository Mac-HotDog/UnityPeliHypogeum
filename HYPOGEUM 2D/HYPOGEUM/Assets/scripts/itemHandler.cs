using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class itemHandler : MonoBehaviour
{
    /*[System.Serializable]
    public class Item
    {
        public GameObject item;
    }*/
    public Item[] items;

    /*public void applyItems()
    {
        GameObject go = gameObject;
        GladiatorStats stats = go.GetComponent<GladiatorStats>();

        if (items == null)
        {
            return;
        }
        else
        {
            foreach (var item in items)
            {
                if (item.type == ItemType.weapon)
                {
                    stats.damage += item.damage;
                    stats.range = item.range;
                    stats.attackSpeed = item.attackSpeed;
                }
                if (item.type == ItemType.armor)
                {
                    stats.hp += item.hp;
                    stats.startHp += item.hp;
                    //stats.armor = item.armor;
                    //stats.movementSpeed = item.movementSpeed;
                }
            }
        }
        
    }*/
}
