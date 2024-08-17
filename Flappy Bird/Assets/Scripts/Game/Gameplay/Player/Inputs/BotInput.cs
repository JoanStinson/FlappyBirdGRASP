using UnityEngine;

namespace JGM.Game
{
    public class BotInput : IPlayerInput
    {
        public bool Received()
        {
            return Random.Range(0, 400) == 0;
        }
    }
}