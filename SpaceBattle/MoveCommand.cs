namespace SpaceBattle;

public class MoveCommand : ICommand
{
    private readonly IMovable _obj;

    public MoveCommand(IMovable movable)
    {
        _obj = movable;
    }

    public void Execute()
    {
        _obj.Position += _obj.Velocity;
    }
}
