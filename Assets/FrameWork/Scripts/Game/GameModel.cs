namespace FrameWork
{
    public class GameModel : Singleton<GameModel>
    {
        private GameModel() { }
        public BindProerty<int> KillCounter = new BindProerty<int>()
        {
            value = 0
        };
    }
}