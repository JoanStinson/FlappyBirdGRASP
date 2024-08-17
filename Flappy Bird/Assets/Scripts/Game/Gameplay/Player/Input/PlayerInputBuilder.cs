namespace JGM.Game
{
    public class PlayerInputBuilder
    {
        public IPlayerInput GetPlayerInput()
        {
#if UNITY_EDITOR || UNITY_STANDALONE
            return new PlayerComputerInput();
#elif UNITY_IOS || UNITY_ANDROID
            return new PlayerMobileInput();
#endif
        }
    }
}