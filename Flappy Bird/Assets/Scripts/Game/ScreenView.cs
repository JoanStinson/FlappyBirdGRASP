using DG.Tweening;
using System;
using System.Threading.Tasks;
using UnityEngine;

namespace JGM.Game
{
    public abstract class ScreenView : MonoBehaviour
    {
        protected GameView m_gameView;
        protected RectTransform m_rectTransform;
        protected GameObject m_rootGameObject;

        private const int m_showPositionInX = -2000;
        private const int m_hidePositionInX = 2000;
        private const float m_animationDuration = 1f;

        public virtual void Initialize(GameView gameView)
        {
            m_gameView = gameView;
            m_rectTransform = gameObject.transform as RectTransform ?? null;
            m_rootGameObject = gameObject;
        }

        public virtual void Show()
        {
            m_rootGameObject.SetActive(true);
            m_rectTransform.DOAnchorPos(new Vector2(m_showPositionInX, 0), 0);
            m_rectTransform.DOAnchorPos(Vector2.zero, m_animationDuration);
        }

        public virtual async void Hide()
        {
            m_rectTransform.DOAnchorPos(new Vector2(m_hidePositionInX, 0), m_animationDuration);
            await Task.Delay(TimeSpan.FromSeconds(m_animationDuration));
            m_rootGameObject.SetActive(false);
        }
    }
}
