using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealPickup : MonoBehaviour {
    
     void OnTriggerEnter(Collider collider)
    {
        //printing a statement to console for testing purposes
        print("pick up");
        //if the the object that colided with the health pick up has a player tag 
        //then get the players health script and check to see if ther is one and add health
        if (collider.gameObject)
        {
            //colider.GetComponent gets the health script from the player not the pickup
            Health health = collider.GetComponent<Health>();
            if(health!=null)
            { 
             health.Damage(-50);

            }
        }
    }
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
