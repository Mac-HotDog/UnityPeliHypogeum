using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StatsUI : MonoBehaviour
{
    public void Start()
    {
        Invoke("UpdateStats", 0.2f);
    }
    public void UpdateStats()
    {
        foreach (Transform child in gameObject.transform)
        {
            Transform valueText = child.Find("Value");
            Transform nameText = child.Find("Name");
            TextMeshProUGUI textmesh = valueText.GetComponent<TextMeshProUGUI>();
            TextMeshProUGUI namemesh = nameText.GetComponent<TextMeshProUGUI>();
            switch (namemesh.text)
            {
                case "Hp":
                    textmesh.text = EquipmentManager.instance.selectedGladiator.gladiator.startHp.ToString();
                    break;
                case "Armor":
                    textmesh.text = EquipmentManager.instance.selectedGladiator.gladiator.armor.ToString();
                    break;
                case "Damage":
                    textmesh.text = EquipmentManager.instance.selectedGladiator.gladiator.damage.ToString();
                    break;
                case "Range":
                    textmesh.text = EquipmentManager.instance.selectedGladiator.gladiator.range.ToString();
                    break;
                case "Attack speed":
                    textmesh.text = EquipmentManager.instance.selectedGladiator.gladiator.attackSpeed.ToString();
                    break;
            }
            
        }
    }
}
