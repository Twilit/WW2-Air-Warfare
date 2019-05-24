using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour
{
    public int damageDealt = 15;
    bool doneDamage = false;

    void OnTriggerEnter(Collider collider)
    {
        //printing a statement to console for testing purposes
        print(collider);
        //if the the object that colided with the health pick up has a player tag 
        //then get the players health script and check to see if ther is one and add health
        if (collider.transform.root.tag == "Player")
        {
            print("Damage player");
            //colider.GetComponent gets the health script from the player not the pickup
            Health health = collider.transform.root.GetComponent<Health>();
            if (health != null && !doneDamage)
            {

                health.Damage(damageDealt);

                doneDamage = true;
            }
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
