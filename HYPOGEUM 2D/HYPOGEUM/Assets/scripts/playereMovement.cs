using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(GladiatorStats))]
public class playereMovement: MonoBehaviour
{
    [Header("Unity stuff")]
    public string enemyTag = "Enemy";
    //public float startSpeed = 5f;

    
    private Transform target;
    private EnemyStats targetEnemy;
    private Animator m_Animator;
    private GladiatorStats player;

    //private Rigidbody rb;

    //private Vector3 movement;
    //private MovementController MovementController;
    public Vector3 direction;
    // Start is called before the first frame update
    void Awake()
    {
        //m_Animator = player.m_Animator;
    }
    void Start()
    {
        player = GetComponent<GladiatorStats>();
        m_Animator = gameObject.GetComponentInChildren<Animator>();
        InvokeRepeating("UpdateTarget", 0f, 0.5f);
        //rb = this.GetComponent<Rigidbody>();
        //InvokeRepeating("moveCharacter", 1.0f, 1.0f);
    }

    void UpdateTarget()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);
        float shortestDistance = Mathf.Infinity;
        GameObject nearestEnemy = null;

        foreach (GameObject enemy in enemies)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
            if (distanceToEnemy < shortestDistance)
            {
                shortestDistance = distanceToEnemy;
                nearestEnemy = enemy;
            }
        }
        if (nearestEnemy != null && shortestDistance >= player.range)
        {
            target = nearestEnemy.transform;
            targetEnemy = nearestEnemy.GetComponent<EnemyStats>();
        }
        else
        {
            target = null;
        }
    }

    void Update()
    {
        if (target != null)
        {
            m_Animator.SetBool("walk", true);
            Vector3 dir = target.position - transform.position;
            transform.Translate(player.movementSpeed * Time.deltaTime * dir.normalized, Space.World); // normalize so that only the movementSpeed affects the speed
        }
        else
        {
            m_Animator.SetBool("walk", false);
        }


    } 
}