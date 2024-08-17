using DG.Tweening;
using JGM.Engine;
using UnityEngine;

namespace JGM.Game
{
    public class GameplayView : ScreenView
    {
        [SerializeField] private RectTransform m_gameplayRectTransform;
        [SerializeField] private PipeSpawnerView m_pipeSpawnerView;
        [SerializeField] private ScoreView m_scoreView;
        [SerializeField] private PlayerView m_playerView;
        [SerializeField] private FloorView m_floorView;
        [SerializeField] private TutorialView m_tutorialView;
        [SerializeField] private AudioService m_audioService;
        [SerializeField] private Camera m_mainCamera;

        private IVibrationService m_vibrationService;

        public override void Initialize(GameView gameView)
        {
            base.Initialize(gameView);
            m_rectTransform = m_gameplayRectTransform;

            m_playerView.Initialize(gameView.GameModel);
            m_playerView.OnPlayerInputReceived += OnPlayerInputReceived;
            m_playerView.OnPlayerDie += OnPlayerDie;

            m_pipeSpawnerView.SpawnPipes();
            m_pipeSpawnerView.OnPlayerPassedPipe += OnPlayerPassedPipe;

            m_audioService.PlayMusic("Background Music");
            m_vibrationService = new HandheldVibrationAdapter();
        }

        private void OnPlayerInputReceived()
        {
            m_tutorialView.Hide();
            m_floorView.StartMoving();
            m_pipeSpawnerView.EnableMovement();
            m_scoreView.Show();
        }

        private void OnPlayerDie()
        {
            m_gameView.OnPlayerDie();
            m_floorView.StopMoving();
            m_pipeSpawnerView.DisableMovement();
            m_vibrationService.Trigger();
            m_mainCamera.DOShakePosition(0.2f, 0.1f, 1000);
        }

        private void OnPlayerPassedPipe()
        {
            m_scoreView.Show(++m_gameView.GameModel.Score);
            m_audioService.PlaySfx("Score");
        }

        public override void Show()
        {
            base.Show();
            m_tutorialView.Show();
            m_pipeSpawnerView.Restart();
            m_scoreView.Hide();
            m_playerView.Restart();
            m_gameView.GameModel.Score = 0;
        }

        public override void Hide()
        {
            base.Hide();
            m_scoreView.Hide();
        }
    }
}
