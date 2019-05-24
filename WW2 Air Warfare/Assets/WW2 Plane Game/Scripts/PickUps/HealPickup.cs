using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealPickup : MonoBehaviour
{
    
     void OnTriggerEnter(Collider collider)
    {
        //printing a statement to console for testing purposes
        print(collider);
        //if the the object that colided with the health pick up has a player tag 
        //then get the players health script and check to see if ther is one and add health
        if (collider.tag == "PlayerGrabBox")
        {
            print("pick up player");
            //colider.GetComponent gets the health script from the player not the pickup
            Health health = collider.transform.root.GetComponent<Health>();
            AddHealth(health);
        }
    }
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void AddHealth(Health health)
    {
        if (health != null)
        {

            health.Damage(-50);
            gameObject.SetActive(false);
        }
    }
}
