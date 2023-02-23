using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventorySelector : MonoBehaviour
{
    public GameObject uiPrefab;
    public Item selectedItem;

    private void Start()
    {
        InstantiateUI();
    }
    public void InstantiateUI()
    {
        foreach (Transform child in gameObject.transform)
        {
            Destroy(child.gameObject);
        }
        foreach (var item in Inventory.instance.items)
        {
            var newItem = Instantiate(uiPrefab, gameObject.transform, false);
            InventorySlot slot = newItem.GetComponent<InventorySlot>();
            slot.item = item;

            if (item.icon)
            {
                slot.sprite = item.icon;
            }
        }

    }
}
