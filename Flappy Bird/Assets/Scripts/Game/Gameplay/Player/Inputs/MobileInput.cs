using UnityEngine;

namespace JGM.Game
{
    public class MobileInput : IPlayerInput
    {
        public bool Received()
        {
            return Input.touchCount > 0 &&
                   Input.GetTouch(0).phase == TouchPhase.Began;
        }
    }
}