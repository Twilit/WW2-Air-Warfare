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
        public AudioSource gunshotSound;

        private float fireDelay = 0f;
        private LineRenderer tracer;
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
            }
        }
        #endregion

        #region Custom Methods
        void ShootGuns()
        {
            foreach (Transform gun in guns)
            {
                ParticleSystem muzzleFlash = gun.GetComponent<ParticleSystem>();
                tracer = gun.GetComponent<LineRenderer>();

                if (muzzleFlash)
                {
                    muzzleFlash.Play();
                }

                if (gunshotSound)
                {
                    gunshotSound.Play();
                }

                RaycastHit hit;

                tracer.SetPosition(0, gun.position);

                if (Physics.Raycast(gun.position, gun.forward, out hit))
                {
                    tracer.SetPosition(1, hit.point);

                    if (hit.transform.tag == "Enemy")
                    {
                        hit.transform.GetComponent<CrabHealth>().DealDamage(3);
                        print("Dealt damage");
                    }

                    if (explosion)
                    {
                        GameObject impactGameObject = Instantiate(explosion, hit.point, Quaternion.LookRotation(hit.normal));

                        Destroy(impactGameObject, 5f);
                    }
                }
                else
                {
                    tracer.SetPosition(1, gun.position + gun.forward * 1000);
                }

                StartCoroutine("DrawTracer");
            }
        }

        IEnumerator DrawTracer()
        {
            tracer.enabled = true;

            yield return new WaitForSeconds(0.01f);

            foreach (Transform gun in guns)
            {
                tracer = gun.GetComponent<LineRenderer>();
                tracer.enabled = false;
            }
        }
        #endregion
    }
}
