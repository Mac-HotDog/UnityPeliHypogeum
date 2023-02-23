using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaillytettavatGameobjectit : MonoBehaviour
{
    // Start is called before the first frame update
    #region Singleton
    //public static SaillytettavatGameobjectit instance;
    void Awake()
    {
        /*if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }*/
        GameObject[] objs = GameObject.FindGameObjectsWithTag("Player");
        

        foreach (var item in objs)
        {
            DontDestroyOnLoad(item);
        }
        

        
    }
    #endregion
}
