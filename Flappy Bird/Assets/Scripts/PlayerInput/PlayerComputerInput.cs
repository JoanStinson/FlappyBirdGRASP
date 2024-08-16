using UnityEngine;

namespace JGM.Game
{
    public class PlayerComputerInput : IPlayerInput
    {
        public bool Received()
        {
            return Input.GetMouseButtonDown(0) ||
                   Input.GetKeyDown(KeyCode.Space);
        }
    }
}