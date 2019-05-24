using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombPickup : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "PlayerGrabBox")
        {
            Ammo Ammo = other.transform.root.GetComponent<Ammo>();
            AddBomb(Ammo);
        }
    }

    public void AddBomb(Ammo ammo)
    {
        if (ammo != null)
        {

            ammo.ChangeBombAmmo(-3);
            Destroy(gameObject);
        }
    }
}
