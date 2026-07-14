

namespace Framework
{
    public class PointGame : Architecture<PointGame>
    {
        protected override void init()
        {
            RegisterSystem<ISorageSystem>(new StorageSystem());
            RegisterUtility<IGameModel>(new GameModel());
            RegisterModel<IStorage>(new PlayerPrefsStorage());
        }
    }
}