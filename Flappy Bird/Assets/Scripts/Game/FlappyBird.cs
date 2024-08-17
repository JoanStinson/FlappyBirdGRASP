using UnityEngine;

namespace JGM.Game
{
    public class FlappyBird : MonoBehaviour
    {
        [SerializeField] private int m_targetFrameRate = 60;
        [SerializeField] private GameView m_gameView;

        private void Start()
        {
            Application.targetFrameRate = m_targetFrameRate;
            RunGame();
        }

        private void RunGame()
        {
            m_gameView.Initialize();
        }
    }
}
