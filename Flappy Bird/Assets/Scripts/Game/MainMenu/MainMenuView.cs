using UnityEngine;
using UnityEngine.UI;

namespace JGM.Game
{
    public class MainMenuView : ScreenView
    {
        [SerializeField] private Button m_playButton;
        [SerializeField] private Button m_changeThemeButton;
        [SerializeField] private Button m_useBotButton;

        public override void Initialize(GameView gameView)
        {
            base.Initialize(gameView);
            m_playButton.onClick.AddListener(OnPlayButtonClick);
            m_changeThemeButton.onClick.AddListener(OnChangeThemeButtonClick);
            m_useBotButton.onClick.AddListener(OnUseBotButtonClick);
        }

        private void OnPlayButtonClick()
        {
            m_gameView.OnPlayButtonClick();
        }

        private void OnChangeThemeButtonClick()
        {
            m_gameView.OnChangeThemeButtonClick();
        }

        private void OnUseBotButtonClick()
        {
            m_gameView.OnUseBotButtonClick();
        }
    }
}
