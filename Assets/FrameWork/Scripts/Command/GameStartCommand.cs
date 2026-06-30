namespace FrameWork
{
    public class GameStartCommand : ICommand
    {
        public void Execute()
        {
            GameStartPanelEvent.Trigger();
        }
    }
}