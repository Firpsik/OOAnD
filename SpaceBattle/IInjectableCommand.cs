namespace SpaceBattle;

public interface IInjectableCommand
{
    public void Inject(ICommand obj);
}
