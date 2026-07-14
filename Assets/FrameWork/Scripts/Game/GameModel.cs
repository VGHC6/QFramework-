using UnityEngine;
public interface IGameModel : IMode
{
    BindProerty<int> KillCounter { get; }
    BindProerty<int> score { get; }
}

public class GameModel : AbstactMode, IGameModel
{
    public BindProerty<int> KillCounter { get; } = new BindProerty<int>
    {
        value = 0
    };

    public BindProerty<int> score { get; } = new BindProerty<int>
    {
        value = 0
    };

    protected override void OnInit()
    {
        var storage = this.GetUtility<IStorage>();
        score.value = storage.LoadInt(nameof(score), 0);
        score._OnValueChanged += v => storage.SaveInt(nameof(score), v);

    }
}
