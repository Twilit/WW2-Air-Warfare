﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterLaser : MonoBehaviour
{
    public GameObject beam;
    public Transform player;
    public AudioSource spit;
    public bool shootingBeam;
    public float trackingSpeed = 10f;

    void Start()
    {
        shootingBeam = true;
        StartCoroutine("ShootLaser");
    }

    void Update()
    {

    }

    IEnumerator ShootLaser()
    {
        while (player)
        {
            if (shootingBeam)
            {
                Vector3 directionToPlayer = player.position - transform.parent.position;

                float angle = Vector3.Angle(transform.parent.forward, directionToPlayer);

                if (Mathf.Abs(angle) < 40f && Vector3.Distance(transform.position, player.position) < 4500)
                {
                    transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(player.position - transform.position), Time.deltaTime * trackingSpeed);

                    spit.Play();
                    Instantiate(beam, transform.position, transform.rotation);
                }
            }

            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(player.position - transform.position), Time.deltaTime * trackingSpeed);

            yield return new WaitForSeconds(3f);
        }
    }
}
