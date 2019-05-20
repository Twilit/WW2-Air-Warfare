using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    private Collider[] entitiesWithInRange;

    void Start()
    {
        Invoke("DealDamage", 0.12f);
    }

    void Update()
    {
        
    }

    void DealDamage()
    {
        entitiesWithInRange = Physics.OverlapSphere(transform.position, 4f);

        foreach(Collider entity in entitiesWithInRange)
        {
            print(entity.name);
            
            //Deal Damage
        }
    }
}
