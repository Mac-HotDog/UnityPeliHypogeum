using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleInv : MonoBehaviour
{
    public GameObject canvas;
    public void Toggle()
    {
        if (canvas.activeInHierarchy)
        {
            canvas.SetActive(false);
        }
        else
        {
            canvas.SetActive(true);
            GameObject statsUI = GameObject.Find("Stats");
            statsUI.GetComponent<StatsUI>().UpdateStats();
            InventorySelector inv = GameObject.Find("InventorySlots").GetComponent<InventorySelector>();
            inv.InstantiateUI();
        }
    }
}
