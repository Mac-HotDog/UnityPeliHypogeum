using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum AbilityType { Damage, Debuff, Buff, Heal }
[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Ability")]
public class Ability : Item
{
    public AbilityType abilityType;

    public float potency = 0;
    public float area = 0;
    public float coolDown = 0;

    public AbilityEffect abilityEffect;

    public override void Use()
    {
        abilityEffect.UseAbility(potency, area);
    }
    public override float CustomFloat()
    {
        return coolDown;
    }
}
