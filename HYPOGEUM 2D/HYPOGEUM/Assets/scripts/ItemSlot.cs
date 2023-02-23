using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ItemSlot : MonoBehaviour
{
    public Item item;
    public EquipType equipType;
    public Sprite sprite;
    public Text alertTexti;
    public void DisplayItem(EquipmentManager.Gladiator gladiator)
    {
        TextMeshProUGUI text = gameObject.GetComponentInChildren<TextMeshProUGUI>();
        foreach (var newItem in gladiator.currentEquipment)
        {
            if (newItem)
            {
                if (newItem.equipType == equipType)
                {
                    item = newItem;
                    text.text = newItem.name;
                    if (item.icon)
                    {
                        gameObject.GetComponent<Image>().sprite = item.icon;
                    }
                    return;
                }
            }
            else
            {
                item = null;
                text.text = "Empty";
                gameObject.GetComponent<Image>().sprite = sprite;
            }
        }
    }

    public void EquipItem()
    {
        InventorySelector inv = GameObject.Find("InventorySlots").GetComponent<InventorySelector>();
        if (inv.selectedItem != null)
        {
            if (inv.selectedItem.ReturnType() == equipType.ToString())
            {
                if (item)
                {
                    Inventory.instance.AddItem(item);
                    item = inv.selectedItem;
                    item.Replace(); // replaces item with new one
                    if (item.icon)
                    {
                        gameObject.GetComponent<Image>().sprite = item.icon;
                    }
                }
                else
                {
                    item = inv.selectedItem;
                    item.Use(); // equips to an empty slot
                    if (item.icon)
                    {
                        gameObject.GetComponent<Image>().sprite = item.icon;
                    }
                } 
                TextMeshProUGUI text = gameObject.GetComponentInChildren<TextMeshProUGUI>();
                text.text = item.name;
                inv.selectedItem = null;
                inv.InstantiateUI();
            }
            else
            {
                AlertManager.instance.AlertCreator("Wrong slot, item returned to inventory");
                Inventory.instance.AddItem(inv.selectedItem);
                inv.selectedItem = null;
                inv.InstantiateUI();
            }
        }
        else
        {
            if(item != null)
            {
                AlertManager.instance.AlertCreator("Removing item");
                item.UnUse(); // Unequips item
                Inventory.instance.AddItem(item);
                item = null;
                gameObject.GetComponent<Image>().sprite = sprite;
                inv.selectedItem = null;
                TextMeshProUGUI text = gameObject.GetComponentInChildren<TextMeshProUGUI>();
                text.text = "Empty";
                inv.InstantiateUI();
            }
            else
            {
                AlertManager.instance.AlertCreator("Select an item first");
            }
        }
    }
}
