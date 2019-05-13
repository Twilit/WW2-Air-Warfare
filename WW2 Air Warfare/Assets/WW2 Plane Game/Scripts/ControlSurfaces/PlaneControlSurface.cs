using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PlaneFlight
{
    public enum ControlSurfaceType
    {
        Rudder,
        Elevator,
        Flap,
        Aileron
    }

    public class PlaneControlSurface : MonoBehaviour
    {
        #region Variables
        [Header("Control Surfaces Properties")]
        public ControlSurfaceType type = ControlSurfaceType.Rudder;
        public float maxAngle = 30f;
        public Vector3 axis = Vector3.right;
        public Transform controlSurfaceGraphic;
        public float smoothSpeed;

        private float wantedAngle;
        #endregion

        #region BuiltIn Methods
        void Start()
        {

        }

        void Update()
        {
            if (controlSurfaceGraphic)
            {
                Vector3 finalAngleAxis = axis * wantedAngle;
                controlSurfaceGraphic.localRotation = Quaternion.Slerp(controlSurfaceGraphic.localRotation, Quaternion.Euler(finalAngleAxis), Time.deltaTime * smoothSpeed);
            }
        }
        #endregion

        #region Custom Methods
        public void HandleControlSurface(BasePlaneInput input)
        {
            float inputValue = 0f;

            switch(type)
            {
                case ControlSurfaceType.Rudder:
                    inputValue = input.Yaw;
                    break;

                case ControlSurfaceType.Elevator:
                    inputValue = input.Pitch;
                    break;

                case ControlSurfaceType.Flap:
                    inputValue = input.Flaps;
                    break;

                case ControlSurfaceType.Aileron:
                    inputValue = input.Roll;
                    break;

                default:
                    break;
            }

            wantedAngle = maxAngle * inputValue;
        }
        #endregion
    }
}

