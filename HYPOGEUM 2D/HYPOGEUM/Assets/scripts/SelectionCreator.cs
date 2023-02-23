using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SelectionCreator : MonoBehaviour
{
    public List<GladiatorStats> gladiators = new List<GladiatorStats>();
    public GameObject uiPrefab;
    private void Awake()
    {
        InstantiateGladiators();
    }

    public void InstantiateGladiators()
    {
        foreach (Transform child in gameObject.transform)
        {
            Destroy(child.gameObject);
        }
        foreach (var item in gladiators)
        {
            var gladiatorButton = Instantiate(uiPrefab, gameObject.transform, false);
            gladiatorButton.GetComponent<SelectionButton>().gladiator = item;
            gladiatorButton.GetComponentInChildren<TextMeshProUGUI>().text = item.name;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
