using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PlaneFlight
{
    [RequireComponent(typeof(Rigidbody))]
    [RequireComponent(typeof(AudioSource))]
    public class BaseRBController : MonoBehaviour
    {
        #region Variables
        protected Rigidbody rb;
        protected AudioSource audioSource;
        #endregion

        #region BuiltIn Methods
        public virtual void Start()
        {
            rb = GetComponent<Rigidbody>();
            audioSource = GetComponent<AudioSource>();
            if (audioSource)
            {
                audioSource.playOnAwake = false;
            }
        }

        void FixedUpdate()
        {
            if (rb)
            {
                HandlePhysics();
            }
        }
        #endregion

        #region Custom Methods
        protected virtual void HandlePhysics()
        {

        }
        #endregion
    }
}
