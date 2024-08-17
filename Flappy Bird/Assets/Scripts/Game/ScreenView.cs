using UnityEngine;

namespace JGM.Game
{
    public abstract class ScreenView : MonoBehaviour
    {
        protected GameView m_gameView;

        public virtual void Initialize(GameView gameView)
        {
            m_gameView = gameView;
        }

        public virtual void Show()
        {
            gameObject.SetActive(true);
        }

        public virtual void Hide()
        {
            gameObject.SetActive(false);
        }
    }
}
