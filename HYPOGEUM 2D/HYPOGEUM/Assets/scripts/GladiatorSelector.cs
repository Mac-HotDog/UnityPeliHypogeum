using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GladiatorSelector : MonoBehaviour
{
    public GameObject uiPrefab;
    public List<GladiatorStats> gladiators = new List<GladiatorStats>();
    private void Start()
    {
        InstantiateUI();
    }
    void InstantiateUI()
    {
        int id = 0;
        /*foreach (var item in GameObject.FindGameObjectsWithTag("Player"))
        {
            gladiators.Add(item.GetComponent<GladiatorStats>());
        }*/
        foreach (var item in PlacementManager.instance.gladiators)
        {
            gladiators.Add(item.GetComponent<GladiatorStats>());
        }
        
        foreach (var item in gladiators)
        {
            var newGladiator = Instantiate(uiPrefab, gameObject.transform, false);
            GladiatorSlot glad = newGladiator.GetComponent<GladiatorSlot>();
            glad.gladiator = item;
            glad.GladiatorID = id;
            id++;

            if (item.sprite)
            {
                glad.sprite = item.sprite;
            }
        }
        
    }
}
