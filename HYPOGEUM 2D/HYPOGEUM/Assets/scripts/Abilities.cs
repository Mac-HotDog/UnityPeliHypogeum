using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Abilities : MonoBehaviour
{
    //[HideInInspector]
    public List<Item> abilities = new List<Item>();
    [HideInInspector]
    public int abilityCount;

    #region Singleton
    public static Abilities instance;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
    #endregion Singleton
}
