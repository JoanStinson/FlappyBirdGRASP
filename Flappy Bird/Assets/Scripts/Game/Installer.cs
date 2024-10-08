﻿using JGM.Engine;
using UnityEngine;

namespace JGM.Game
{
    public class Installer : MonoBehaviour
    {
        [Header("Services")]
        [SerializeField] private AudioService m_audioServiceInstance;
        [SerializeField] private CoroutineService m_coroutineServiceInstance;

        [Header("Dependencies")]
        [SerializeField] private GameView m_gameView;
        [SerializeField] private GameplayView m_gameplayView;
        [SerializeField] private ScorePanelView m_scorePanelView;
        [SerializeField] private PlayerView m_playerView;

        public void Awake()
        {
            InstallDependencies();
        }

        private void InstallDependencies()
        {
            m_gameView.Configure(m_audioServiceInstance);
            m_gameplayView.Configure(m_audioServiceInstance, new HandheldVibrationAdapter());
            m_scorePanelView.Configure(new PlayerPrefsAdapter());
            m_playerView.Configure(m_audioServiceInstance);
            var hitEffectCommands = m_playerView.GetComponents<HitEffectCommand>();
            foreach (var hitEffectCommand in hitEffectCommands)
            {
                hitEffectCommand.Configure(m_coroutineServiceInstance);
            }
        }
    }
}
