using System.Diagnostics;
using UnityEngine;
using System.IO;

namespace JGM.Editor
{
    public static class OpenTerminalButton
    {
        [ToolbarButton(IconName = "d_winbtn_win_max", Tooltip = "Open Terminal")]
        public static void OnButtonClick()
        {
            Process cmd = new Process();
#if UNITY_EDITOR_WIN
            cmd.StartInfo.FileName = "cmd.exe";
#endif
#if UNITY_EDITOR_OSX
            cmd.StartInfo.FileName = "/Applications/Utilities/Terminal.app/Contents/MacOS/Terminal";
#endif
            var projectPath = Directory.GetParent(Application.dataPath).FullName;
            cmd.StartInfo.WorkingDirectory = projectPath;
            cmd.Start();
        }
    }
}