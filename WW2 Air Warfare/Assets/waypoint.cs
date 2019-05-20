﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class waypoint : MonoBehaviour
{
    int current = 0;
    public GameObject[] Waypoints;
    public float speed;
    float Wpradius = 1;

    Vector3 lastPos;

    [SerializeField] float turnSpeed = 30f;

    void Update()
    {

        if (Vector3.Distance(Waypoints[current].transform.position, transform.position) < Wpradius)
        {
            current++;
            if (current >= Waypoints.Length)
            {
                current = 0;
            }
        }
        transform.position = Vector3.MoveTowards(transform.position, Waypoints[current].transform.position, Time.deltaTime * speed);

        Vector3 newDir = Waypoints[current].transform.position - transform.position;
        //Debug.Log(transform.position + newDir);

        //transform.LookAt(transform.position + lastPos - transform.position);

        transform.rotation = Quaternion.LookRotation(Vector3.RotateTowards(transform.forward, newDir, turnSpeed * Time.deltaTime, 0.0f));

        lastPos = transform.position;
    }
}
