using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PUController : MonoBehaviour
{
    private GameObject HUP;
    private GameObject AUP;
    private GameObject BUP;

    public float respawnTime = 10f;
    public float respawnDelay = 10f;

    void Start()
    {
        HUP = GameObject.FindGameObjectWithTag("HealthPU");
        AUP = GameObject.FindGameObjectWithTag("AmmoPU");
        BUP = GameObject.FindGameObjectWithTag("BombPU");
    }

    void Update()
    {
        if (HUP.activeInHierarchy == false)
        {

        }
        else if (AUP.activeInHierarchy == false)
        {

        }
    }
}
