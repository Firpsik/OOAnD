using Hwdtech;

namespace SpaceBattle;

public class StartRotateCommand : ICommand
{
    private readonly IRotateCommandStartable obj;
    public StartRotateCommand(IRotateCommandStartable Obj)
    {
        obj = Obj;
    }

    public void Execute()
    {
        obj.initValues.ToList().ForEach(o => IoC.Resolve<ICommand>("UObject.Register", obj.UObject, o.Key, o.Value).Execute());

        var rotate_command = IoC.Resolve<ICommand>("Rotate.Command", obj.UObject);
        var inject_Command = IoC.Resolve<ICommand>("Inject.Command", rotate_command);

        IoC.Resolve<IQueue>("Queue").Add(inject_Command);
    }
}
