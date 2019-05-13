using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace PlaneFlight
{
    [CustomEditor(typeof(BasePlaneInput))]
    public class BasePlaneInputEditor : Editor
    {
        #region Variables
        private BasePlaneInput targetInput;
        #endregion

        #region BuiltIn Methods
        private void OnEnable()
        {
            targetInput = (BasePlaneInput)target;
        }

        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

            string debugInfo = "";
            debugInfo += "Pitch: " + targetInput.Pitch + "\n";
            debugInfo += "Roll: " + targetInput.Roll + "\n";
            debugInfo += "Yaw: " + targetInput.Yaw + "\n";
            debugInfo += "Throttle: " + targetInput.Throttle + "\n";
            debugInfo += "Brake: " + targetInput.Brake + "\n";
            debugInfo += "Flaps: " + targetInput.Flaps + "\n";

            //Custom Editor Code
            GUILayout.Space(20);
            EditorGUILayout.TextArea(debugInfo, GUILayout.Height(80));
            GUILayout.Space(20);

            Repaint();
        }
        #endregion
    }

}
