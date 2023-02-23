using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipmentManager : MonoBehaviour
{
    public class Gladiator
    {
        public GladiatorStats gladiator;
        public Equipment[] currentEquipment;
    }
    public List<Gladiator> gladiators = new List<Gladiator>();
    public Gladiator selectedGladiator;
    #region Singleton
    public static EquipmentManager instance;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this);
        }
        else
        {
            Destroy(this.gameObject);
            
        }
    }
    #endregion Singleton

    public void SelectedGladiator(int i)
    {
        selectedGladiator = gladiators[i];
    }
    

    //public delegate void OnEquipmentChangedCallback();
    //public OnEquipmentChangedCallback onEquipmentChangedCallback;

    private void Start()
    {
        for (int i = 0; i < GameObject.FindGameObjectsWithTag("Player").Length; i++)
        {
            gladiators.Add(new Gladiator { gladiator = GameObject.FindGameObjectsWithTag("Player")[i].GetComponent<GladiatorStats>() });
        }
        foreach(var item in PlacementManager.instance.gladiators)
        {
            gladiators.Add(new Gladiator{ gladiator = item });
        }
        int numSlots = System.Enum.GetNames(typeof(EquipType)).Length;
        foreach (var gladiator in gladiators)
        {
            gladiator.currentEquipment = new Equipment[numSlots];
        }
        SelectedGladiator(0);
    }
    public void Replace(Equipment newItem)
    {
        int equipSlot = (int)newItem.equipType;
        Equipment oldItem = selectedGladiator.currentEquipment[equipSlot];

        selectedGladiator.currentEquipment[equipSlot] = newItem;
        Debug.Log("newItem " + newItem + " olditem " + oldItem);
        StatusManager.instance.UpdateGladiatorStats(newItem, oldItem, selectedGladiator.gladiator);

        GameObject go = GameObject.Find("Stats");
        go.GetComponent<StatsUI>().UpdateStats();

    }
    public void Equip(Equipment newItem)
    {
        int equipSlot = (int)newItem.equipType;
        Equipment oldItem = null;
        selectedGladiator.currentEquipment[equipSlot] = newItem;
        //Debug.Log("newItem " + newItem + " olditem " + oldItem);
        StatusManager.instance.UpdateGladiatorStats(newItem, oldItem, selectedGladiator.gladiator);

        GameObject go = GameObject.Find("Stats");
        go.GetComponent<StatsUI>().UpdateStats();
    }

    public void UnEquip(Equipment item)
    {
        int equipSlot = (int)item.equipType;
        selectedGladiator.currentEquipment[equipSlot] = null;
        StatusManager.instance.UpdateGladiatorStats(null,item, selectedGladiator.gladiator);
        GameObject go = GameObject.Find("Stats");
        go.GetComponent<StatsUI>().UpdateStats();
    }
}
