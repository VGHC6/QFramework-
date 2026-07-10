namespace Counter
{
    public class AddCounterCommand : AbstructCommand
    {
        protected override void OnExecute()
        {
            this.GetModel<IConterModel>().count.value++;
        }
    }
}