using Hwdtech;

namespace SpaceBattle;
public class InitGameDependenciesStrategy : IStrategy
{
    public object Run(object[] args)
    {
        var commands = IoC.Resolve<IDictionary<string, IStrategy>>("command");

        return new ActionCommand(() =>
        {
            commands.ToList().ForEach(c =>
                IoC.Resolve<Hwdtech.ICommand>("IoC.Register", c.Key, (object[] args) =>
                    c.Value.Run(args)).Execute());
        }
        );
    }
}
