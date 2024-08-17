using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace JGM.Game
{
    public class GameOverView : ScreenView
    {
        [SerializeField] private TextMeshProUGUI m_scoreText;
        [SerializeField] private TextMeshProUGUI m_highScoreText;
        [SerializeField] private Button m_restartButton;

        public override void Initialize(GameView gameView)
        {
            base.Initialize(gameView);
            m_restartButton.onClick.AddListener(OnRestartButtonClick);
        }

        private void OnRestartButtonClick()
        {
            m_gameView.OnRestartButtonClick();
        }

        public void SetScore(int score, int highScore)
        {
            m_scoreText.text = score.ToString();
            m_highScoreText.text = highScore.ToString();
        }
    }
}
