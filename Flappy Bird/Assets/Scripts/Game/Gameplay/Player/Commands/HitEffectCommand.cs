using JGM.Engine;
using System.Collections;
using UnityEngine;

namespace JGM.Game
{
    public class HitEffectCommand : PlayerCommand
    {
        [SerializeField] private Transform m_hitEffect;
        [SerializeField] private float m_hitEffectDuration = 0.2f;

        private ICoroutineService m_coroutineService;

        public void Configure(ICoroutineService coroutineService)
        {
            m_coroutineService = coroutineService;
        }

        public override void Execute()
        {
            m_coroutineService.RunCoroutine(ShowHitEffect());
        }

        private IEnumerator ShowHitEffect()
        {
            m_hitEffect.gameObject.SetActive(true);
            yield return new WaitForSeconds(m_hitEffectDuration);
            m_hitEffect.gameObject.SetActive(false);
        }
    }
}
