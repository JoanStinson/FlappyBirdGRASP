using System.Diagnostics;
using UnityEngine;
using System.IO;

namespace JGM.Editor
{
    public static class OpenProjectFolderButton
    {
        [ToolbarButton(IconName = "Folder Icon", Tooltip = "Open Project Folder")]
        public static void OnButtonClick()
        {
            Process cmd = new Process();
#if UNITY_EDITOR_WIN
            cmd.StartInfo.FileName = "explorer.exe";
#endif
            var projectPath = Directory.GetParent(Application.dataPath).FullName;
            cmd.StartInfo.Arguments = projectPath;
            cmd.Start();
        }
    }
}