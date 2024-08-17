using JGM.Engine;
using UnityEngine;

namespace JGM.Game
{
    public class GameplayView : ScreenView
    {
        [SerializeField] private PipeSpawnerView m_pipeSpawnerView;
        [SerializeField] private ScoreView m_scoreView;
        [SerializeField] private PlayerView m_playerView;
        [SerializeField] private FloorView m_floorView;
        [SerializeField] private TutorialView m_tutorialView;
        [SerializeField] private AudioService m_audioService;

        private PlayerPrefsAdapter m_persistenceService;
        private int m_highScore;

        public override void Initialize(GameView gameView)
        {
            base.Initialize(gameView);

            m_pipeSpawnerView.OnPlayerPassedPipe += OnPlayerPassedPipe;
            m_playerView.OnPlayerInputReceived += OnPlayerInputReceived;
            m_playerView.OnPlayerDie += OnPlayerDie;

            m_pipeSpawnerView.SpawnPipes();
            m_scoreView.gameObject.SetActive(false);

            m_persistenceService = new PlayerPrefsAdapter();
            m_highScore = m_persistenceService.LoadInt("HighScore");
            m_audioService.PlayMusic("Background Music");
        }

        private void OnPlayerPassedPipe()
        {
            m_scoreView.gameObject.SetActive(true);
            m_scoreView.AddScore();
            m_audioService.PlaySfx("Score");
        }

        private void OnPlayerInputReceived()
        {
            m_tutorialView.Hide();
            m_floorView.StartMoving();
            m_pipeSpawnerView.EnableMovement();
        }

        private void OnPlayerDie()
        {
            m_floorView.StopMoving();
            m_pipeSpawnerView.DisableMovement();
            m_gameView.OnPlayerDie();

            if (m_scoreView.ScoreTotal > m_highScore)
            {
                m_highScore = m_scoreView.ScoreTotal;
                m_persistenceService.SaveInt("HighScore", m_highScore);
            }
            //m_gameOver.SetScore(m_score.ScoreTotal, m_highScore);
            new HandheldVibrationAdapter().Trigger();
        }

        public override void Show()
        {
            base.Show();
            m_tutorialView.Show();
            m_pipeSpawnerView.Restart();
            m_scoreView.Restart();
            m_playerView.Restart();
            //m_gameOver.gameObject.SetActive(false);
        }
    }
}
