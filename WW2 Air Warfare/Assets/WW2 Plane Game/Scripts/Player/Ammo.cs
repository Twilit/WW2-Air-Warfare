using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Ammo : MonoBehaviour
{
    public TextMeshProUGUI gunAmmoUI;
    public TextMeshProUGUI bombAmmoUI;

    [SerializeField] int maximumAmmo = 5;
    //seting a maximum health variable as 100 which can be changed in the inspector

    [SerializeField] private int CurrentAmmo = 0;

    [SerializeField]
    int maxBombs = 3;

    int currentBombCount = 0;




    // Use this for initialization
    void Start()
    {

        // setting the current health the same as max health at the start of the game
        CurrentAmmo = maximumAmmo;
        currentBombCount = maxBombs;

    }
    void LateUpdate()
    {
        //GetComponent<Rigidbody>().AddForce(new Vector3(100, 0, 0));

        if (gunAmmoUI && bombAmmoUI)
        {
            gunAmmoUI.text = CurrentAmmo + "/" + maximumAmmo;
            bombAmmoUI.text = "x" + currentBombCount;
        }
    }



    public bool HasGunAmmo { get { return CurrentAmmo >0; } }
    //using IsDead to get the result of the code current health <=0

    public bool HasBombAmmo { get { return currentBombCount > 0; } }
    //using IsDead to get the result of the code current health <=0


    public void ChangeGunAmmo(int ChangeValue)
    {
        CurrentAmmo -= ChangeValue;
        //if the code is equles to or less that 0 then the game object will be destoryed.
        if(CurrentAmmo < 0)
        {
            CurrentAmmo = 0;
        }

    }

    public void ChangeBombAmmo(int ChangeValue)
    {
        currentBombCount -= ChangeValue;
        //if the code is equles to or less that 0 then the game object will be destoryed.
        if (currentBombCount < 0)
        {
            currentBombCount = 0;
        }

    }
}

