using UnityEngine;

namespace JGM.Game
{
    public class PlayerComputerInput : IPlayerInput
    {
        public bool Pressed()
        {
            return Input.GetMouseButtonDown(0) ||
                   Input.GetKeyDown(KeyCode.Space);
        }
    }
}