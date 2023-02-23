using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ShopSlot : MonoBehaviour
{
    public Item item;
    public Sprite sprite;
    // Start is called before the first frame update
    private void Start()
    {
        OnSlot(item);
    }
    void OnSlot(Item item)
    {
        this.item = item;
        TextMeshProUGUI text = gameObject.GetComponentInChildren<TextMeshProUGUI>();
        text.text = item.value.ToString();
        if (sprite)
        {
            Image imageComponent = gameObject.GetComponent<Image>();
            imageComponent.sprite = item.icon;
        }
    }
    public void ItemPickUp()
    {
        if(GameManager.instance.Gold >= item.value)
        {
            ShopPanel shop = gameObject.GetComponentInParent<ShopPanel>();
            GameManager.instance.Gold -= item.value;
            Inventory.instance.AddItem(item);
            shop.items.Remove(item);
            shop.InstantiateUI();
        }
        else
        {
            Debug.Log("You do not have enough gold to buy this item");
        }
    }
}
