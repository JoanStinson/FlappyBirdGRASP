using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

namespace JGM.Game
{
    public class TutorialView : MonoBehaviour
    {
        [SerializeField] 
        private Image m_tutorialImage;
        
        private Sequence m_sequence;

        public void Show()
        {
            gameObject.SetActive(true);

            if (m_sequence == null)
            {
                m_sequence = DOTween.Sequence();
                m_sequence.Insert(0, m_tutorialImage.DOFade(0f, 0.4f));
                m_sequence.Insert(1, m_tutorialImage.DOFade(1f, 0.4f));
                m_sequence.Insert(2, m_tutorialImage.DOFade(1f, 0.1f));
                m_sequence.SetLoops(-1);
            }

            m_sequence.PlayForward();
        }

        public void Hide()
        {
            gameObject.SetActive(false);
        }
    }
}
