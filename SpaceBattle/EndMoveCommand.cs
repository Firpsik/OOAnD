using Hwdtech;

namespace SpaceBattle;

public class EndMoveCommand : ICommand
{
    private readonly IMoveCommandEndable _endable;
    public EndMoveCommand(IMoveCommandEndable endable)
    {
        _endable = endable;
    }
    public void Execute()
    {
        _endable.Properties.ToList().ForEach(property => IoC.Resolve<ICommand>("Game.UObject.DeleteProperty", _endable.Object, property).Execute());
        _endable.Move.Inject(IoC.Resolve<ICommand>("Game.Command.EmptyCommand"));
    }
}
