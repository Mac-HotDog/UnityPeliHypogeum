using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SelectionPreview : MonoBehaviour
{
    public GameObject uiPrefab;

    public void InstantiateUI()
    {
        foreach (Transform child in gameObject.transform)
        {
            Destroy(child.gameObject);
        }
        foreach (var item in GladiatorHolder.instance.gladiators)
        {
            var newItem = Instantiate(uiPrefab, gameObject.transform, false);
            newItem.GetComponentInChildren<TextMeshProUGUI>().text = item.name;
            //InventorySlot slot = newItem.GetComponent<InventorySlot>();
        }

    }
}
