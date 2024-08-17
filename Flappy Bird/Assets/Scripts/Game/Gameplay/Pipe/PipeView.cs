using UnityEngine;

namespace JGM.Game
{
    public class PipeView : MoverView
    {
        private PipeSpawnerView m_pipeSpawner;

        public void Initialize(PipeSpawnerView pipeSpawner)
        {
            m_pipeSpawner = pipeSpawner;
        }

        protected override void Move()
        {
            transform.position -= Vector3.right * Time.deltaTime;

            if (transform.position.x < m_pipeSpawner.LeftScreenLimit.position.x)
            {
                m_pipeSpawner.Return(this);
            }
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.TryGetComponent<PlayerView>(out var player) && !player.IsDead)
            {
                m_pipeSpawner.PlayerPassedPipe(this);
            }
        }
    }
}
