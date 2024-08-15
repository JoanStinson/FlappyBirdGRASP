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
        [SerializeField] private float m_pitchAngle = 12f;
        [SerializeField] private float m_rotationSpeed = 6f;

        private Vector3 m_startPosition;
        private bool m_shouldFlap;
        private bool m_canFlap;
        private bool m_dead;

        private void Start()
        {
            m_startPosition = transform.position;
            m_rigidbody2D.isKinematic = true;
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
                m_canFlap = true;
                m_rigidbody2D.isKinematic = false;
            }
        }

        private void FixedUpdate()
        {
            if (!m_canFlap)
            {
                return;
            }

            if (m_shouldFlap)
            {
                Flap();
                m_shouldFlap = false;
            }

            Rotate();
        }

        private void Flap()
        {
            m_rigidbody2D.velocity = Vector2.zero;
            m_rigidbody2D.AddForce(Vector2.up * m_flapStrength, ForceMode2D.Impulse);
        }

        private void Rotate()
        {
            float targetAngle = (m_rigidbody2D.velocity.y > 0) ? m_pitchAngle : -m_pitchAngle;
            Quaternion targetRotation = Quaternion.Euler(0, 0, targetAngle);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, m_rotationSpeed * Time.deltaTime);
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
            transform.rotation = Quaternion.identity;
            m_dead = false;
            m_canFlap = false;
            m_rigidbody2D.isKinematic = true;
        }
    }
}
