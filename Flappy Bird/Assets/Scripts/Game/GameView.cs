using JGM.Engine;
using System;
using System.Threading.Tasks;
using UnityEngine;

namespace JGM.Game
{
    public class GameView : MonoBehaviour
    {
        public GameModel GameModel { get; private set; }

        [SerializeField] private ScreenView m_mainMenuView;
        [SerializeField] private ScreenView m_gameplayView;
        [SerializeField] private ScreenView m_gameOverView;
        
        private IAudioService m_audioService;

        public void Configure(IAudioService audioService)
        {
            m_audioService = audioService;
        }

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
            PlayButtonSfx();
        }

        public void OnChangeThemeButtonClick()
        {
            PlayButtonSfx();
        }

        public void OnUseBotButtonClick()
        {
            GameModel.UseBot = !GameModel.UseBot;
            PlayButtonSfx();
        }

        public void OnQuitButtonClick()
        {
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#else
            Application.Quit();
#endif
        }

        public async void OnPlayerDie()
        {
            await Task.Delay(TimeSpan.FromSeconds(0.5f));
            m_gameOverView.Show();
            m_audioService.PlaySfx("Fall");
        }

        public void OnRestartButtonClick()
        {
            m_gameOverView.Hide();
            m_gameplayView.Show();
            PlayButtonSfx();
        }

        public void OnBackButtonClick()
        {
            m_gameplayView.Hide();
            m_gameOverView.Hide();
            m_mainMenuView.Show();
            PlayButtonSfx();
        }

        private void PlayButtonSfx()
        {
            m_audioService.PlaySfx("Button");
        }
    }
}
