using UnityEditor;
using UnityEngine;

namespace PITask.Editors
{
    [CustomEditor(typeof(Field))]
    public class FieldEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

            if(GUILayout.Button("Generate field"))
            {
                var fieldTarget = (Field)target;
                fieldTarget.ApplySettings();
            }
        }
    }
}
