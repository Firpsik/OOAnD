namespace SpaceBattle;

public class BridgeCommand : ICommand, IInjectableCommand
{
    private ICommand _internalCommand;
    public BridgeCommand(ICommand command)
    {
        _internalCommand = command;
    }

    public void Inject(ICommand other)
    {
        _internalCommand = other;
    }

    public void Execute()
    {
        _internalCommand.Execute();
    }
}
