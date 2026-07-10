public interface ICommand : IBelongArchitecture, ICanSetArchitecture, ICanGetUtility, ICanGetSystem, ICanGetModel, ICanSendEvent, ICanSendCommand
{
    void Execute();
}

public abstract class AbstructCommand : ICommand
{
    private IArchitecture _architecture;
    void ICommand.Execute()
    {
        OnExecute();
    }

    protected abstract void OnExecute();

    void ICanSetArchitecture.SetArchitecture(IArchitecture architecture)
    {
        _architecture = architecture;
    }

    IArchitecture IBelongArchitecture._GetArchitecture()
    {
        return _architecture;
    }


}