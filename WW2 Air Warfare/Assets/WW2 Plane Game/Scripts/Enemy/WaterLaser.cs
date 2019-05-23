using System.Collections;
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
        while (true)
        {
            if (shootingBeam)
            {
                Vector3 directionToPlayer = player.position - transform.root.position;

                float angle = Vector3.Angle(transform.forward, directionToPlayer);
                //print(angle);

                if (Mathf.Abs(angle) < 15f && Vector3.Distance(transform.position, player.position) < 8000)
                {
                    transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(player.position - transform.position), Time.deltaTime * trackingSpeed);

                    spit.Play();
                    Instantiate(beam, transform.position, transform.rotation);
                }                
            }

            yield return new WaitForSeconds(3f);
        }
    }
}
