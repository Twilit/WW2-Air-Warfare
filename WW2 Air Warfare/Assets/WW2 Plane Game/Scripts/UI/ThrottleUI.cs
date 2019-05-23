using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace PlaneFlight
{
    public class ThrottleUI : MonoBehaviour
    {
        public BasePlaneInput input;

        private Slider slider;

        void Start()
        {
            slider = GetComponent<Slider>();
        }

        void LateUpdate()
        {
            slider.value = input.StickyThrottle;
        }
    }
}