namespace Counter
{
    public struct AddCounterCommand : ICommand
    {
        public void Execute()
        {
            CounterModel.Instance.count.value++;
        }
    }
}