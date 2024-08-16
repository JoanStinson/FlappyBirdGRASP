using System.Collections;
using UnityEngine;

namespace JGM.Engine
{
    public interface ICoroutineService
    {
        Coroutine RunCoroutine(IEnumerator coroutine);
    }
}
