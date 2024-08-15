using UnityEditor;
using UnityEngine;

namespace JGM.Editor
{
    public static class OpenEditorSettingsButton
    {
        [ToolbarButton(IconName = "Settings", Tooltip = "Open Settings")]
        public static void OnButtonClick()
        {
            var a = new GenericMenu();
            a.AddItem(new GUIContent("Project"), false, () => EditorApplication.ExecuteMenuItem("Edit/Project Settings..."));
            a.AddItem(new GUIContent("Preferences"), false, () => EditorApplication.ExecuteMenuItem("Edit/Preferences..."));
            a.ShowAsContext();
        }
    }
}