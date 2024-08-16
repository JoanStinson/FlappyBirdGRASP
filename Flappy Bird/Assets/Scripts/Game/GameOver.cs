using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace JGM.Game
{
    public class GameOver : MonoBehaviour
    {
        public event Action OnRestartButtonClicked;

        [SerializeField] private Button m_restartButton;
        [SerializeField] private TextMeshProUGUI m_scoreText;
        [SerializeField] private TextMeshProUGUI m_highScoreText;

        private void Start()
        {
            m_restartButton.onClick.AddListener(OnRestartButtonClick);
        }

        private void OnRestartButtonClick()
        {
            OnRestartButtonClicked?.Invoke();
        }

        public void SetScore(int score, int highScore)
        {
            m_scoreText.text = score.ToString();
            m_highScoreText.text = highScore.ToString();
        }
    }
}
