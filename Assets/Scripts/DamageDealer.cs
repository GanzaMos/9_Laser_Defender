using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageDealer : MonoBehaviour
{

    [SerializeField] private int damagePerHit = 100;

    public int GetDamageAmount()
    {
        return damagePerHit;
    }

    void Start()
    {
        
    }
    
    void Update()
    {
        
    }
}
