using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ammo : MonoBehaviour
{

    [SerializeField] int maximumAmmo = 100;
    //seting a maximum health variable as 100 which can be changed in the inspector

    [SerializeField] private int CurrentAmmo = 0;




    public Renderer rend;

    // Use this for initialization
    void Start()
    {

        // setting the current health the same as max health at the start of the game
        CurrentAmmo = maximumAmmo;


    }
    void Update() { 

    }



    public bool IsDead { get { return CurrentAmmo <= 0; } }
    //using IsDead to get the result of the code current health <=0


    public void Change(int ChangeValue)
    {
        CurrentAmmo -= ChangeValue;
        //if the code is equles to or less that 0 then the game object will be destoryed.

        if (CurrentAmmo <= 0)
        {
            //if the objects is not nuseing the player tag then add 50 to the players score and destroy the game object
            if (gameObject.tag != "player") //POSIBLE IDEA if (gameObject.tag == "Enemy1")

            {
;
                GetComponent<UnityEngine.AI.NavMeshAgent>().isStopped = true;
            }



        }

    }
}

