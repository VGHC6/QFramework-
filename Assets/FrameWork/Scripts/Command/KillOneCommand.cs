using Framework;

namespace FrameWork{
    public struct KillOneCommand : ICommand
    {
        public void Execute()
        {
            GameModel.Instance.KillCounter.value++;
            KillOneEnemyEvent.Trigger();

            if (GameModel.Instance.KillCounter.value == 10)
            {
                GamePassPanelEvent.Trigger();
            }
        }
    }
}