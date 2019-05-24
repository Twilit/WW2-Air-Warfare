﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Beam : MonoBehaviour
{
    private Transform player;

    void Start()
    {
        if (GameObject.FindGameObjectWithTag("Player"))
        player = GameObject.FindGameObjectWithTag("Player").transform.root;

        Invoke("Decay", 5f);
    }

    void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * 1500f);
        if(player)
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(player.position - transform.position), Time.deltaTime * 0.008f);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.root.tag == "Player")
        {
            print("Hit");
            other.transform.root.GetComponent<Rigidbody>().AddForce(transform.right*500000);
            other.transform.root.GetComponent<Rigidbody>().AddTorque(transform.up * 130000);
            Destroy(gameObject);
        }
    }

    void Decay()
    {
        Destroy(gameObject);
    }
}
