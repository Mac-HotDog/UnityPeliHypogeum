using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyStats : MonoBehaviour
{
    [Header("stats")]

    public float hp;
    public float startHp;
    public float damage;
    public float attackSpeed;
    public float movementSpeed = 5f;
    public int worth;
    public int range;
    private float attackCountDown = 0f;

    [Header("Unity stuff")]

    public Image healthBar;
    public string playerTag = "Player";
    public bool isRanged = false;
    public GameObject projectilePrefab;
    
    private Transform target;
    private GladiatorStats targetPlayer;
    public Transform enemyTransform;

    public Transform firePoint;
    private List<Item> dropTable;
    void Start()
    {
        hp = startHp;
        InvokeRepeating("UpdateTarget", 0f, 0.5f);
    }
    public void TakeDamage(float amount)
    {
        hp -= amount;
        healthBar.fillAmount = hp / startHp;
        if (hp <= 0)
        {
            DropItem();
            GameManager.instance.Gold += worth;
            GameManager.instance.GameWinLogic();
            Destroy(gameObject);
        }
    }

    void DropItem()
    {
        float ifDrops = Random.Range(0f, 1f);
        if (ifDrops >= 0.5)
        {
            dropTable = GameManager.instance.dropTable;
            float count = dropTable.Count;
            float rand = Random.Range(0.0f, count - 1);
            int rounded = Mathf.RoundToInt(rand);
            Inventory.instance.AddItem(dropTable[rounded]);

            DisplayDroppedItem(dropTable[rounded]);
        }
    }

    void DisplayDroppedItem(Item droppedItem)
    {
        // logic here for displaying what item you got
        AlertManager.instance.AlertCreator("Item dropped:" + droppedItem);
    }

    void UpdateTarget()
    {
        GameObject[] players = GameObject.FindGameObjectsWithTag(playerTag);
        float shortestDistance = Mathf.Infinity;
        GameObject nearestPlayer = null;

        foreach (GameObject player in players)
        {
            float distanceToPlayer = Vector3.Distance(transform.position, player.transform.position);
            if (distanceToPlayer < shortestDistance)
            {
                shortestDistance = distanceToPlayer;
                nearestPlayer = player;
            }
        }
        if (nearestPlayer != null && shortestDistance <= range)
        {
            target = nearestPlayer.transform;
            targetPlayer = nearestPlayer.GetComponent<GladiatorStats>();
        }
        else
        {
            target = null;
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

        //enemyTransform.LookAt(target);
        attackCountDown -= Time.deltaTime;

        
    }
    void Attack()
    {
        GladiatorStats e = targetPlayer.GetComponent<GladiatorStats>();
        if (e != null)
        {
            e.TakeDamage(damage);
        }
    }
    void Shoot()
    {
        GameObject projectileGO = (GameObject)Instantiate(projectilePrefab, firePoint.position, firePoint.rotation);
        Projectile projectile = projectileGO.GetComponent<Projectile>();

        if (projectile != null)
        {
            projectile.Seek(target, damage);
        }
    }
}
