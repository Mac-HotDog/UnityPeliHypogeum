using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class videoPlay : MonoBehaviour
{
    private GameObject canvas;
    public void Awake()
    {
        //canvas = GameObject.FindGameObjectWithTag("UICANVAS");
        //canvas.SetActive(false);
        Invoke(nameof(cleanUp), 4f);
    }
    private void cleanUp()
    {
        Debug.Log("aa");
        //canvas.SetActive(true);
        Destroy(gameObject);
    }
}
