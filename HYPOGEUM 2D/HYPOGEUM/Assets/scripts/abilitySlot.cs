using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class abilitySlot : MonoBehaviour
{
    public int id;
    public Item item;
    public Sprite sprite;
    public float cooldDown = 0f;
    public GameObject canvas;
    public Text alertTexti;


    private void Awake()
    {
        id = 1;
        Invoke("LoadOld", 0.1f);
    }
    public void LoadOld()
    {
        if ((Abilities.instance.abilities[id - 1].ReturnType() == "ability") && (Abilities.instance.abilities.Count <= (id - 1)))
        {
            TextMeshProUGUI text = gameObject.GetComponentInChildren<TextMeshProUGUI>();
            item = Abilities.instance.abilities[id - 1];
            text.text = item.name;
        }
    }
    void Update()
    {
        if (Input.GetKeyDown(id.ToString()))
        {
            UseAbility();
        }
        if (cooldDown <= 0f)
        {
            return;
        }
        else
        {
            TextMeshProUGUI text = gameObject.GetComponentInChildren<TextMeshProUGUI>();
            cooldDown -= Time.deltaTime;
            if (cooldDown <= 0f)
            {
                try
                {
                    text.text = item.name;
                }
                catch
                {
                    text.text = "Empty";
                }
            }
            else
            {
                text.text = Mathf.Round(cooldDown).ToString();
            }
        }
    }
    public void UseAbility()
    {
        TextMeshProUGUI text = gameObject.GetComponentInChildren<TextMeshProUGUI>();
        if (canvas.activeInHierarchy)
        {
            InventorySelector inv = GameObject.Find("InventorySlots").GetComponent<InventorySelector>();
            if (inv.selectedItem != null)
            {
                if (item != null)
                {
                    Inventory.instance.AddItem(item);
                    Abilities.instance.abilities.Remove(item);
                    Abilities.instance.abilities.Insert(id - 1, inv.selectedItem);
                    item = inv.selectedItem;
                    text.text = item.name;
                    if (item.icon)
                    {
                        gameObject.GetComponent<Image>().sprite = item.icon;
                    }
                }
                else
                {
                    var itemtype = inv.selectedItem.ReturnType();
                    if (itemtype == "ability")
                    {
                        item = inv.selectedItem;
                        text.text = item.name;
                        Abilities.instance.abilities.Insert(id - 1, item);
                        if (item.icon)
                        {
                            gameObject.GetComponent<Image>().sprite = item.icon;
                            //sprite = item.icon;
                        }
                        inv.selectedItem = null;
                    }
                    else
                    {
                        AlertManager.instance.AlertCreator("Not an ability");
                        Inventory.instance.AddItem(inv.selectedItem);
                        inv.selectedItem= null;
                        inv.InstantiateUI();
                    }
                }
            }
            else if (item != null)
            {
                Inventory.instance.AddItem(item);
                Abilities.instance.abilities.Insert(id - 1, null);
                item = null;
                text.text = "Empty";
                gameObject.GetComponent<Image>().sprite = sprite;
                inv.InstantiateUI();
            }
        }
        else if ((item != null) && cooldDown <= 0f)
        {
            item.Use();
            cooldDown = item.CustomFloat();
        }
    }
}
