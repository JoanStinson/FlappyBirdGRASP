using JGM.Engine;
using System;
using UnityEngine;

namespace JGM.Game
{
    public class PlayerView : MonoBehaviour
    {
        public bool IsDead => m_dead;

        public event Action OnPlayerInputReceived;
        public event Action OnPlayerDie;

        [Header("General")]
        [SerializeField] private Animator m_animator;
        [SerializeField] private Rigidbody2D m_rigidbody2D;
        [SerializeField] private Vector3 m_startingPosition;
        [SerializeField] private Transform m_trail;

        [Header("Commands")]
        [SerializeField] private PlayerCommand m_flapCommand;
        [SerializeField] private PlayerCommand m_rotateCommand;
        [SerializeField] private PlayerCommand m_rightHitEffectCommand;
        [SerializeField] private PlayerCommand m_downHitEffectCommand;

        private IAudioService m_audioService;
        private PlayerInputBuilder m_inputBuilder;
        private GameModel m_gameModel;
        private bool m_receiveInputFirstTime;
        private bool m_shouldFlap;
        private bool m_canFlap;
        private bool m_dead;

        public void Configure(IAudioService audioService)
        {
            m_audioService = audioService;
        }

        public void Initialize(GameModel gameModel)
        {
            m_gameModel = gameModel;
        }

        private void Update()
        {
            if (!m_dead)
            {
                HandleInput();
            }
        }

        private void HandleInput()
        {
            m_inputBuilder ??= new PlayerInputBuilder();
            if (m_inputBuilder.GetInput(m_gameModel.UseBot).Received())
            {
                if (!m_receiveInputFirstTime)
                {
                    OnPlayerInputReceived?.Invoke();
                    m_receiveInputFirstTime = true;
                    m_trail.gameObject.SetActive(true);
                }

                m_shouldFlap = true;
                m_canFlap = true;
                m_rigidbody2D.isKinematic = false;
                m_audioService.PlaySfx("Flap");
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
                m_trail.gameObject.SetActive(false);
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
            m_receiveInputFirstTime = false;
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
