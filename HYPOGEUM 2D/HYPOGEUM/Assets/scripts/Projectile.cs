using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    private Transform target;
    public float explosionRadius = 0f;
    public GameObject impactEffect;
    public float speed = 70f;
    private float damage = 5;
    public AudioSource source;

    public void Seek (Transform _target, float _damage)
    {
        target = _target;
        damage = _damage;
    }

    void Update()
    {
        if (target == null)
        {
            Destroy(gameObject);
            return;
        }
        Vector3 dir = target.position - transform.position;
        float distanceThisFrame = speed * Time.deltaTime;
        if (dir.magnitude <= distanceThisFrame)
        {
            HitTarget();
            return;
        }
        transform.Translate(dir.normalized * distanceThisFrame, Space.World);
        transform.LookAt(target);
    }
    void HitTarget()
    {
        
        GameObject effectIns = (GameObject)Instantiate(impactEffect, transform.position, transform.rotation);
        source.Play();
        Destroy(effectIns, 5f);

        if(explosionRadius > 0f)
        {
            Explode();
        }
        else
        {
            
            Damage(target);
        }
    }
    void Explode()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, explosionRadius);
        foreach (Collider collider in colliders)
        {
            if (collider.CompareTag("Enemy"))
            {
                Damage(collider.transform);
            }
        }
    }
    void Damage (Transform enemy)
    {
        EnemyStats e = enemy.GetComponent<EnemyStats>();
        BossStats b = enemy.GetComponent<BossStats>();
        if (e != null)
        {
            e.TakeDamage(damage);
            Destroy(gameObject);
        }
        else if (b != null)
        {
            b.TakeDamage(damage);
            Destroy(gameObject);
        }
        
    }
}
