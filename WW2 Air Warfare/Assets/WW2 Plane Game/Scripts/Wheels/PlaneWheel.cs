using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PlaneFlight
{
    [RequireComponent(typeof(WheelCollider))]
    public class PlaneWheel : MonoBehaviour
    {
        #region Variables
        private WheelCollider wheelCol;
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
        #endregion
    }
}

