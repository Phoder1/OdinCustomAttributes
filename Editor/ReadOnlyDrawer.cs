using UnityEditor;
using UnityEngine;

namespace CustomAttributes
{
    [CustomPropertyDrawer(typeof(ReadOnlyAttribute))]
    public class ReadOnlyDrawer : PropertyDrawer
    {
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            bool enabled = GUI.enabled;
            GUI.enabled = false;
            EditorGUI.PropertyField(position, property, label);
            GUI.enabled = enabled;
        }
    }
}
