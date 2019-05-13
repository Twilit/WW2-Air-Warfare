using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PlaneFlight
{
    [RequireComponent(typeof(PlaneCharacteristics))]
    public class PlaneController : BaseRBController
    {
        #region Variables
        [Header("Base Plane Properties")]
        public BasePlaneInput input;
        public PlaneCharacteristics characteristics;
        public Transform centreOfGravity;

        [Tooltip("Weight is in kilograms.")]
        public float planeWeight = 1953f;

        [Header("Engines")]
        public List<PlaneEngine> engines = new List<PlaneEngine>();

        [Header("Wheels")]
        public List<PlaneWheel> wheels = new List<PlaneWheel>();

        [Header("Control Surfaces")]
        public List<PlaneControlSurface> controlSurfaces = new List<PlaneControlSurface>();
        #endregion

        #region BuiltIn Methods
        public override void Start()
        {
            base.Start();

            if (rb)
            {
                rb.mass = planeWeight;
                if (centreOfGravity)
                {
                    rb.centerOfMass = centreOfGravity.localPosition;
                }

                characteristics = GetComponent<PlaneCharacteristics>();
                if (characteristics)
                {
                    characteristics.InitCharacteristics(rb, input);
                }
            }

            if (wheels != null)
            {
                if (wheels.Count > 0)
                {
                    foreach(PlaneWheel wheel in wheels)
                    {
                        wheel.InitWheel();
                    }
                }
            }
        }
        #endregion

        #region Custom Methods
        protected override void HandlePhysics()
        {
            if (input)
            {
                HandleEngines();
                HandleCharacteristics();
                HandleControlSurfaces();
                HandleSteering();
                HandleBrakes();
                HandleAltitude();                
            }
        }

        void HandleEngines()
        {
            if (engines != null)
            {
                if (engines.Count > 0)
                {
                    foreach (PlaneEngine engine in engines)
                    {
                        rb.AddForce(engine.CalculateForce(input.StickyThrottle));
                    }
                }
            }
        }

        void HandleCharacteristics()
        {
            if (characteristics)
            {
                characteristics.UpdateCharacteristics();
            }
        }

        void HandleControlSurfaces()
        {
            if (controlSurfaces.Count > 0)
            {
                foreach(PlaneControlSurface controlSurface in controlSurfaces)
                {
                    controlSurface.HandleControlSurface(input);
                }
            }
        }

        void HandleSteering()
        {

        }
        void HandleBrakes()
        {

        }

        void HandleAltitude()
        {

        }
        #endregion
    }
}
