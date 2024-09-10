using UnityEditor;
using UnityEngine;
using BFyreUnityExtensions.ReadOnlyDrawer;

namespace BFyreUnityExtensions.ReadOnlyDrawer.Editor
{
    [CustomPropertyDrawer(typeof(ReadOnlyAttribute))]
    public class ReadOnlyDrawer : PropertyDrawer
    {
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            GUI.enabled = false;
            EditorGUI.PropertyField(position, property, label, true);
            GUI.enabled = true;
        }
    }
}