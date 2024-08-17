using UnityEngine;

namespace JGM.Game
{
    public class FlappyBird : MonoBehaviour
    {
        [SerializeField] 
        private GameView m_gameView;

        private void Start()
        {
            RunGame();
        }

        private void RunGame()
        {
            m_gameView.Initialize();
        }
    }
}
