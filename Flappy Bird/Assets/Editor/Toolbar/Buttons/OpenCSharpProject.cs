using System;
using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices;
using UnityEditor;
using UnityEngine;
using Debug = UnityEngine.Debug;

namespace JGM.Editor
{
    public static class OpenCSharpProject
    {
        private const string m_visualStudioPath = @"C:\Program Files\Microsoft Visual Studio\2022\Community\Common7\IDE\devenv.exe";

        [ToolbarButton(IconName = "UnityEditor.ConsoleWindow", Tooltip = "Open C# Project", Order = -100)]
        public static void OnButtonClick()
        {
            AssetDatabase.Refresh();

            var visualStudioProcesses = Process.GetProcessesByName("devenv");
            if (visualStudioProcesses.Length > 0)
            {
                OpenExistingVisualStudioInstance(visualStudioProcesses[0]);
            }
            else
            {
                OpenNewVisualStudioInstance();
            }
        }

        private static void OpenExistingVisualStudioInstance(Process process)
        {
            IntPtr hWnd = process.MainWindowHandle;
            uint foregroundThreadId = GetWindowThreadProcessId(hWnd, out _);
            uint currentThreadId = GetCurrentThreadId();
            AttachThreadInput(currentThreadId, foregroundThreadId, true);
            ShowWindow(hWnd, 9);
            SetForegroundWindow(hWnd);
            AttachThreadInput(currentThreadId, foregroundThreadId, false);
        }

        private static void OpenNewVisualStudioInstance()
        {
            if (!File.Exists(m_visualStudioPath))
            {
                Debug.LogError("Visual Studio executable not found. Ensure the path is correct.");
                return;
            }

            string solutionPath = Path.GetFullPath(Application.dataPath + "/../" + Application.productName + ".sln");
            ProcessStartInfo startInfo = new ProcessStartInfo
            {
                FileName = m_visualStudioPath,
                Arguments = $"\"{solutionPath}\"",
                UseShellExecute = true
            };

            try
            {
                Process.Start(startInfo);
            }
            catch (Exception exception)
            {
                Debug.LogError("Could not open the C# project: " + exception.Message);
            }
        }

        [DllImport("user32.dll", SetLastError = true)]
        private static extern bool AttachThreadInput(uint idAttach, uint idAttachTo, bool fAttach);

        [DllImport("kernel32.dll")]
        private static extern uint GetCurrentThreadId();

        [DllImport("user32.dll")]
        private static extern uint GetWindowThreadProcessId(IntPtr hWnd, out uint lpdwProcessId);

        [DllImport("user32.dll")]
        private static extern bool SetForegroundWindow(IntPtr hWnd);

        [DllImport("user32.dll")]
        private static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);
    }
}