namespace Counter
{
    public struct AddCounterCommand : ICommand
    {
        public void Execute()
        {
            CounterApp.Get<IConterModel>().count.value++;
        }
    }
}