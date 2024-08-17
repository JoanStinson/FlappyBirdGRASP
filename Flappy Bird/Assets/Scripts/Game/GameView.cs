using UnityEngine;

namespace JGM.Game
{
    public class GameView : MonoBehaviour
    {
        [SerializeField] private ScreenView m_mainMenuView;
        [SerializeField] private ScreenView m_gameplayView;
        [SerializeField] private ScreenView m_gameOverView;

        public void Initialize()
        {
            m_mainMenuView.Initialize(this);
            m_gameplayView.Initialize(this);
            m_gameOverView.Initialize(this);

            m_mainMenuView.Show();
            m_gameplayView.Hide();
            m_gameOverView.Hide();
        }

        public void OnPlayButtonClick()
        {
            m_mainMenuView.Hide();
            m_gameplayView.Show();
        }

        public void OnChangeThemeButtonClick()
        {

        }

        public void OnUseBotButtonClick()
        {

        }

        public void OnRestartButtonClick()
        {
            m_gameOverView.Hide();
            m_gameplayView.Show();
        }

        public void OnPlayerDie()
        {
            m_gameOverView.Show();
        }
    }
}
