using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlacementManager : MonoBehaviour
{
    //public GladiatorStats gladiatorStats;
    //public List<GladiatorStats> preFabGladiators = new List<GladiatorStats>();

    public List<GladiatorStats> gladiators = new List<GladiatorStats>();
    //public List<GladiatorStats> gladiators2 = new List<GladiatorStats>();

    #region Singleton
    public static PlacementManager instance;
    public int placettujenMaara;

    void Awake()
    {
        if (instance == null)
        {
            placettujenMaara = 0;
            Startup();
            instance = this;
            DontDestroyOnLoad(this);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    private void Startup()
    {
        foreach (var item in GladiatorHolder.instance.gladiators)
        {
            gladiators.Add(Instantiate(item, new Vector3(20,20,20), Quaternion.identity));
        }
        GameObject[] players = GameObject.FindGameObjectsWithTag("Player");
        foreach (var item in players)
        {
            item.gameObject.SetActive(false);
        }
    }
    #endregion Singleton 
}
