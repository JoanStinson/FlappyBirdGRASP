using System.Diagnostics;
using System.IO;
using Debug = UnityEngine.Debug;

namespace JGM.Editor
{
    public static class OpenGitHubDesktopButton
    {
        [ToolbarButton(IconName = "UnityEditor.VersionControl", Tooltip = "Open GitHub Desktop", Order = -10)]
        public static void OnButtonClick()
        {
            string localAppDataPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.LocalApplicationData);
            string gitHubDesktopPath = Path.Combine(localAppDataPath, @"GitHubDesktop\GitHubDesktop.exe");

            try
            {
                if (File.Exists(gitHubDesktopPath))
                {
                    Process.Start(gitHubDesktopPath);
                }
                else
                {
                    Debug.LogError("GitHub Desktop executable not found. Please check the installation.");
                }
            }
            catch (System.Exception ex)
            {
                Debug.LogError($"Failed to open GitHub Desktop. Error: {ex.Message}");
            }
        }
    }
}
