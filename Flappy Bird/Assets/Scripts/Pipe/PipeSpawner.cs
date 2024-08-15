using UnityEngine;

namespace JGM.Game
{
    public class PipeSpawner : MonoBehaviour
    {
        [field: SerializeField] public Transform LeftScreenLimit { get; private set; }
        [field: SerializeField] public Transform SpawnPosition { get; private set; }

        [SerializeField] private Transform m_pipesParent;
        [SerializeField] private Pipe m_pipePrefab;

        private void Start()
        {
            SpawnPipes();
        }

        private void SpawnPipes()
        {
            var pipeInstance = GameObject.Instantiate(m_pipePrefab, m_pipesParent, false);
            pipeInstance.Initialize(this);
            Return(pipeInstance);
        }

        public void Return(Pipe pipe)
        {
            pipe.transform.position = SpawnPosition.position;
        }
    }
}
