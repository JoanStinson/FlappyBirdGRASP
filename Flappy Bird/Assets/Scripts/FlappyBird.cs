using UnityEngine;

namespace JGM.Game
{
    public class FlappyBird : MonoBehaviour
    {
        [SerializeField] private PipeSpawner m_pipeSpawner;
        [SerializeField] private Score m_score;
        [SerializeField] private Player m_player;
        [SerializeField] private GameOver m_gameOver;

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
            m_gameOver.gameObject.SetActive(true);
        }

        private void OnRestartButtonClicked()
        {
            m_pipeSpawner.Restart();
            m_score.Restart();
            m_player.Restart();
            m_gameOver.gameObject.SetActive(false);
        }
    }
}
