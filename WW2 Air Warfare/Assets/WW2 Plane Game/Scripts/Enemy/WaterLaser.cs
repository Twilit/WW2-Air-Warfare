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
        while (shootingBeam)
        {
            if(player)
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(player.position - transform.position), Time.deltaTime * trackingSpeed);

            spit.Play();
            Instantiate(beam, transform.position, transform.rotation);
            yield return new WaitForSeconds(3f);
        }
    }
}
