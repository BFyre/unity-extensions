using System.IO;
using UnityEditor;
using UnityEngine;

namespace BFyre.Common.Editor
{
    /// <summary>
    /// This class allows assigning directories as serialized fields via dragging them to a box in Unity inspector.
    /// Useful e.g. for specifying directories for file generation in custom editors.
    /// </summary>
    public static class EditorGUILayoutExtensions
    {
        public static Object DirectoryField(Object obj, string labelText)
        {
            // set control name to allow focus
            string controlName = nameof(DirectoryField) + labelText.GetHashCode(); // todo: look for better way to set unique control name
            GUI.SetNextControlName(controlName);

            // draw content and label
            GUIContent guiContent = EditorGUIUtility.ObjectContent(obj, typeof(DefaultAsset));
            Rect rect = EditorGUI.PrefixLabel(EditorGUILayout.GetControlRect(), new GUIContent(labelText));

            // set asset image
            GUIStyle textFieldStyle = new GUIStyle("TextField")
            {
                imagePosition = obj ? ImagePosition.ImageLeft : ImagePosition.TextOnly,
            };

            // set custom text when reference is null
            if (!obj)
            {
                guiContent.text = "None (Directory)";
            }

            // add button to the control
            if (GUI.Button(rect, guiContent, textFieldStyle))
            {
                // focus the control with visual outline
                GUI.FocusControl(controlName);

                if (obj)
                {
                    // highlight asset in project window
                    EditorGUIUtility.PingObject(obj);
                }
            }

            // check for pressed key when this control is focused
            if (Event.current.type == EventType.KeyDown && GUI.GetNameOfFocusedControl() == controlName)
            {
                if (Event.current.keyCode == KeyCode.Delete)
                {
                    Event.current.Use();
                    return null;
                }
            }

            // check if mouse cursor is on the control
            if (rect.Contains(Event.current.mousePosition))
            {
                // dragging in progress
                if (Event.current.type == EventType.DragUpdated)
                {
                    Object reference = DragAndDrop.objectReferences[0];
                    string path = AssetDatabase.GetAssetPath(reference);
                    // check if the dragged asset is a directory, if yes show indicator that it can be dropped
                    DragAndDrop.visualMode = Directory.Exists(path) ? DragAndDropVisualMode.Copy : DragAndDropVisualMode.Rejected;
                    Event.current.Use();
                }
                // dragging finished
                else if (Event.current.type == EventType.DragPerform)
                {
                    Object reference = DragAndDrop.objectReferences[0];
                    string path = AssetDatabase.GetAssetPath(reference);
                    if (Directory.Exists(path))
                    {
                        obj = reference;
                    }

                    GUI.FocusControl(controlName);
                    GUI.changed = true;
                    Event.current.Use();
                }
            }

            return obj;
        }
    }
}