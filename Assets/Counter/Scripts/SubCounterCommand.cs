namespace Counter
{
    public class SubCounterCommand : AbstructCommand
    {
        protected override void OnExecute()
        {
            this.GetModel<IConterModel>().count.value--;
        }
    }
}