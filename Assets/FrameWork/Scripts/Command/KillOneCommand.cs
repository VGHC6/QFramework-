using FarameWork;
using Framework;
using System.Drawing;

namespace FrameWork{
    public struct KillOneCommand : ICommand
    {
        public void Execute()
        {
            var gameModel= PointGame.Get<IGameModel>();
            gameModel.KillCounter.value++;
            KillOneEnemyEvent.Trigger();

            if (gameModel.KillCounter.value == 10)
            {
                GamePassPanelEvent.Trigger();
            }
        }
    }
}