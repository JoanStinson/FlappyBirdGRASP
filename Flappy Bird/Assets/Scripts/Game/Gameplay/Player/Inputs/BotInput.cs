using UnityEngine;

namespace JGM.Game
{
    public class BotInput : IPlayerInput
    {
        public bool Received()
        {
            int range = Random.Range(0, 2);
            int maxExclusive = (range == 0) ? 20 : 400;
            return Random.Range(0, maxExclusive) == 0;
        }
    }
}