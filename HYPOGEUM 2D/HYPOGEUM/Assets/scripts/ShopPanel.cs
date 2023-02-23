using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopPanel : MonoBehaviour
{
    public GameObject uiPrefab;

    public List<Item> items = new List<Item>();

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
        foreach (var item in items)
        {
            var newItem = Instantiate(uiPrefab, gameObject.transform, false);
            ShopSlot slot = newItem.GetComponent<ShopSlot>();
            slot.item = item;

            if (item.icon)
            {
                slot.sprite = item.icon;
            }
        }

    }
}
