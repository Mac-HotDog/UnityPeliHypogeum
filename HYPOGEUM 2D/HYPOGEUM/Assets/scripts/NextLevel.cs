using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextLevel : MonoBehaviour
{
    public GameObject invBut;
    public GameObject invPanel;
    public GameObject abiPanel;
    public GameObject pauseButton;
    public GameObject startButton;
    public GameObject contButton;
    public GameObject Wontext;
    public void Toggle()
    {
        
        
        invBut.SetActive(true);
        invPanel.SetActive(true);
        abiPanel.SetActive(true);
        pauseButton.SetActive(true);
        startButton.SetActive(true);
        contButton.SetActive(false);
        Wontext.SetActive(false);
        GameManager.instance.LevelChangLogic();
        
    }
}
