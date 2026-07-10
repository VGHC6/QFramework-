namespace Counter
{
    public class CounterApp : Architecture<CounterApp>
    {
        protected override void init()
        {
            RegisterSystem<IAcheivementSystem>(new AcheivementSystem());
            RegisterModel<IStorage>(new PlayerStorage());
            RegisterUtility<IConterModel>(new CounterModel());//使用IConterModel接口注册CounterModel，后续可以直接更改为其他的ICounterModel子类
        }
    }
}