using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PlaneFlight
{
    public class XboxPlaneInput : BasePlaneInput
    {
        protected override void HandleInput()
        {
            //Keyboard
            base.HandleInput();

            //Main Inputs
            pitch += Input.GetAxis("Vertical");
            roll += Input.GetAxis("Horizontal");
            yaw += Input.GetAxis("XboxRStickH");
            throttle += Input.GetAxis("XboxRStickV");

            //Brake Inputs
            brake = Input.GetButton("Brake") ? 1f : 0f;

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
    }
}
