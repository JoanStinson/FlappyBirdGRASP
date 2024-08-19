using UnityEngine;

namespace JGM.Game
{
    public class EnvironmentView : MonoBehaviour
    {
        [SerializeField]
        private EnvironmentTheme[] m_themes;

        private EnvironmentTheme m_currentTheme;

        public void SetTheme(int theme)
        {
            DisableAllThemes();
            m_currentTheme = m_themes[theme];
            m_currentTheme.Root.gameObject.SetActive(true);
        }

        private void DisableAllThemes()
        {
            foreach (var theme in m_themes)
            {
                theme.Root.gameObject.SetActive(false);
                theme.FloorView.StopMoving();
            }
        }

        public void StartMoving()
        {
            m_currentTheme.FloorView.StartMoving();
        }

        public void StopMoving()
        {
            m_currentTheme.FloorView.StopMoving();
        }
    }
}
