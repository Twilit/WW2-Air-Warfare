using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PlaneFlight
{
    public class PlaneAudio : MonoBehaviour
    {
        #region Variables
        [Header("Plane Audio Properties")]
        public BasePlaneInput input;
        public PlaneCharacteristics characteristics;
        public AudioSource idleSource;
        public AudioSource fullThrotSource;
        public AudioSource wind;
        public float maxPitchValue = 1.2f;

        private float finalVolumeValue;
        private float finalWindVolumeValue;
        private float finalPitchValue;
        #endregion

        #region BuiltIn Methods
        void Start()
        {
            if (fullThrotSource)
            {
                fullThrotSource.volume = 0f;
            }
            if (wind)
            {
                wind.volume = 0f;
            }
        }

        void Update()
        {
            if (input && characteristics)
            {
                HandleAudio();
            }
        }
        #endregion

        #region Custom Methods
        protected virtual void HandleAudio()
        {
            finalVolumeValue = Mathf.Lerp(0f, 0.7f, input.StickyThrottle);
            finalWindVolumeValue = Mathf.Lerp(0f, 1f, characteristics.mph/characteristics.maxMPH);
            finalPitchValue = Mathf.Lerp(1f, maxPitchValue, input.StickyThrottle);

            if (fullThrotSource)
            {
                fullThrotSource.volume = finalVolumeValue;
                fullThrotSource.pitch = finalPitchValue;

                wind.volume = finalWindVolumeValue;
            }
        }
        #endregion
    }
}