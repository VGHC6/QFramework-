namespace FrameWork
{
    public interface IGameModel
    {
        public BindProerty<int> KillCounter { get; }
    }

    public class GameModel : IGameModel
    {
        BindProerty<int> IGameModel.KillCounter { get; } = new BindProerty<int>
        {
            value = 0
        };
    }
}