using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PlaneFlight
{
    public class PlaneCharacteristics : MonoBehaviour
    {
        #region Variables
        [Header("Characteristics Properties")]
        public float forwardSpeed;
        public float mph;
        public float maxMPH = 370;
        public float rbLerpSpeed = 0.01f;

        [Header("Lift Properties")]
        public float maxLiftPower = 800f;
        public AnimationCurve liftCurve = AnimationCurve.EaseInOut(0f, 0f, 1f, 1f);

        [Header("Drag Properties")]
        public float dragFactor = 0.01f;

        [Header("Control Properties")]
        public float pitchSpeed = 1000f;
        public float rollSpeed = 1000f;
        public float yawSpeed = 1000f;
        public AnimationCurve controlSurfaceEfficiency = AnimationCurve.EaseInOut(0f, 0f, 1f, 1f);

        private BasePlaneInput input;
        private Rigidbody rb;

        private float startDrag;
        private float startAngularDrag;

        private float maxMPS;
        private float normalisedMPH;

        private float angleOfAttack;
        private float pitchAngle;
        private float rollAngle;

        private float csEfficiencyValue;
        #endregion

        #region Constants
        const float mpsToMph = 2.23694f;
        #endregion

        #region BuiltIn Methods

        #endregion

        #region Custom Methods
        public void InitCharacteristics(Rigidbody currentRB, BasePlaneInput currentInput)
        {
            //Basic Initialistion
            input = currentInput;
            rb = currentRB;
            startDrag = rb.drag;
            startAngularDrag = rb.angularDrag;

            //Find max mps 
            maxMPS = maxMPH / mpsToMph;
        }

        public void UpdateCharacteristics()
        {
            if (rb)
            {
                //Process the flight model
                CalculateForwardSpeed();
                CalculateLift();
                CalculateDrag();
                HandleControlSurfaceEfficiency();
                HandlePitch();
                HandleRoll();
                HandleYaw();
                HandleBanking();
                HandleRigidBodyTransform();
            }
        }

        void CalculateForwardSpeed()
        {
            Vector3 localVelocity = transform.InverseTransformDirection(rb.velocity);
            forwardSpeed = Mathf.Max(0f, localVelocity.z);
            forwardSpeed = Mathf.Clamp(forwardSpeed, 0f, maxMPS);

            mph = forwardSpeed * mpsToMph;
            mph = Mathf.Clamp(mph, 0f, maxMPH);
            normalisedMPH = Mathf.InverseLerp(0f, maxMPH, mph);
        }

        void CalculateLift()
        {
            angleOfAttack = Vector3.Dot(rb.velocity.normalized, transform.forward);
            angleOfAttack *= angleOfAttack;
   
            Vector3 liftDir = transform.up;
            float liftPower = liftCurve.Evaluate(normalisedMPH) * maxLiftPower;

            Vector3 finalLiftForce = liftDir * liftPower * angleOfAttack;
            rb.AddForce(finalLiftForce);
        }

        void CalculateDrag()
        {
            float speedDrag = forwardSpeed * dragFactor;
            float finalDrag = startDrag + speedDrag;

            rb.drag = finalDrag;
            rb.angularDrag = startAngularDrag * forwardSpeed;
        }

        void HandleRigidBodyTransform()
        {
            if (rb.velocity.magnitude > 1f)
            {
                Vector3 updatedVelocity = Vector3.Lerp(rb.velocity, transform.forward * forwardSpeed, forwardSpeed * angleOfAttack * Time.deltaTime * rbLerpSpeed);
                rb.velocity = updatedVelocity;

                Quaternion updatedRotation = Quaternion.Slerp(rb.rotation, Quaternion.LookRotation(rb.velocity.normalized, transform.up), Time.deltaTime *rbLerpSpeed);
                rb.MoveRotation(updatedRotation);
            }
        }

        void HandleControlSurfaceEfficiency()
        {
            csEfficiencyValue = controlSurfaceEfficiency.Evaluate(normalisedMPH);
        }

        void HandlePitch()
        {
            Vector3 flatForward = transform.forward;
            flatForward.y = 0f;
            flatForward = flatForward.normalized;
            pitchAngle = Vector3.Angle(transform.forward, flatForward);

            Vector3 pitchTorque = input.Pitch * pitchSpeed * transform.right * csEfficiencyValue;
            rb.AddTorque(pitchTorque);
        }

        void HandleRoll()
        {
            Vector3 flatRight = transform.right;
            flatRight.y = 0f;
            flatRight = flatRight.normalized;
            rollAngle = Vector3.SignedAngle(transform.right, flatRight, transform.forward);

            Vector3 rollTorque = -input.Roll * rollSpeed * transform.forward * csEfficiencyValue;
            rb.AddTorque(rollTorque);
        }

        void HandleYaw()
        {
            Vector3 yawTorque = input.Yaw * yawSpeed * transform.up *csEfficiencyValue;
            rb.AddTorque(yawTorque);
        }
        
        void HandleBanking()
        {
            float bankSide = Mathf.InverseLerp(-90f, 90f, rollAngle);
            float bankAmount = Mathf.Lerp(-1f, 1f, bankSide);
            Vector3 bankTorque = bankAmount * rollSpeed * transform.up;
            rb.AddTorque(bankTorque);
        }
        #endregion
    }
}
