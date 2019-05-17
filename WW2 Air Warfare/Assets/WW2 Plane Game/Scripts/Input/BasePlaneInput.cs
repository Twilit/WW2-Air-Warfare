﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PlaneFlight
{
    public class BasePlaneInput : MonoBehaviour
    {
        #region Variables
        protected float pitch = 0f;
        protected float roll = 0f;
        protected float yaw = 0f;
        protected float throttle = 0f;

        protected float brake = 0f;

        protected int maxFlapIncrements = 2;
        protected int flaps = 0;

        public float throttleSpeed = 0.1f;
        protected float stickyThrottle;
        #endregion

        #region Properties
        public float Pitch
        {
            get { return pitch; }
        }
        public float Roll
        {
            get { return roll; }
        }
        public float Yaw
        {
            get { return yaw; }
        }
        public float Throttle
        {
            get { return throttle; }
        }
        public float Flaps
        {
            get { return flaps; }
        }
        public float Brake
        {
            get { return brake; }
        }
        public float StickyThrottle
        {
            get { return stickyThrottle; }
        }
        #endregion

        #region BuiltIn Methods
        void Start()
        {

        }

        void Update()
        {
            HandleInput();
            StickyThrottleControl();
            ClampInputs();
        }
        #endregion

        #region Custom Methods
        protected virtual void HandleInput()
        {
            //Main Inputs
            pitch = Input.GetAxis("Vertical");
            roll = Input.GetAxis("Horizontal");
            yaw = Input.GetAxis("Yaw");
            throttle = Input.GetAxis("Throttle");

            //Brake Inputs
            brake = Input.GetButton("Brake")? 1f : 0f;

            //Flap Inputs
            if (Input.GetButtonDown("FlapUp"))
            {
                flaps += 1;
            }

            if (Input.GetButtonDown("FlapDown"))
            {
                flaps -= 1;
            }

            flaps = Mathf.Clamp(flaps, 0, maxFlapIncrements);
        }

        protected void StickyThrottleControl()
        {
            stickyThrottle = stickyThrottle + (throttle * throttleSpeed * Time.deltaTime);
            stickyThrottle = Mathf.Clamp01(stickyThrottle);
        }

        protected void ClampInputs()
        {
            pitch = Mathf.Clamp(pitch, -1f, 1f);
            roll = Mathf.Clamp(roll, -1f, 1f);
            yaw = Mathf.Clamp(yaw, -1f, 1f);
            throttle = Mathf.Clamp(throttle, -1f, 1f);
        }
        #endregion
    }
}

