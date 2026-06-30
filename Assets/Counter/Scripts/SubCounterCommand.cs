namespace Counter
{
    public class SubCounterCommand : ICommand
    {
        public void Execute()
        {
            CounterModel.Instance.count.value--;
        }
    }
}