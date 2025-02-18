using Hwdtech;

namespace SpaceBattle;
public class RegisterDependencies : ICommand
{
    private readonly object _gameId;
    public RegisterDependencies(object gameId)
    {
        _gameId = gameId;
    }
    public void Execute()
    {
        var initDependenciesCommand = IoC.Resolve<ICommand>("initDependecies");
        IoC.Resolve<ICommand>("Queue", _gameId, initDependenciesCommand).Execute();
    }
}
