using DG.Tweening;
using System;
using System.Collections;
using UnityEngine;

namespace JGM.Game
{
    public class Player : MonoBehaviour
    {
        public event Action OnPlayerInputReceived;
        public event Action OnPlayerDie;
        public bool IsDead => m_dead;

        [SerializeField] private Rigidbody2D m_rigidbody2D;
        [SerializeField] private float m_flapStrength = 5f;
        [SerializeField] private float m_pitchAngle = 12f;
        [SerializeField] private float m_rotationSpeed = 6f;
        [SerializeField] private Animator m_animator;
        [SerializeField] private Transform m_rightHitEffect;
        [SerializeField] private Transform m_downHitEffect;
        [SerializeField] private float m_hitEffectDuration = 0.2f;
        [SerializeField] private Camera m_mainCamera;

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
            if (!collision.collider.CompareTag("Enemy") || m_dead)
            {
                return;
            }

            OnPlayerDie?.Invoke();
            m_animator.Play("PlayerHurt");
            m_mainCamera.DOShakePosition(0.2f, 0.1f, 1000);
            m_dead = true;
            m_shouldFlap = false;
        }

        public void Restart()
        {
            transform.position = m_startPosition;
            transform.rotation = Quaternion.identity;
            m_animator.Play("PlayerFly");
            m_dead = false;
            m_canFlap = false;
            m_rigidbody2D.isKinematic = true;
        }

        public void TriggerRightHitEffect()
        {
            StartCoroutine(ShowHitEffect(m_rightHitEffect));
        }

        public void TriggerDownHitEffect()
        {
            StartCoroutine(ShowHitEffect(m_downHitEffect));
        }

        private IEnumerator ShowHitEffect(Transform hitEffect)
        {
            hitEffect.gameObject.SetActive(true);
            yield return new WaitForSeconds(m_hitEffectDuration);
            hitEffect.gameObject.SetActive(false);
        }
    }
}
