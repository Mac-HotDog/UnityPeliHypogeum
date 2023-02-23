using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GladiatorSlot : MonoBehaviour
{
    public GladiatorStats gladiator;
    public Sprite sprite;
    public int GladiatorID;
    private void Start()
    {
        OnSlot();
    }
    void OnSlot()
    {
        TextMeshProUGUI text = gameObject.GetComponentInChildren<TextMeshProUGUI>();
        text.text = gladiator.GladiatorName;
        if (sprite)
        {
            Image imageComponent = gameObject.GetComponentInChildren<Image>();
            imageComponent.sprite = sprite;
        }
    }
    public void SelectGladiator()
    {
        EquipmentManager.instance.SelectedGladiator(GladiatorID);
        //Debug.Log("Gladiator ID: " + GladiatorID);
        foreach (var item in GameObject.FindGameObjectsWithTag("EquipSlot"))
        {
            item.GetComponent<ItemSlot>().DisplayItem(EquipmentManager.instance.gladiators[GladiatorID]);
        }
        GameObject statsUI = GameObject.Find("Stats");
        statsUI.GetComponent<StatsUI>().UpdateStats();
    }
}
