using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spwancrab : MonoBehaviour
{
    [SerializeField] private Transform crab;
    [SerializeField] private Transform spwanpoint;

    private void OnTriggerEnter(Collider other)
    {
        crab.transform.position = spwanpoint.transform.position;
    }
}
