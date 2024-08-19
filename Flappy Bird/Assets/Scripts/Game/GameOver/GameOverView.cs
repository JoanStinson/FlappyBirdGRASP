using UnityEngine;
using UnityEngine.UI;

namespace JGM.Game
{
    public class GameOverView : ScreenView
    {
        [SerializeField] private ScorePanelView m_scorePanelView;
        [SerializeField] private Button m_restartButton;
        [SerializeField] private Button m_changeThemeButton;
        [SerializeField] private Button m_backButton;

        public override void Initialize(GameView gameView)
        {
            base.Initialize(gameView);
            m_scorePanelView.Initialize(gameView.GameModel);
            m_restartButton.onClick.AddListener(OnRestartButtonClick);
            m_changeThemeButton.onClick.AddListener(OnChangeThemeButtonClick);
            m_backButton.onClick.AddListener(OnBackButtonClick);
        }

        private void OnRestartButtonClick()
        {
            m_gameView.OnRestartButtonClick();
        }

        private void OnChangeThemeButtonClick()
        {
            m_gameView.OnChangeThemeButtonClick();
        }

        private void OnBackButtonClick()
        {
            m_gameView.OnBackButtonClick();
        }

        public override void Show()
        {
            base.Show();
            m_scorePanelView.Refresh();
        }
    }
}
