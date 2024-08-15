using UnityEngine;

namespace JGM.Game
{
    public class Pipe : MonoBehaviour
    {
        private PipeSpawner m_pipeSpawner;

        public void Initialize(PipeSpawner pipeSpawner)
        {
            m_pipeSpawner = pipeSpawner;
        }

        private void Update()
        {
            transform.position -= Vector3.right * Time.deltaTime;

            if (transform.position.x < m_pipeSpawner.LeftScreenLimit.position.x)
            {
                m_pipeSpawner.Return(this);
            }
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (!collision.TryGetComponent<Player>(out var player))
            {
                return;
            }

            m_pipeSpawner.PlayerPassedPipe(this);
        }
    }
}
