using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private int enemyHealth = 200;
    void Start()
    {
        
    }
    
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        DamageDealer damageDealer = other.gameObject.GetComponent<DamageDealer>();
        enemyHealth -= damageDealer.GetDamageAmount();
        if (enemyHealth <= 0)
        {
            Destroy(gameObject);
        }
    }
}
