namespace SpaceBattle;

public interface IShootable
{
    public Vector Position { get; set; }
    public Vector AmmoVelocity { get; }
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

    }
}
