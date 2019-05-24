using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoPickup : MonoBehaviour
{ 

    void OnTriggerEnter(Collider collider)
    {
    //printing a statement to console for testing purposes
    print("pick up");
        //if the the object that colided with the health pick up has a player tag 
        //then get the players health script and check to see if ther is one and add health
        if (collider.tag == "PlayerGrabBox")
        {
            //colider.GetComponent gets the health script from the player not the pickup
            Ammo Ammo = collider.transform.root.GetComponent<Ammo>();

            AddAmmo(Ammo);
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

    public void AddAmmo(Ammo ammo)
    {
        if (ammo != null)
        {

            ammo.ChangeGunAmmo(-50);
            gameObject.SetActive(false);
        }
    }
}
