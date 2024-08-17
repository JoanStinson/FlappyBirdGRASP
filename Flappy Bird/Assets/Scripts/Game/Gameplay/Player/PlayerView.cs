using System;
using UnityEngine;

namespace JGM.Game
{
    public class PlayerView : MonoBehaviour
    {
        public event Action OnPlayerInputReceived;
        public event Action OnPlayerDie;
        public bool IsDead => m_dead;

        [Header("General")]
        [SerializeField] private Animator m_animator;
        [SerializeField] private Rigidbody2D m_rigidbody2D;
        [SerializeField] private Vector3 m_startingPosition;

        [Header("Commands")]
        [SerializeField] private PlayerCommand m_flapCommand;
        [SerializeField] private PlayerCommand m_rotateCommand;
        [SerializeField] private PlayerCommand m_rightHitEffectCommand;
        [SerializeField] private PlayerCommand m_downHitEffectCommand;

        private bool m_shouldFlap;
        private bool m_canFlap;
        private bool m_dead;

        private void Update()
        {
            if (!m_dead)
            {
                HandleInput();
            }
        }

        private void HandleInput()
        {
            var playerInput = new PlayerInputBuilder().GetInput();
            if (playerInput.Received())
            {
                OnPlayerInputReceived?.Invoke();
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
                m_flapCommand.Execute();
                m_shouldFlap = false;
            }

            m_rotateCommand.Execute();
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.collider.CompareTag("Enemy") && !m_dead)
            {
                OnPlayerDie?.Invoke();
                m_animator.Play("PlayerHurt");
                m_dead = true;
                m_shouldFlap = false;
            }
        }

        public void Restart()
        {
            transform.position = m_startingPosition;
            transform.rotation = Quaternion.identity;
            m_animator.Play("PlayerFly");
            m_dead = false;
            m_canFlap = false;
            m_rigidbody2D.isKinematic = true;
        }

        public void TriggerRightHitEffect()
        {
            m_rightHitEffectCommand.Execute();
        }

        public void TriggerDownHitEffect()
        {
            m_downHitEffectCommand.Execute();
        }
    }
}
