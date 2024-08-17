using UnityEngine;

namespace JGM.Game
{
    public class ComputerInput : IPlayerInput
    {
        public bool Received()
        {
            return Input.GetMouseButtonDown(0) ||
                   Input.GetKeyDown(KeyCode.Space);
        }
    }
}