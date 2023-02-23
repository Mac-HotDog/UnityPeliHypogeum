using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GladiatorStats : MonoBehaviour
{
    [Header("stats")]

    public float startHp = 20;
    private float attackCountDown = 0f;
    public float baseRange = 5.0f;
    public float hp;
    public float damage = 5;
    public float attackSpeed = 1;
    public float movementSpeed = 2;
    public float range = 5;
    public float armor = 0;

    [Header("misc")]

    public bool isDead;

    [Header("Unity Setup Fields")]

    public string GladiatorName;
    public Image healthBar;
    public string enemyTag = "Enemy";
    public bool isRanged = false;
    public GameObject projectilePrefab;
    public bool hasAnimations;
    private Transform target;
    private EnemyStats targetEnemy;
    private BossStats targetBoss;
    public Transform gladiatorTransform;
    public Sprite sprite;
    public Vector3 targetPos;
    private AudioSource source;

    public Transform firePoint;

    public Animator m_Animator;
    private void Start()
    {
        m_Animator = gameObject.GetComponentInChildren<Animator>();
        source = GetComponent<AudioSource>();
        DontDestroyOnLoad(gameObject);
        targetPos = gameObject.transform.position;
        InvokeRepeating("UpdateTarget", 0f, 0.5f);
    }
    private void Awake()
    {
        hp = startHp;
        
        if (isDead == true)
        {
            gameObject.SetActive(true);
            
        }
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
                if (!isDead)
                {
                    gladiatorTransform.LookAt(nearestEnemy.transform);    
                }
                
            }
        }
        if (nearestEnemy != null && shortestDistance <= range)
        {
            target = nearestEnemy.transform;
            targetEnemy = nearestEnemy.GetComponent<EnemyStats>();
            targetBoss = nearestEnemy.GetComponent<BossStats>();
        }
        else
        {
            target = null;
        }
    }
    public void TakeDamage(float damageTaken)
    {
        float damageMult = (1 - (armor / 100));
        damageTaken = damageTaken * damageMult;
        
        hp -= damageTaken;
        healthBar.fillAmount = hp / startHp;
        if (hp <= 0)
        {
            gameObject.tag = "dead";
            range = 0;
            isDead = true;
            GameManager.instance.GameOverLogic();
            m_Animator.SetTrigger("die");
            gameObject.GetComponent<playereMovement>().enabled = false;
            gameObject.GetComponent<CapsuleCollider>().enabled = false;
            gameObject.GetComponent<GladiatorStats>().enabled = false;
            
        }
    }
    // Update is called once per frame
    void Update()
    {
        
        if (target == null)
        {
            return;
        }
        if (attackCountDown <= 0f)
        {
            if (isRanged)
            {
                Shoot();
            }
            else
            {
                Attack();
            }
            attackCountDown = 1f / attackSpeed;
        }
        
        gladiatorTransform.LookAt(target);    
        
        attackCountDown -= Time.deltaTime;
        
        
    }
    void Attack()
    {
        try
        {
            EnemyStats e = targetEnemy.GetComponent<EnemyStats>();
            if (e != null)
        {
            source.Play();
            m_Animator.SetTrigger("attack");
            e.TakeDamage(damage);
        }
        }
        catch 
        {
            BossStats e = targetBoss.GetComponent<BossStats>();
            if (e != null)
        {
            source.Play();
            m_Animator.SetTrigger("attack");
            e.TakeDamage(damage);
        }
        }
        
        
    }
    void Shoot()
    {
        GameObject projectileGO = (GameObject)Instantiate(projectilePrefab, firePoint.position, firePoint.rotation);
        Projectile projectile = projectileGO.GetComponent<Projectile>();
        projectileGO.GetComponent<Projectile>().source = source;

        if (projectile != null)
        {
            m_Animator.SetTrigger("attack");
            projectile.Seek(target, damage);
        }
    }
}
