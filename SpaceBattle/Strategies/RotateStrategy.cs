using Hwdtech;

namespace SpaceBattle;
public class RotateStrategy : IStrategy
{
    public object Run(object[] args)
    {
        var obj = args[0];
        return new RotateCommand(IoC.Resolve<IRotable>("adapter", obj, typeof(IRotable)));
    }
}
