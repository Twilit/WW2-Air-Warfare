using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PlaneFlight
{
    [RequireComponent(typeof(WheelCollider))]
    public class PlaneWheel : MonoBehaviour
    {
        #region Variables
        [Header("Wheel Properties")]
        public Transform wheelGraphic;
        public bool isBraking = false;
        public float brakePower = 5f;
        public bool isSteering = false;
        public float steerAngle = 20f;
        public float steerSmoothSpeed = 2f;

        private WheelCollider wheelCol;
        private Vector3 worldPos;
        private Quaternion worldRot;
        private float finalBrakeForce;
        private float finalSteerAngle;
        #endregion

        #region BuiltIn Methods
        private void Start()
        {
            wheelCol = GetComponent<WheelCollider>();
        }
        #endregion

        #region Custom Methods
        public void InitWheel()
        {
            if (wheelCol)
            {
                wheelCol.motorTorque = 0.000000000001f;
            }
        }

        public void HandleWheel(BasePlaneInput input)
        {
            if (wheelCol)
            {
                wheelCol.GetWorldPose(out worldPos, out worldRot);
                
                if (wheelGraphic)
                {
                    wheelGraphic.position = worldPos;
                    wheelGraphic.rotation = worldRot;
                }
                if (isBraking)
                {
                    if (input.Brake > 0.1f)
                    {
                        finalBrakeForce = Mathf.Lerp(finalBrakeForce, input.Brake * brakePower, Time.deltaTime);
                        wheelCol.brakeTorque = input.Brake * brakePower;
                    }
                    else
                    {
                        finalBrakeForce = 0f;
                        wheelCol.brakeTorque = 0f;
                        wheelCol.motorTorque = 0.000000000001f;
                    }
                }
                if (isSteering)
                {
                    finalSteerAngle = Mathf.Lerp(finalSteerAngle, -input.Yaw * steerAngle, Time.deltaTime * steerSmoothSpeed);
                    wheelCol.steerAngle = finalSteerAngle;
                }
            }
        }
        #endregion
    }
}

