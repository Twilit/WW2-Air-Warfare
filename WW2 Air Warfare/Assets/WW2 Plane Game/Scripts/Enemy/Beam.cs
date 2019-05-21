using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Beam : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * 1000f);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.root.tag == "Player")
        {
            print("Hit");
            other.transform.root.GetComponent<Rigidbody>().AddForce(transform.forward*300000);
            other.transform.root.GetComponent<Rigidbody>().AddTorque(transform.up * 130000);
        }
    }
}
