using UnityEngine;

namespace JGM.Game
{
    public class FlapCommand : PlayerCommand
    {
        [SerializeField] private Rigidbody2D m_rigidbody2D;
        [SerializeField] private float m_flapStrength = 5f;

        public override void Execute()
        {
            m_rigidbody2D.velocity = Vector2.zero;
            m_rigidbody2D.AddForce(Vector2.up * m_flapStrength, ForceMode2D.Impulse);
        }
    }
}
