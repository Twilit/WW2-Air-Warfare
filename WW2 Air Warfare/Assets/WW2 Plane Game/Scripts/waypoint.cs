using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class waypoint : MonoBehaviour
{
    public bool reachedEnd = false;

    int current = 0;
    public GameObject[] Waypoints;
    public float speed;
    public bool repeat = true;
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
                reachedEnd = true;

                if (repeat)
                {
                    current = 0;
                }
            }
        }
        transform.position = Vector3.MoveTowards(transform.position, Waypoints[current].transform.position, Time.deltaTime * speed);

        Vector3 newDir = Waypoints[current].transform.position - transform.position;
        //Debug.Log(transform.position + newDir);

        //transform.LookAt(transform.position + lastPos - transform.position);

        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(newDir), Time.deltaTime * turnSpeed);

        lastPos = transform.position;
    }
}
