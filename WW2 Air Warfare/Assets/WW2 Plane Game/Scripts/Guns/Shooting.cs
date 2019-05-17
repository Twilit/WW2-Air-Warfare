using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PlaneFlight
{
    public class Shooting : MonoBehaviour
    {
        #region Variables
        [Header("Gun Properties")]
        public float damage = 10f;
        public float fireRate = 25f;
        public BasePlaneInput input;
        public Transform[] guns;
        public GameObject explosion;

        private float fireDelay = 0f;
        #endregion

        #region BuiltIn Methods
        void Start()
        {

        }

        void Update()
        {
            if (input)
            {
                if (input.Shooting && Time.time >= fireDelay)
                {
                    fireDelay = Time.time + 1f / fireRate;
                    ShootGuns();
                }

                if (Input.GetButtonDown("Fire2"))
                {

                }
            }
        }
        #endregion

        #region Custom Methods
        void ShootGuns()
        {
            foreach (Transform gun in guns)
            {
                ParticleSystem muzzleFlash = gun.GetComponent<ParticleSystem>();

                if (muzzleFlash)
                {
                    muzzleFlash.Play();
                }

                RaycastHit hit;

                if (Physics.Raycast(gun.position, gun.forward, out hit))
                {
                    if (explosion)
                    {
                        GameObject impactGameObject = Instantiate(explosion, hit.point, Quaternion.LookRotation(hit.normal));

                        Destroy(impactGameObject, 5f);
                    }
                }
            }
        }
        #endregion
    }
}
