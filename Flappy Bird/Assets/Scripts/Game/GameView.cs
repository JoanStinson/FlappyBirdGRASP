using UnityEngine;

namespace JGM.Game
{
    public class GameView : MonoBehaviour
    {
        public GameModel GameModel { get; private set; }

        [SerializeField] private ScreenView m_mainMenuView;
        [SerializeField] private ScreenView m_gameplayView;
        [SerializeField] private ScreenView m_gameOverView;

        public void Initialize()
        {
            GameModel = new GameModel();

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
            GameModel.UseBot = !GameModel.UseBot;
        }

        public void OnQuitButtonClick()
        {
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#else
            Application.Quit();
#endif
        }

        public void OnPlayerDie()
        {
            m_gameOverView.Show();
        }

        public void OnRestartButtonClick()
        {
            m_gameOverView.Hide();
            m_gameplayView.Show();
        }
    }
}
