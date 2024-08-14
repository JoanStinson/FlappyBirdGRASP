using UnityEngine;

namespace JGM.Game
{
    public class PlayerMobileInput : IPlayerInput
    {
        public bool Pressed()
        {
            return Input.touchCount > 0 &&
                   Input.GetTouch(0).phase == TouchPhase.Began;
        }
    }
}