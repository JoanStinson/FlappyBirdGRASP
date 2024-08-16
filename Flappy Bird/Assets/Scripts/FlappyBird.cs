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

        private void Start()
        {
            m_pipeSpawner.OnPlayerPassedPipe += OnPlayerPassedPipe;
            m_player.OnPlayerDie += OnPlayerDie;
            m_gameOver.OnRestartButtonClicked += OnRestartButtonClicked;
        }

        private void OnPlayerPassedPipe()
        {
            m_score.AddScore();
        }

        private void OnPlayerDie()
        {
            m_pipeSpawner.DisableMovement();
            m_infiniteScroller.enabled = false;
            m_gameOver.gameObject.SetActive(true);
        }

        private void OnRestartButtonClicked()
        {
            m_pipeSpawner.Restart();
            m_pipeSpawner.EnableMovement();
            m_infiniteScroller.enabled = true;
            m_score.Restart();
            m_player.Restart();
            m_gameOver.gameObject.SetActive(false);
        }
    }
}
