using System;
using UnityEngine;

namespace JGM.Game
{
    public class PipeSpawnerView : MonoBehaviour
    {
        public event Action OnPlayerPassedPipe;
        [field: SerializeField] public Transform LeftScreenLimit { get; private set; }
        [field: SerializeField] public Transform SpawnPosition { get; private set; }

        [SerializeField] private Transform m_pipesParent;
        [SerializeField] private PipeView m_pipePrefab;

        private PipeView m_pipeInstance;

        public void SpawnPipes()
        {
            m_pipeInstance = GameObject.Instantiate(m_pipePrefab, m_pipesParent, false);
            m_pipeInstance.Initialize(this);
            Return(m_pipeInstance);
        }

        public void Return(PipeView pipe)
        {
            pipe.transform.position = SpawnPosition.position;
        }

        public void PlayerPassedPipe(PipeView pipe)
        {
            OnPlayerPassedPipe?.Invoke();
        }

        public void Restart()
        {
            Return(m_pipeInstance);
        }

        public void EnableMovement()
        {
            m_pipeInstance.StartMoving();
        }

        public void DisableMovement()
        {
            m_pipeInstance.StopMoving();
        }
    }
}
