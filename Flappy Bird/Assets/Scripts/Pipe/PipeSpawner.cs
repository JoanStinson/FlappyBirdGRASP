using UnityEngine;

namespace JGM.Game
{
    public class PipeSpawner : MonoBehaviour
    {
        [SerializeField] private Transform m_pipesParent;
        [SerializeField] private Pipe m_pipePrefab;

        private void Start()
        {
            SpawnPipes();
        }

        private void SpawnPipes()
        {
            var pipeInstance = GameObject.Instantiate(m_pipePrefab, m_pipesParent, false);
        }
    }
}
