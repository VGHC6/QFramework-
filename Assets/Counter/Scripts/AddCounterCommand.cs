namespace Counter
{
    public struct AddCounterCommand : ICommand
    {
        public void Execute()
        {
            CounterApp.Get<CounterModel>().count.value++;
        }
    }
}