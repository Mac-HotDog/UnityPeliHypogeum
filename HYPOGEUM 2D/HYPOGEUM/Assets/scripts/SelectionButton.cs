using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectionButton : MonoBehaviour
{
    public GladiatorStats gladiator;


    public void AddGladiator()
    {
        { 
          GladiatorHolder.instance.gladiators.Add(gladiator);
          gameObject.GetComponentInParent<SelectionCreator>().gladiators.Remove(gladiator);
          gameObject.GetComponentInParent<SelectionCreator>().InstantiateGladiators();
            GameObject.Find("SelectedGladiators").GetComponent<SelectionPreview>().InstantiateUI();
        }
    }
}
