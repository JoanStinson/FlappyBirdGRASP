namespace JGM.Editor
{
    public static class OpenPackageManagerButton
    {
        [ToolbarButton(IconName = "Package Manager", Tooltip = "Open Package Manager")]
        public static void OnButtonClick()
        {
            UnityEditor.PackageManager.UI.Window.Open("");
        }
    }
}