using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemType { equipment, ability }
[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Item", order = 1)]

public class Item : ScriptableObject
{
    new public string name = "New Item";
    public int value;
    public ItemType type;
    public Sprite icon;

    public virtual void Use()
    {
        // this function is supposed to be overriden
    }

    public virtual string ReturnType()
    {
        return type.ToString();
    }
    public virtual void UnUse()
    {
        // this function is supposed to be overriden
    }
    public virtual void Replace()
    {
        // this function is supposed to be overriden
    }
    public virtual void Drop()
    {
        Inventory.instance.RemoveItem(this);
    }
    public virtual float CustomFloat()
    {
        return 0;
    }
}
