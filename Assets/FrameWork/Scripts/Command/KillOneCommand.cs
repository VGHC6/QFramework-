namespace Framework
{
    public class KillOneCommand : AbstructCommand
    {
        protected override void OnExecute()
        {
            var gameModel =this.GetModel<IGameModel>();
            gameModel.KillCounter.value++;
            this.SendEvent<KillOneEnemyEvent>();
            //KillOneEnemyEvent.Trigger();

            if (gameModel.KillCounter.value == 10)
            {
                this.SendEvent<GamePassPanelEvent>();

                //GamePassPanelEvent.Trigger();
            }
        }
    }
}