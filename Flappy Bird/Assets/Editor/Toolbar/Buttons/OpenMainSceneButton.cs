using UnityEditor.SceneManagement;
using Debug = UnityEngine.Debug;

namespace JGM.Editor
{
    public static class OpenMainSceneButton
    {
        private static string m_mainScenePath = "Assets/Scenes/MainScene.unity";

        [ToolbarButton(IconName = "SceneAsset Icon", Tooltip = "Open Main Scene", Order = 100)]
        public static void OnButtonClick()
        {
            if (System.IO.File.Exists(m_mainScenePath))
            {
                EditorSceneManager.OpenScene(m_mainScenePath);
            }
            else
            {
                Debug.LogError($"Scene not found at path: {m_mainScenePath}");
            }
        }
    }
}