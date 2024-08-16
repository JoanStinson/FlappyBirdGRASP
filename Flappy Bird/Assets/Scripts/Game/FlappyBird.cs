using JGM.Engine;
using UnityEngine;

namespace JGM.Game
{
    public class FlappyBird : MonoBehaviour
    {
        [SerializeField] private PipeSpawner m_pipeSpawner;
        [SerializeField] private Score m_score;
        [SerializeField] private Player m_player;
        [SerializeField] private GameOver m_gameOver;
        [SerializeField] private InfiniteScroller m_infiniteScroller;
        [SerializeField] private Tutorial m_tutorial;
        
        private PlayerPrefsAdapter m_persistenceService;
        private int m_highScore;

        private void Start()
        {
            m_pipeSpawner.OnPlayerPassedPipe += OnPlayerPassedPipe;
            m_player.OnPlayerInputReceived += OnPlayerInputReceived;
            m_player.OnPlayerDie += OnPlayerDie;
            m_gameOver.OnRestartButtonClicked += OnRestartButtonClicked;

            m_pipeSpawner.SpawnPipes();
            m_pipeSpawner.DisableMovement();
            m_infiniteScroller.enabled = false;
            m_tutorial.Show();

            m_persistenceService = new PlayerPrefsAdapter();
            m_highScore = m_persistenceService.LoadInt("HighScore");
        }

        private void OnPlayerPassedPipe()
        {
            m_score.AddScore();
        }

        private void OnPlayerInputReceived()
        {
            m_tutorial.Hide();
            m_pipeSpawner.EnableMovement();
            m_infiniteScroller.enabled = true;
        }

        private void OnPlayerDie()
        {
            m_pipeSpawner.DisableMovement();
            m_infiniteScroller.enabled = false;
            m_gameOver.gameObject.SetActive(true);

            if (m_score.ScoreTotal > m_highScore)
            {
                m_highScore = m_score.ScoreTotal;
                m_persistenceService.SaveInt("HighScore", m_highScore);
            }
            m_gameOver.SetScore(m_score.ScoreTotal, m_highScore);
            new HandheldVibrationAdapter().Trigger();
        }

        private void OnRestartButtonClicked()
        {
            m_pipeSpawner.Restart();            
            m_score.Restart();
            m_player.Restart();
            m_gameOver.gameObject.SetActive(false);
            m_tutorial.Show();
        }
    }
}
