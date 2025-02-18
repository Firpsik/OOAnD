using Hwdtech;

namespace SpaceBattle;
public class ShootStrategy : IStrategy
{
    public object Run(object[] args)
    {
        var obj = args[0];
        return new ShootCommand(IoC.Resolve<IShootable>("adapter", obj, typeof(IShootable)));
    }
}
