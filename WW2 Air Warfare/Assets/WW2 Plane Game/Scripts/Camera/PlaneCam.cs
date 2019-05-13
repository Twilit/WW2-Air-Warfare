using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PlaneFlight
{
    public class PlaneCam : BasicFollowCam
    {
        #region Variables
        [Header("Airplane Camera Properties")]
        public float minHeightFromGround;
        #endregion

        protected override void HandleCamera()
        {
            RaycastHit hit;

            if (Physics.Raycast(transform.position, Vector3.down, out hit))
            {
                if (hit.distance < minHeightFromGround && hit.transform.tag == "Ground")
                {
                    float wantedHeight = originalHeight + (minHeightFromGround - hit.distance);
                    height = wantedHeight;
                }
            }

            base.HandleCamera();
        }
    }
}
