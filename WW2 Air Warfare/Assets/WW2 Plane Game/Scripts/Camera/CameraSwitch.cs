using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PlaneFlight {
    public class CameraSwitch : MonoBehaviour
    {
        public Camera mainCam;
        public Camera topCam;
        public BasePlaneInput input;

        private void Start()
        {
            mainCam.depth = 5;
            topCam.depth = 0;
            topCam.enabled = false;
        }

        void LateUpdate()
        {
            if (input)
            {
                if (input.TopCam)
                {
                    topCam.enabled = true;
                    topCam.depth = 10;
                }
                else
                {
                    topCam.enabled = false;
                    topCam.depth = 0;
                }
            }
    }
    }
}