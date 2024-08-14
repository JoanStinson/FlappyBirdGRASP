using UnityEngine;

namespace JGM.Game
{
    public class Player : MonoBehaviour
    {
        [SerializeField] private Rigidbody2D m_rigidbody2D;
        [SerializeField] private float m_flapStrength = 5f;

        private bool m_shouldFlap;

        private void Update()
        {
            var playerInput = new PlayerInputBuilder().GetPlayerInput();
            if (playerInput.Pressed())
            {
                m_shouldFlap = true;
            }
        }

        private void FixedUpdate()
        {
            if (m_shouldFlap)
            {
                Flap();
                m_shouldFlap = false;
            }
        }

        private void Flap()
        {
            m_rigidbody2D.velocity = Vector2.zero;
            m_rigidbody2D.AddForce(Vector2.up * m_flapStrength, ForceMode2D.Impulse);
        }
    }
}