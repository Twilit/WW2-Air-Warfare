using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Homing : MonoBehaviour
{
    public Transform crabTarget;
    public Rigidbody crabRidgidbody;

    public float Turn;
    public float CrabVelocity;
    private void FixedUpdate()
    {
        crabRidgidbody.velocity = transform.forward * CrabVelocity;
        var crabTargetRotation = Quaternion.LookRotation(crabTarget.position - transform.position);

        crabRidgidbody.MoveRotation(Quaternion.RotateTowards(transform.rotation, crabTargetRotation, Turn));
    }
    void OnTriggerEnter(Collider collider)
    {
        //printing a statement to console for testing purposes
        print("pick up");
        //if the the object that colided with the health pick up has a player tag 
        //then get the players health script and check to see if ther is one and add health
        if (collider.tag == "PlayerGrabBox")
        {
            print("hit");
            //colider.GetComponent gets the health script from the player not the pickup
            Health health = collider.transform.root.GetComponent<Health>();

            if (health != null)
            {
                health.Damage(+10);
                Destroy(gameObject);
            }
        }
    }

    private void Update()
    {
        Destroy(gameObject, 30f);
    }



}
