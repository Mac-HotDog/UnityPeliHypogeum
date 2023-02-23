using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AlertText : MonoBehaviour
{
    // Start is called before the first frame update
    public Text alertText;
    
    public void Start(){
        
        StartCoroutine(DeleteSelf());
    }
    public void Update(){
        gameObject.transform.position += Vector3.up * 0.06f;
    }
    public void Alert(string alert)
    {
        alertText.text = alert; 
    }
    IEnumerator DeleteSelf()
    {
        yield return new WaitForSecondsRealtime(2.5f);
        
        Destroy(gameObject); 
    }
    
}
