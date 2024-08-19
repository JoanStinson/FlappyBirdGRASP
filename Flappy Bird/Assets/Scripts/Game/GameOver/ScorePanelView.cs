using JGM.Engine;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace JGM.Game
{
    public class ScorePanelView : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI m_scoreText;
        [SerializeField] private TextMeshProUGUI m_highScoreText;
        [SerializeField] private Transform m_newTag;
        [SerializeField] private Image m_medalSlot;
        [SerializeField] private Sprite[] m_medals;

        private GameModel m_gameModel;
        private ScorePanelController m_scorePanelController;

        public void Configure(IPersistenceService persistenceService)
        {
            m_scorePanelController = new ScorePanelController(persistenceService);
        }

        public void Initialize(GameModel gameModel)
        {
            m_gameModel = gameModel;
            m_gameModel.HighScore = m_scorePanelController.LoadHighScore();
        }

        public void Refresh()
        {
            bool beatHighScore = (m_gameModel.Score > m_gameModel.HighScore);
            if (beatHighScore)
            {
                m_scorePanelController.SaveHighScore(m_gameModel);
            }

            m_newTag.gameObject.SetActive(beatHighScore);
            m_scoreText.text = m_gameModel.Score.ToString();
            m_highScoreText.text = m_gameModel.HighScore.ToString();
            ShowMedal();
        }

        private void ShowMedal()
        {
            switch (m_gameModel.Score)
            {
                case >= 3:
                    m_medalSlot.sprite = m_medals[2];
                    break;

                case 2:
                    m_medalSlot.sprite = m_medals[1];
                    break;

                case 1:
                    m_medalSlot.sprite = m_medals[0];
                    break;

                default:
                    m_medalSlot.sprite = null;
                    break;
            }

            m_medalSlot.gameObject.SetActive(m_medalSlot.sprite != null);
        }
    }
}
