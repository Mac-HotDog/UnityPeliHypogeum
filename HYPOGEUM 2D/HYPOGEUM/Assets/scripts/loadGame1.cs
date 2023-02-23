using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class loadGame1 : MonoBehaviour
{
    public string sceneName;
    public void startGame()
    {
        if (GladiatorHolder.instance.gladiators.Count == 0)
        {
            Debug.Log("Selecto more gladiators");
        }
        else
        {
            Destroy(GameObject.Find("music"));
            SceneManager.LoadScene(sceneName);
        }
        
    }
}
