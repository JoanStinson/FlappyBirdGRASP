using TMPro;
using UnityEngine;

namespace JGM.Game
{
    public class ScoreView : MonoBehaviour
    {
        [SerializeField] 
        private TextMeshProUGUI m_scoreText;

        public void Show(int score)
        {
            m_scoreText.text = score.ToString();
            gameObject.SetActive(true);
        }

        public void Hide()
        {
            gameObject.SetActive(false);
        }
    }
}
