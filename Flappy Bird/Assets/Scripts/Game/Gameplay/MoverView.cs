using UnityEngine;

namespace JGM.Game
{
    public abstract class MoverView : MonoBehaviour
    {
        private bool m_isMoving;

        public void StartMoving()
        {
            m_isMoving = true;
        }

        public void StopMoving()
        {
            m_isMoving = false;
        }

        private void Update()
        {
            if (m_isMoving)
            {
                Move();
            }
        }

        protected abstract void Move();
    }
}
