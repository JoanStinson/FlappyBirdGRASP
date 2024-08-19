using UnityEngine;

namespace JGM.Game
{
    public class PipeView : MoverView
    {
        [SerializeField] private SpriteRenderer[] m_topBlocks;
        [SerializeField] private SpriteRenderer[] m_downBlocks;

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

        public void SetTheme(Sprite topSprite, Sprite bottomSprite)
        {
            foreach (var block in m_topBlocks)
            {
                block.sprite = topSprite;
            }

            foreach (var downBlock in m_downBlocks)
            {
                downBlock.sprite = bottomSprite;
            }
        }
    }
}
