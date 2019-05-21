﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PlaneFlight
{
    public class DropBomb : MonoBehaviour
    {
        #region Variables
        public BasePlaneInput input;
        public GameObject bomb;
        #endregion

        #region BuiltIn Methods
        void Start()
        {

        }

        void Update()
        {
            if (input)
            {
                if (input.BombDrop)
                {
                    input.BombDrop = false;

                    HandleBombing();
                }
            }
        }
        #endregion

        #region Custom Methods
        void HandleBombing()
        {
            Instantiate(bomb, transform.position, Quaternion.Euler(new Vector3 (transform.eulerAngles.x, transform.eulerAngles.y -180, transform.eulerAngles.z)));
        }
        #endregion
    }
}   