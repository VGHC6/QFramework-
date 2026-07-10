namespace Framework
{

    public interface IGameModel:IMode
    {
        public BindProerty<int> KillCounter { get; }
    }

    public class GameModel :AbstructCommand, IGameModel
    {
        BindProerty<int> IGameModel.KillCounter { get; } = new BindProerty<int>
        {
            value = 0
        };

        public void Init()
        {
        }

        protected override void OnExecute()
        {
        }
    }
}