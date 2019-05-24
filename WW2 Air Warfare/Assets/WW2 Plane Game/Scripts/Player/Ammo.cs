using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ammo : MonoBehaviour
{

    [SerializeField] int maximumAmmo = 5;
    //seting a maximum health variable as 100 which can be changed in the inspector

    [SerializeField] public int CurrentAmmo = 0;




    // Use this for initialization
    void Start()
    {

        // setting the current health the same as max health at the start of the game
        CurrentAmmo = maximumAmmo;


    }
    void Update()
    {
        //GetComponent<Rigidbody>().AddForce(new Vector3(100, 0, 0));
    }
    
    public bool HasAmmo { get { return CurrentAmmo >0; } }
    //using IsDead to get the result of the code current health <=0


    public void Change(int ChangeValue)
    {
        CurrentAmmo -= ChangeValue;
        //if the code is equles to or less that 0 then the game object will be destoryed.
        if(CurrentAmmo < 0)
        {
            CurrentAmmo = 0;        }

    }
}

