namespace JGM.Game
{
    public class GameModel
    {
        public int Score { get; set; }
        public int HighScore { get; set; }
        public bool UseBot { get; set; }
        public int Theme { get; private set; }

        public void ChangeTheme()
        {
            Theme++;

            if (Theme >= 3)
            {
                Theme = 0;
            }
        }
    }
}
