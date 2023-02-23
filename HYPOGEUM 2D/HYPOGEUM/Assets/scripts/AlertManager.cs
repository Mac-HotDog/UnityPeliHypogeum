using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlertManager : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject alertPrefab;
    #region Singleton
    public static AlertManager instance;
    private Vector3 location = new Vector3(200,0,0); 

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
    public void AlertCreator(string message){
        var create = Instantiate(alertPrefab, location, Quaternion.identity, GameObject.Find("UICANVAS").transform);
        create.GetComponent<AlertText>().Alert(message);
    }
}
