

namespace Framework
{
    public class PointGame : Architecture<PointGame>
    {
        protected override void init()
        {
            Register<IGameModel>(new GameModel());
        }
    }
}