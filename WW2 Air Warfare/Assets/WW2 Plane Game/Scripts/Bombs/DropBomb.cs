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

        private float dropDelay = 0f;
        #endregion

        #region BuiltIn Methods
        void Start()
        {

        }

        void Update()
        {
            if (input)
            {
                if (input.BombDrop && Time.time >= dropDelay)
                {
                    input.BombDrop = false;
                    dropDelay = Time.time + 1f / dropRate;

                    HandleBombing();
                }
            }
        }
        #endregion

        #region Custom Methods
        void HandleBombing()
        {
            bombDropAudio.Play();
            Instantiate(bomb, transform.position, Quaternion.Euler(new Vector3 (transform.eulerAngles.x, transform.eulerAngles.y -180, transform.eulerAngles.z)));
        }
        #endregion
    }
}   
