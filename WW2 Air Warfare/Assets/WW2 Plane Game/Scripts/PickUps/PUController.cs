using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PUController : MonoBehaviour
{
    private GameObject HUP;
    private GameObject AUP;
    private GameObject BUP;

    bool spawning = false;

    void Start()
    {
        HUP = GameObject.FindGameObjectWithTag("HealthPU");
        AUP = GameObject.FindGameObjectWithTag("AmmoPU");
        BUP = GameObject.FindGameObjectWithTag("BombPU");
    }

    void Update()
    {
        if (HUP.activeInHierarchy == false && !spawning)
        {
            StartCoroutine("Spawn", 1);
        }
        else if (AUP.activeInHierarchy == false && !spawning)
        {
            StartCoroutine("Spawn", 2);
        }
        else if (BUP.activeInHierarchy == false && !spawning)
        {
            StartCoroutine("Spawn", 3);
        }
    }

    IEnumerator Spawn(int identity)
    {
        spawning = true;

        yield return new WaitForSeconds(5f);

        if (identity == 1)
        {
            HUP.SetActive(true);
        }
        else if (identity == 2)
        {
            AUP.SetActive(true);
        }
        else if (identity == 3)
        {
            BUP.SetActive(true);
        }

        spawning = false;
    }
}
