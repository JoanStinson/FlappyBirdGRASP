using JGM.Engine;
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

        private IPersistenceService m_persistenceService;
        private GameModel m_gameModel;

        public override void Initialize(GameView gameView)
        {
            base.Initialize(gameView);
            m_persistenceService = new PlayerPrefsAdapter();
            m_gameModel = gameView.GameModel;
            m_gameModel.HighScore = m_persistenceService.LoadInt("HighScore");
            m_restartButton.onClick.AddListener(OnRestartButtonClick);
        }

        private void OnRestartButtonClick()
        {
            m_gameView.OnRestartButtonClick();
        }

        public override void Show()
        {
            base.Show();
            if (m_gameModel.Score > m_gameModel.HighScore)
            {
                m_gameModel.HighScore = m_gameModel.Score;
                m_persistenceService.SaveInt("HighScore", m_gameModel.HighScore);
            }
            m_scoreText.text = m_gameModel.Score.ToString();
            m_highScoreText.text = m_gameModel.HighScore.ToString();
        }
    }
}
