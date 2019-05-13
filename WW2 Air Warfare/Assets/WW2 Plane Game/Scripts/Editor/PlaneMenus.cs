using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace PlaneFlight
{
    public static class PlaneMenus
    {
        [MenuItem("Plane Tools/Create New Plane")]
        public static void CreateNewPlane()
        {
            Debug.Log("Creating new plane...");

            GameObject currentSelection = Selection.activeGameObject;
            if (currentSelection)
            {
                PlaneController currentController = currentSelection.AddComponent<PlaneController>();
                GameObject currentCoG = new GameObject("CoG");
                currentCoG.transform.SetParent(currentSelection.transform);

                currentController.centreOfGravity = currentCoG.transform;
            }
        }
    }
}
