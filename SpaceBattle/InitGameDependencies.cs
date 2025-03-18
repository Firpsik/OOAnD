using Hwdtech;

namespace SpaceBattle;
public class InitGameDependenciesCommand : ICommand
{
    public void Execute()
    {
        var commands = IoC.Resolve<IDictionary<string, IStrategy>>("command");

        commands.ToList().ForEach(c =>
            IoC.Resolve<Hwdtech.ICommand>("IoC.Register", c.Key, (object[] args) =>
                c.Value.Run(args)).Execute()
        );
    }
}
