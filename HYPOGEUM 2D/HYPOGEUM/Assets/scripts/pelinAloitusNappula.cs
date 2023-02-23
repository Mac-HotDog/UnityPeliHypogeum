using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pelinAloitusNappula : MonoBehaviour
{
     public GameObject canvas;
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 0;
        
    }

    // Update is called once per frame
    public void Toggle()
    {
        Time.timeScale = 1;
        GameManager.instance.ResetGame();
        canvas.SetActive(false);
    }
}
