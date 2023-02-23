using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InventorySlot : MonoBehaviour
{
    public Item item;
    public Sprite sprite;

    private void Start()
    {
        OnSlot(item);
    }

    void OnSlot(Item item)
    {
        this.item = item;
        TextMeshProUGUI text = gameObject.GetComponentInChildren<TextMeshProUGUI>();
        text.text = item.name;
        if (sprite)
        {
            Image imageComponent = gameObject.GetComponent<Image>();
            imageComponent.sprite = item.icon;
        }
    }

    public void ItemPickUp()
    {
        InventorySelector inv = gameObject.GetComponentInParent<InventorySelector>();

        if (inv.selectedItem == null)
        {
            inv.selectedItem = item;
            Inventory.instance.RemoveItem(item);
            inv.InstantiateUI();
        }
        else
        {
            AlertManager.instance.AlertCreator("You already have selected an item");
        }
    }
}
