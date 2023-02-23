using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GladiatorHolder : MonoBehaviour
{
    public List<GladiatorStats> gladiators = new List<GladiatorStats>();

#region Singleton
    public static GladiatorHolder instance;

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
