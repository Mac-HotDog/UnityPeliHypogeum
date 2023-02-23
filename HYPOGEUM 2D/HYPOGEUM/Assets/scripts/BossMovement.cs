using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BossStats))]
public class BossMovement : MonoBehaviour
{
    [Header("Unity stuff")]
    public string playerTag = "Player";
    //public float startSpeed = 5f;


    private Transform target;
    private Animator m_Animator;
    private BossStats enemy;

    private GladiatorStats targetPlayer;

    //private Rigidbody rb;

    //private Vector3 movement;
    //private MovementController MovementController;
    public Vector3 direction;
    // Start is called before the first frame update
    void Start()
    {
        enemy = GetComponent<BossStats>();
        InvokeRepeating("UpdateTarget", 0f, 0.5f);
        m_Animator = gameObject.GetComponentInChildren<Animator>();
        //rb = this.GetComponent<Rigidbody>();
        //InvokeRepeating("moveCharacter", 1.0f, 1.0f);
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
        if (nearestPlayer != null && shortestDistance >= enemy.range)
        {
            target = nearestPlayer.transform;
            targetPlayer = nearestPlayer.GetComponent<GladiatorStats>();
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
            transform.Translate(enemy.movementSpeed * Time.deltaTime * dir.normalized, Space.World); // normalize so that only the movementSpeed affects the speed
        }
        else
        {
            m_Animator.SetBool("walk", false);
        }
        

        /*Vector3 direction2 = redGuy.position - transform.position;
        float angle = Mathf.Atan2(direction2.z, direction2.x) * Mathf.Rad2Deg;*/
        //rb.rotation = angle;
        //direction.Normalize();

        //movement = direction;
        /*double koko = angle;
        Debug.Log(koko);*/
       
        
        /*if (128.9 >= koko && koko >= 60.3)
        {
            direction = new Vector3(1.25f, 0, -0.75f);
            
        }
        else if (60.3 >= koko && koko >= -14.6)
        {
            direction = new Vector3(0, 0, -1.5f);
            
        }
        else if (-14.6 >= koko && koko >= -68.6)
        {
            direction = new Vector3(-1.25f, 0, -0.75f);
            
        }
        else if (-68.6 >= koko && koko >= -118.6)
        {
            direction = new Vector3(-1.25f, 0, 0.75f);
            
        }
        else if (-118.6 >= koko && koko >= -170.8)
        {
            direction = new Vector3(0, 0, 1.5f);
           
        }
        else
        {
            direction = new Vector3(1.25f, 0, 0.75f);
            
        }*/

    }

    /*void moveCharacter()
    {
        transform.position += direction;
        //Debug.Log(direction);
    }*/
    /*void OnCollisionEnter2D(Collision2D other)
    {
        asdController player = other.gameObject.GetComponent<asdController >();

        if (player != null)
        {
            player.ChangeHealth(-1);
        }
    }*/
}