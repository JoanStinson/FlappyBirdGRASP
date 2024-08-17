namespace JGM.Game
{
    public class PlayerInputBuilder
    {
        public IPlayerInput GetInput()
        {
#if UNITY_EDITOR || UNITY_STANDALONE
            return new ComputerInput();
#elif UNITY_IOS || UNITY_ANDROID
            return new PlayerMobileInput();
#endif
        }
    }
}