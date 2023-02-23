using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EquipType { WEAPON, HEAD, TORSO, MISC, FEET }

[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Equipment")]

public class Equipment : Item
{
    public EquipType equipType;

    public float hp;
    public float armor;
    public float movementSpeed;
    public float range;
    public float attackSpeed;
    public float damage;

    public override void Use()
    {
        base.Use();
        EquipmentManager.instance.Equip(this);
    }
    public override void UnUse()
    {
        base.UnUse();
        EquipmentManager.instance.UnEquip(this);
    }
    public override void Replace()
    {
        base.Replace();
        EquipmentManager.instance.Replace(this);
    }
    public override string ReturnType()
    {
        return equipType.ToString();
    }
}
