using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrabHealth : MonoBehaviour
{
    [SerializeField]
    private int crabMaxHealth = 1000;
    private int crabCurrentHealth = 1000;

    void Start()
    {
        crabCurrentHealth = crabMaxHealth;
    }

    void Update()
    {

    }

    void Death()
    {
        Destroy(gameObject);
    }

    public void DealDamage(int damage)
    {
        crabCurrentHealth -= damage;

        if (crabCurrentHealth <= 0)
        {
            Death();
        }
    }
}
