using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    #region Variables
    [Header("Gun Properties")]
    public float damage = 10f;
    public Transform[] guns;
    #endregion

    #region BuiltIn Methods
    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            ShootGuns();
        }

        if (Input.GetButtonDown("Fire2"))
        {

        }
    }
    #endregion

    #region Custom Methods
    void ShootGuns()
    {
        foreach(Transform gun in guns)
        {
            ParticleSystem muzzleFlash = gun.GetComponent<ParticleSystem>();

            if (muzzleFlash)
            {
                muzzleFlash.Play();
            }

            RaycastHit hit;

            if (Physics.Raycast(gun.position, gun.forward, out hit))
            {

            }
        }
    }
    #endregion
}
