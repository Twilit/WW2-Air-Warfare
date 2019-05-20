using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PlaneFlight
{
    public class WingTrails : MonoBehaviour
    {
        public TrailRenderer leftTrails;
        public TrailRenderer rightTrails;
        public PlaneCharacteristics chara;

        void Start()
        {

        }

        void Update()
        {
            if (leftTrails & rightTrails & chara)
            {
                if (chara.mph == chara.maxMPH)
                {
                    leftTrails.emitting = true;
                    rightTrails.emitting = true;
                }
                else
                {
                    leftTrails.emitting = false;
                    rightTrails.emitting = false;
                }
            }
        }
    }
}