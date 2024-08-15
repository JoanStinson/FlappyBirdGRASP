using TMPro;
using UnityEngine;

namespace JGM.Game
{
    public class Score : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI m_scoreText;

        private int m_score;

        public void AddScore()
        {
            m_score++;
            m_scoreText.text = m_score.ToString();
        }
    }
}
