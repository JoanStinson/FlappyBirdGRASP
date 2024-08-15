using System.Diagnostics;
using System;
using UnityEngine;
using System.IO;

namespace JGM.Editor
{
    public static class OpenForkButton
    {
#if UNITY_EDITOR_WIN
        [ToolbarButton(IconName = "UnityEditor.VersionControl", Tooltip = "Open Fork")]
        public static void OnButtonClick()
        {
            var projectPath = Directory.GetParent(Application.dataPath).FullName;
            var forkPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);

            Process cmd = new Process();
            cmd.StartInfo.FileName = forkPath + "\\Fork\\Fork.exe";
            cmd.StartInfo.Arguments = projectPath;
            cmd.Start();
        }
#endif
    }
}