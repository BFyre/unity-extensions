using BFyre.Common.Attributes;
using UnityEditor;
using UnityEngine;

namespace BFyre.Common.Editor
{
    /// <summary>
    /// Property drawer for <see cref="BFyre.Common.Attributes.ReadOnlyAttribute"/>.
    /// It has to be put inside Editor folder!
    /// </summary>
    [CustomPropertyDrawer(typeof(ReadOnlyAttribute))]
    public class ReadOnlyDrawer : PropertyDrawer
    {
        public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
        {
            return EditorGUI.GetPropertyHeight(property, label, true);
        }

        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            GUI.enabled = false;
            EditorGUI.PropertyField(position, property, label, true);
            GUI.enabled = true;
        }
    }
}