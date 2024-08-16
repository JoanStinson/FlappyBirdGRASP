using UnityEngine;

namespace JGM.Engine
{
    public class HandheldVibrationAdapter : IVibrationService
    {
        public void Trigger()
        {
#if !UNITY_EDITOR
            Handheld.Vibrate();
#endif
        }
    }
}