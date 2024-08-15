using UnityEngine;

namespace JGM.Game
{
    public class FlappyBird : MonoBehaviour
    {
        [SerializeField] private PipeSpawner m_pipeSpawner;
        [SerializeField] private Score m_score;

        private void Start()
        {
            m_pipeSpawner.OnPlayerPassedPipe += AddScore;
        }

        private void AddScore()
        {
            m_score.AddScore();
        }
    }
}
