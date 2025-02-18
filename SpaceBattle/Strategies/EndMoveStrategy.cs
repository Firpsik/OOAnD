using Hwdtech;

namespace SpaceBattle;
public class EndMoveStrategy : IStrategy
{
    public object Run(object[] args)
    {
        var obj = args[0];
        return new EndMoveCommand(IoC.Resolve<IMoveCommandEndable>("adapter", obj, typeof(IMoveCommandEndable)));
    }
}
