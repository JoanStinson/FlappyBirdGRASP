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
            m_pipeSpawner.OnPlayerPassedPipe += AddScore;
            m_player.OnPlayerDie += ShowGameOver;
        }

        private void AddScore()
        {
            m_score.AddScore();
        }

        private void ShowGameOver()
        {
            m_gameOver.gameObject.SetActive(true);
        }
    }
}
