using DG.Tweening;
using JGM.Engine;
using UnityEngine;

namespace JGM.Game
{
    public class GameplayView : ScreenView
    {
        [Header("General")]
        [SerializeField] private Transform m_playTransform;
        [SerializeField] private Camera m_mainCamera;

        [Header("Sub Views")]
        [SerializeField] private PlayerView m_playerView;
        [SerializeField] private EnvironmentView m_environmentView;
        [SerializeField] private PipeSpawnerView m_pipeSpawnerView;
        [SerializeField] private ScoreView m_scoreView;
        [SerializeField] private TutorialView m_tutorialView;

        private IAudioService m_audioService;
        private IVibrationService m_vibrationService;

        public void Configure(IAudioService audioService, IVibrationService vibrationService)
        {
            m_audioService = audioService;
            m_vibrationService = vibrationService;
        }

        public override void Initialize(GameView gameView)
        {
            base.Initialize(gameView);

            m_playerView.Initialize(gameView.GameModel);
            m_playerView.OnPlayerInputReceived += OnPlayerInputReceived;
            m_playerView.OnPlayerDie += OnPlayerDie;

            m_pipeSpawnerView.Initialize();
            m_pipeSpawnerView.OnPlayerPassedPipe += OnPlayerPassedPipe;

            m_environmentView.SetTheme(gameView.GameModel.Theme);
            m_audioService.PlayMusic("Background Music");
        }

        private void OnPlayerInputReceived()
        {
            m_tutorialView.Hide();
            m_scoreView.Show();
            m_environmentView.StartMoving();
            m_pipeSpawnerView.StartMoving();
        }

        private void OnPlayerDie()
        {
            m_scoreView.Hide();
            m_environmentView.StopMoving();
            m_pipeSpawnerView.StopMoving();
            m_mainCamera.DOShakePosition(0.2f, 0.1f, 1000);
            m_vibrationService.Trigger();
            m_audioService.PlaySfx("Hit");
            m_gameView.OnPlayerDie();
        }

        private void OnPlayerPassedPipe()
        {
            m_scoreView.Show(++m_gameView.GameModel.Score);
            m_audioService.PlaySfx("Score");
        }

        public override void Show()
        {
            m_playerView.Restart();
            m_tutorialView.Show();
            m_scoreView.Hide();
            m_pipeSpawnerView.Restart();
            m_gameView.GameModel.Score = 0;
            m_playTransform.gameObject.SetActive(true);
        }

        public override void Hide()
        {
            m_playTransform.gameObject.SetActive(false);
        }

        public void SetTheme(int theme)
        {
            m_environmentView.SetTheme(theme);
            m_pipeSpawnerView.SetTheme(theme);
        }
    }
}
