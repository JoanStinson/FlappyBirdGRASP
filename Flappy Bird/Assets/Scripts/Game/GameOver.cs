using System;
using UnityEngine;
using UnityEngine.UI;

namespace JGM.Game
{
    public class GameOver : MonoBehaviour
    {
        public event Action OnRestartButtonClicked;

        [SerializeField] private Button m_restartButton;

        private void Start()
        {
            m_restartButton.onClick.AddListener(OnRestartButtonClick);
        }

        private void OnRestartButtonClick()
        {
            OnRestartButtonClicked?.Invoke();
        }
    }
}
