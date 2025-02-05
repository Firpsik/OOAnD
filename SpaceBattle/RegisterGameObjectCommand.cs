using Hwdtech;

namespace SpaceBattle.Lib;

public class RegisterGameObjectCommand : ICommand
{
    private readonly IUObject _obj;
    private readonly object _id;
    public RegisterGameObjectCommand(IUObject obj, object id)
    {
        _obj = obj;
        _id = id;
    }
    public void Execute()
    {
        IoC.Resolve<IDictionary<object, IUObject>>("GameObjects").Add(_id, _obj);
    }
}
