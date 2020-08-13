using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;
using Random = UnityEngine.Random;

public class Enemy : MonoBehaviour
{
    [SerializeField] private int enemyHealth = 200;
    [SerializeField] private ParticleSystem _deathVFX;
    [SerializeField] private GameObject laser;
    [SerializeField] float bulletSpeed = 20f;
    [SerializeField] private float minReloadTime = 0.5f;
    [SerializeField] private float maxReloadTime = 3f;

    private float reloadCounter;
    void Start()
    {
        reloadCounter = Random.Range(minReloadTime, maxReloadTime);
    }
    
    void Update()
    {
        Fire();
    }

    private void Fire()
    {
        reloadCounter -= Time.deltaTime;
        if (reloadCounter <= 0)
        {
            var _laser = Instantiate(laser, transform.position, Quaternion.identity);
            _laser.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -bulletSpeed);
            reloadCounter = Random.Range(minReloadTime, maxReloadTime);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.GetComponent<DamageDealer>())
        {
            DamageDealer damageDealer = other.gameObject.GetComponent<DamageDealer>();
            enemyHealth -= damageDealer.GetDamageAmount();
            Destroy(other.gameObject);
            if (enemyHealth <= 0)
            {
                Instantiate(_deathVFX, transform.position, Quaternion.identity);
                Destroy(gameObject);
            }
        };
    }
}
