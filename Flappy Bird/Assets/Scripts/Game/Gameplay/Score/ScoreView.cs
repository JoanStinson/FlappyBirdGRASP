using TMPro;
using UnityEngine;

namespace JGM.Game
{
    public class ScoreView : MonoBehaviour
    {
        public int ScoreTotal => m_score;
        
        [SerializeField] private TextMeshProUGUI m_scoreText;

        private int m_score;

        public void AddScore()
        {
            m_score++;
            m_scoreText.text = m_score.ToString();
        }

        public void Restart()
        {
            m_score = 0;
            m_scoreText.text = m_score.ToString();
        }
    }
}
