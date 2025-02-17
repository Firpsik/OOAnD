using Hwdtech;

namespace SpaceBattle.Lib;

public interface IShootable
{
    Vector Position { get; set; }
    Vector TorpedoVelocity { get; }
}
public class ShootCommand : ICommand
{
    private readonly IShootable _shootable;

    public ShootCommand(IShootable shootable)
    {
        _shootable = shootable;
    }
    public void Execute()
    {
        var torpedo = IoC.Resolve<IUObject>("Game.Create.Torpedo");

        var property = new Dictionary<string, object>()
        {
            {"position", _shootable.Position },
            {"velocity", _shootable.TorpedoVelocity}
        };

        var order = IoC.Resolve<IUObject>("Generate.Order", torpedo, property);
        IoC.Resolve<ICommand>("Command.StartMove", order).Execute();
    }
}
