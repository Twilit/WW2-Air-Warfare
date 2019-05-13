using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PlaneFlight
{
    public class BasicFollowCam : MonoBehaviour
    {
        #region Variables
        [Header("Basic Follow Camera Properties")]
        public Transform target;
        public float distance = 5f;
        public float height = 2f;
        public float smoothSpeed = 0.5f;

        private Vector3 smoothVelocity;
        protected float originalHeight;
        #endregion

        #region Built In Methods
        void Start()
        {
            originalHeight = height;
        }

        void FixedUpdate()
        {
            if (target)
            {
                HandleCamera();
            }
        }
        #endregion

        #region Custom Methods
        protected virtual void HandleCamera()
        {
            //Follow Target
            Vector3 wantedPostion = target.position + (-target.transform.forward * distance) + (Vector3.up * height);
            transform.position = Vector3.SmoothDamp(transform.position, wantedPostion, ref smoothVelocity, smoothSpeed);

            transform.LookAt(target);
        }
        #endregion
    }
}

