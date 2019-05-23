using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PlaneFlight
{
    public class DropBomb : MonoBehaviour
    {
        #region Variables
        public BasePlaneInput input;
        public GameObject bomb;
        public AudioSource bombDropAudio;
        public float dropRate = 1f;

        public Ammo ammo;


        private float dropDelay = 0f;
        #endregion

        #region BuiltIn Methods
        void Start()
        {
            ammo = transform.root.GetComponent<Ammo>();
        }

        void Update()
        {
            if (input)
            {
                if (ammo.HasAmmo)
                {


                    if (input.BombDrop && Time.time >= dropDelay)
                    {
                        input.BombDrop = false;
                        dropDelay = Time.time + 1f / dropRate;

                        if (ammo.HasAmmo)
                        {
                            Debug.Log("Has Ammo: " + ammo.HasAmmo);

                            ammo.Change(1);

                            HandleBombing();

                        }
                    }
                    else if (input.BombDrop && Time.time < dropDelay)
                    {
                        input.BombDrop = false;
                    }
                }
            }
        }
        #endregion

        #region Custom Methods
        void HandleBombing()
        {
            bombDropAudio.Play();
            GameObject droppedBomb = Instantiate(bomb, transform.position, Quaternion.Euler(new Vector3(transform.eulerAngles.x, transform.eulerAngles.y - 180, transform.eulerAngles.z)));
            droppedBomb.GetComponent<Rigidbody>().velocity = input.gameObject.GetComponent<Rigidbody>().velocity;
            ammo.Change(1);
        }
        #endregion
    }
}