using UnityEditor;
using UnityEngine;

namespace CustomAttributes
{

    [CustomPropertyDrawer(typeof(LocalComponentAttribute))]
    public class LocalComponentDrawer : PropertyDrawer
    {
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            LocalComponentAttribute localComponentAttribute = attribute as LocalComponentAttribute;
            bool wasEnabled = GUI.enabled;
            if (!label.text.Contains(" (local)"))
                label.text += " (local)";

            if (localComponentAttribute.lockProperty)
                GUI.enabled = false;

            if (!localComponentAttribute.hideProperty)
                EditorGUI.PropertyField(position, property, label);

            GUI.enabled = wasEnabled;
            if (property.objectReferenceValue != null)
                return;

            GameObject mono = null;
            if (localComponentAttribute.parentObject != null && localComponentAttribute.parentObject != "")
            {
                string propertyPath = property.propertyPath; //returns the property path of the property we want to apply the attribute to
                string conditionPath = propertyPath.Replace(property.name, localComponentAttribute.parentObject); //changes the path to the conditionalsource property path
                SerializedProperty sourcePropertyValue = property.serializedObject.FindProperty(conditionPath);

                if (sourcePropertyValue != null)
                    mono = sourcePropertyValue.objectReferenceValue as GameObject;
                if (mono == null)
                {
                    property.objectReferenceValue = null;
                    return;
                }
                if (sourcePropertyValue == null)
                {
                    Debug.LogError("Field " + fieldInfo.Name + " doesn't exist!");
                    return;
                }

            }
            else
                mono = (property.serializedObject.targetObject as MonoBehaviour).gameObject;
            //if(fieldInfo.FieldType.IsSubclassOf(typeof(Component)) )
            if (typeof(Component).IsAssignableFrom(fieldInfo.FieldType))
            {
                if (property.objectReferenceValue == null)
                {
                    Component comp;
                    if (localComponentAttribute.getComponentFromChildrens)
                        comp = mono.GetComponentInChildren(fieldInfo.FieldType);
                    else
                        comp = mono.GetComponent(fieldInfo.FieldType);

                    property.objectReferenceValue = comp;
                }
            }
            else
            {
                Debug.LogError("Field <b>" + fieldInfo.Name + "</b> of " + mono.GetType() + " is not a component!", mono);
            }
        }
        public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
        {
            LocalComponentAttribute localComponentAttribute = attribute as LocalComponentAttribute;

            if (!localComponentAttribute.hideProperty)
                return EditorGUI.GetPropertyHeight(property, label);
            return -EditorGUIUtility.standardVerticalSpacing;
        }
    }
}

