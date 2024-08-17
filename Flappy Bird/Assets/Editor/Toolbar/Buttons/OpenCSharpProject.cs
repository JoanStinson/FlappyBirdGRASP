using UnityEditor;
using UnityEngine;

namespace JGM.Editor
{
    public static class OpenCSharpProject
    {
        [ToolbarButton(IconName = "UnityEditor.ConsoleWindow", Tooltip = "Open C# Project", Order = -100)]
        public static void OnButtonClick()
        {
            AssetDatabase.Refresh();
            UnityEditorInternal.InternalEditorUtility.OpenFileAtLineExternal(Application.dataPath + "/../" + Application.productName + ".sln", 0);
        }
    }
}