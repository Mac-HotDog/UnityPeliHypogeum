using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    GameObject[] players;
    GameObject[] enemies;
    public int enemyCount;
    public int deadCount;
    public List<Item> dropTable = new List<Item>();
    public int Gold;
    public int CurrentLevel = 0;
    public int GamesWon = 0;

    #region Singleton
    public static GameManager instance;
    public GameObject invBut;
    public GameObject invPanel;
    public GameObject abiPanel;
    public GameObject pauseButton;
    public GameObject startButton;
    public GameObject contButton;
    public GameObject Wontext;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            Gold = 0;
            DontDestroyOnLoad(this);
            _isGameOver = false;
            _isGameWon = false;
            players = GameObject.FindGameObjectsWithTag("Player");
            enemies = GameObject.FindGameObjectsWithTag("Enemy");
            deadCount = 0;
            enemyCount = enemies.Length;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    #endregion
    public bool _isGameOver;
    public bool _isGameWon;
    public void GameOverLogic()
    {
        deadCount = GameObject.FindGameObjectsWithTag("dead").Length;
        if (deadCount >= 4)
        {
            
            _isGameOver = true;
            SceneManager.LoadScene("loss");
            CleanUp();

        }
    }
    public void GameWinLogic()
    {
        enemyCount -= 1;
        if (enemyCount <= 0)
        {
            _isGameWon = true;
            GamesWon++;
            if (GamesWon >= 5)
            {
                SceneManager.LoadScene("victory");
                CleanUp();
            }
            else
            {
                invBut.SetActive(false);
                invPanel.SetActive(false);
                abiPanel.SetActive(false);
                pauseButton.SetActive(false);
                startButton.SetActive(false);
                contButton.SetActive(true);
                Wontext.SetActive(true);
                //LevelChangLogic();
            }
            Time.timeScale = 0;
        }
    }

    public void LevelChangLogic()
    {
        switch (CurrentLevel)
        {
            case 0:
                SceneManager.LoadScene("level2");
                break;
            case 1:
                SceneManager.LoadScene("level3");
                break;
            case 2:
                SceneManager.LoadScene("level4");
                break;
            case 3:
                invBut.SetActive(false);
                invPanel.SetActive(false);
                abiPanel.SetActive(false);
                pauseButton.SetActive(false);
                startButton.SetActive(false);
                contButton.SetActive(false);
                Wontext.SetActive(false);
                SceneManager.LoadScene("Shop");
                break;
            case 4:
            invBut.SetActive(true);
                invPanel.SetActive(false);
                abiPanel.SetActive(true);
                pauseButton.SetActive(true);
                startButton.SetActive(true);
                Destroy(GameObject.Find("music"));
                SceneManager.LoadScene("boss1");
                break;
            default:
                SceneManager.LoadScene("victory");
                CleanUp();
                break;
        }
        CurrentLevel++;
    }

    public void CleanUp()
    {
        foreach (var item in players)
        {
            Destroy(item);
        }
        Destroy(GameObject.Find("UICANVAS"));
        Destroy(GameObject.Find("Managers"));
        Destroy(GameObject.Find("GladiatorPasser"));
    }
    public void ResetGame()
    {
        players = GameObject.FindGameObjectsWithTag("Player");
        //deadplayers = GameObject.FindGameObjectsWithTag("dead");
        foreach (var item in players)
        {
            var statit = item.GetComponent<GladiatorStats>();
            item.tag = "Player";
            item.GetComponent<playereMovement>().enabled = true;
            item.GetComponent<CapsuleCollider>().enabled = true;
            item.GetComponent<GladiatorStats>().enabled = true;
            statit.enabled = true;
            statit.range = statit.baseRange;
            statit.hp = statit.startHp;
            statit.isDead = false;
            statit.m_Animator.SetTrigger("reset");
            statit.transform.position = statit.targetPos;
        }
        
        enemies = GameObject.FindGameObjectsWithTag("Enemy");
        deadCount = 0;
        enemyCount = enemies.Length;
    }
}
