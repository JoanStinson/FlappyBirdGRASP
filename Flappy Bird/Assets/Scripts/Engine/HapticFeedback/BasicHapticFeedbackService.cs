using UnityEngine;

namespace JGM.Engine
{
    public class BasicHapticFeedbackService : IHapticFeedbackService
    {
        public void TriggerVibration()
        {
#if !UNITY_EDITOR
            Handheld.Vibrate();
#endif
        }
    }
}