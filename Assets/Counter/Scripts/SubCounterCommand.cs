namespace Counter
{
    public class SubCounterCommand : ICommand
    {
        public void Execute()
        {
            CounterApp.Get<IConterModel>().count.value--;
        }
    }
}