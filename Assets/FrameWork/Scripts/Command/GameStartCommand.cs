namespace Framework
{
    public class GameStartCommand : AbstructCommand
    {
        protected override void OnExecute()
        {
            this.SendEvent< GameStartPanelEvent >();
        }
    }
}