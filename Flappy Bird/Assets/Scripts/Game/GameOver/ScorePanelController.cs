using JGM.Engine;

namespace JGM.Game
{
    public class ScorePanelController
    {
        private readonly IPersistenceService m_persistenceService;

        public ScorePanelController(IPersistenceService persistenceService)
        {
            m_persistenceService = persistenceService;
        }

        public int LoadHighScore()
        {
            return m_persistenceService.LoadInt("HighScore");
        }

        public void SaveHighScore(GameModel gameModel)
        {
            gameModel.HighScore = gameModel.Score;
            m_persistenceService.SaveInt("HighScore", gameModel.HighScore);
        }
    }
}
