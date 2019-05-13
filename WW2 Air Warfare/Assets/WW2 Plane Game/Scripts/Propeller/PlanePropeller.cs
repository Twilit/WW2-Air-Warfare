using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PlaneFlight
{
    public class PlanePropeller : MonoBehaviour
    {
        #region Variables
        [Header("Propeller Properties")]
        public float minQuadRPMs = 300f;
        public float minTextureSwapLevel2 = 700f;
        public float minTextureSwapLevel3 = 1500f;
        public GameObject mainProp;
        public GameObject blurredProp;

        [Header("Material Properties")]
        public Material blurredPropMat;
        public Texture2D blurLevel1;
        public Texture2D blurLevel2;
        public Texture2D blurLevel3;
        #endregion

        #region BuiltIn Methods
        private void Start()
        {
            if (mainProp && blurredProp)
            {
                HandleSwapping(0f);
            }
        }
        #endregion

        #region Custom Methods
        public void HandlePropeller(float currentRPM)
        {
            //Get the current degrees per second
            float dps = ((currentRPM * 360f) / 60f) * Time.deltaTime;

            //Rotate Propeller
            transform.Rotate(Vector3.forward, dps);

            //Handle Propeller Swapping
            if (mainProp && blurredProp)
            {
                HandleSwapping(currentRPM);
            }           
        }

        void HandleSwapping(float currentRPM)
        {
            if (currentRPM > minQuadRPMs)
            {
                blurredProp.gameObject.SetActive(true);
                mainProp.gameObject.SetActive(false);

                if (blurredPropMat && blurLevel1 && blurLevel2 && blurLevel3)
                {
                    if (currentRPM > minTextureSwapLevel3)
                    {
                        blurredPropMat.SetTexture("_MainTex", blurLevel3);
                    }
                    else if (currentRPM > minTextureSwapLevel2)
                    {
                        blurredPropMat.SetTexture("_MainTex", blurLevel2);
                    }
                    else
                    {
                        blurredPropMat.SetTexture("_MainTex", blurLevel1);
                    }
                }                 
            }
            else
            {
                blurredProp.gameObject.SetActive(false);
                mainProp.gameObject.SetActive(true);
            }
        }
        #endregion
    }
}
