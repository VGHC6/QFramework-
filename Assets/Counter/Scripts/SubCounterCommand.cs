namespace Counter
{
    public class SubCounterCommand : ICommand
    {
        public void Execute()
        {
            CounterApp.Get<CounterModel>().count.value--;
        }
    }
}