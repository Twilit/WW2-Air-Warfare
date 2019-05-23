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
    }

    void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * 2800f);
        if(player)
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(player.position - transform.position), Time.deltaTime * 0.005f);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.root.tag == "Player")
        {
            print("Hit");
            other.transform.root.GetComponent<Rigidbody>().AddForce(transform.forward*500000);
            other.transform.root.GetComponent<Rigidbody>().AddTorque(transform.up * 130000);
            Destroy(gameObject);
        }
    }
}
