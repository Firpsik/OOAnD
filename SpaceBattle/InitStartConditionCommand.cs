using Hwdtech;

namespace SpaceBattle.Lib;

public class InitStartConditionCommand : ICommand
{
    private readonly int[] _countObject;
    public InitStartConditionCommand(int[] countObject)
    {
        _countObject = countObject;
    }
    public void Execute()
    {
        var positionGenerator = IoC.Resolve<IEnumerable<Vector>>("PositionGenerator.Create", _countObject);
        foreach (var position in positionGenerator)
        {
            var obj = IoC.Resolve<IUObject>("GameObject.Create");
            var id = Guid.NewGuid();

            IoC.Resolve<ICommand>("GameObject.Register", obj, id).Execute();

            IoC.Resolve<ICommand>("GameObject.Property.Set", obj, "Position", position).Execute();
            var fuelVolume = IoC.Resolve<int>("Game.GetFuelVolume");
            IoC.Resolve<ICommand>("GameObject.Property.Set", obj, "Fuel", fuelVolume).Execute();
        }
    }
}
