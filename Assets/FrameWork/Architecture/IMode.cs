public interface IMode : IBelongArchitecture, ICanSetArchitecture,ICanGetUtility,ICanSendEvent
{
    void Init();
}


public abstract class AbstactMode : IMode
{
    private IArchitecture _architecture;
    void IMode.Init()
    {
        OnInit();
    }

    protected abstract void OnInit();


    void ICanSetArchitecture.SetArchitecture(IArchitecture architecture)
    {
        _architecture = architecture;
    }

    IArchitecture IBelongArchitecture._GetArchitecture()
    {
        return _architecture;
    }
}