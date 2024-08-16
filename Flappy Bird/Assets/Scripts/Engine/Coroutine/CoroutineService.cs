using System.Collections;
using UnityEngine;

namespace JGM.Engine
{
    public class CoroutineService : MonoBehaviour, ICoroutineService
    {
        /// <summary>
        /// Useful for when running coroutines outside MonoBehaviour scripts
        /// </summary>
        /// <param name="coroutine"></param>
        /// <returns></returns>
        public Coroutine RunCoroutine(IEnumerator coroutine)
        {
            return StartCoroutine(coroutine);
        }
    }
}
