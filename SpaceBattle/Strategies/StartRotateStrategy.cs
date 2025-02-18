using Hwdtech;

namespace SpaceBattle;
public class StartRotateStrategy : IStrategy
{
    public object Run(object[] args)
    {
        var obj = args[0];
        return new StartRotateCommand(IoC.Resolve<IRotateCommandStartable>("adapter", obj, typeof(IRotateCommandStartable)));
    }
}
