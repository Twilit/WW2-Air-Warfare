using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PlaneFlight
{
    public class PlaneEngine : MonoBehaviour
    {
        #region Variables
        [Header("Engine Properties")]
        public float maxForce = 200f;
        public float maxRPM = 3000f;

        public AnimationCurve powerCurve = AnimationCurve.Linear(0f, 0f, 1f, 1f);

        [Header("Propellers")]
        public PlanePropeller propeller;
        #endregion

        #region BuiltIn Variables

        #endregion

        #region Custom Methods
        public Vector3 CalculateForce(float throttle)
        {
            //Calculate Power
            float finalThrottle = Mathf.Clamp01(throttle);
            finalThrottle = powerCurve.Evaluate(finalThrottle);

            //Calculate RPM
            float currentRPM = finalThrottle * maxRPM;
            if (propeller)
            {
                propeller.HandlePropeller(currentRPM);
            }

            //Create Force
            float finalPower = finalThrottle * maxForce;
            Vector3 finalForce = transform.forward * finalPower;

            return finalForce;
        }
        #endregion
    }
}
