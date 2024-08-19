using System;
using UnityEngine;
using Random = UnityEngine.Random;

namespace JGM.Game
{
    public class PipeSpawnerView : MonoBehaviour
    {
        public event Action OnPlayerPassedPipe;
        [field: SerializeField] public Transform LeftScreenLimit { get; private set; }
        [field: SerializeField] public Transform SpawnPosition { get; private set; }

        [SerializeField] private Transform m_pipesParent;
        [SerializeField] private PipeView[] m_pipePrefabs;
        [SerializeField] private Sprite[] m_topSprites;
        [SerializeField] private Sprite[] m_bottomSprites;

        private PipeView[] m_pipeInstances;
        private int m_currentPipe;

        public void Initialize()
        {
            SpawnPipes();
        }

        private void SpawnPipes()
        {
            m_pipeInstances = new PipeView[m_pipePrefabs.Length];

            for (int i = 0; i < m_pipePrefabs.Length; i++)
            {
                m_pipeInstances[i] = GameObject.Instantiate(m_pipePrefabs[i], m_pipesParent, false);
                m_pipeInstances[i].Initialize(this);
                m_pipeInstances[i].transform.position = SpawnPosition.position;
            }
        }

        public void Return(PipeView pipe)
        {
            pipe.transform.position = SpawnPosition.position;
            pipe.StopMoving();
            m_currentPipe = Random.Range(0, m_pipePrefabs.Length);
            m_pipeInstances[m_currentPipe].StartMoving();
        }

        public void PlayerPassedPipe(PipeView pipe)
        {
            OnPlayerPassedPipe?.Invoke();
        }

        public void Restart()
        {
            foreach (var pipeInstance in m_pipeInstances)
            {
                pipeInstance.transform.position = SpawnPosition.position;
                pipeInstance.StopMoving();
            }
        }

        public void StartMoving()
        {
            m_currentPipe = Random.Range(0, m_pipePrefabs.Length);
            m_pipeInstances[m_currentPipe].StartMoving();
        }

        public void StopMoving()
        {
            m_pipeInstances[m_currentPipe].StopMoving();
        }

        public void SetTheme(int theme)
        {
            var topSprite = m_topSprites[theme];
            var bottomSprite = m_bottomSprites[theme];

            foreach(var pipeInstance in m_pipeInstances)
            {
                pipeInstance.SetTheme(topSprite, bottomSprite);
            }
        }
    }
}
