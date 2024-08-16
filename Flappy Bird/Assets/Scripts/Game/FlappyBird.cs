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
            new BasicHapticFeedbackService().TriggerVibration();
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
