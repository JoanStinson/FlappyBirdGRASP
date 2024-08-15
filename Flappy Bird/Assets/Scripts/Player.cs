using System;
using UnityEngine;

namespace JGM.Game
{
    public class Player : MonoBehaviour
    {
        public event Action OnPlayerDie;
        public bool IsDead => m_dead;

        [SerializeField] private Rigidbody2D m_rigidbody2D;
        [SerializeField] private float m_flapStrength = 5f;

        private bool m_shouldFlap;
        private bool m_dead;
        private Vector3 m_startPosition;

        private void Start()
        {
            m_startPosition = transform.position;   
        }

        private void Update()
        {
            if (m_dead)
            {
                return;
            }

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

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (!collision.collider.CompareTag("Enemy"))
            {
                return;
            }

            OnPlayerDie?.Invoke();
            m_dead = true;
            m_shouldFlap = false;
        }

        public void Restart()
        {
            transform.position = m_startPosition;
            m_dead = false;
        }
    }
}