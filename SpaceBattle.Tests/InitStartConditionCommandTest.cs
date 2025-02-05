using Hwdtech;
using Hwdtech.Ioc;
using Moq;

namespace SpaceBattle.Lib.Tests;

public class InitStartConditionCommandTest
{
    public InitStartConditionCommandTest()
    {
        new InitScopeBasedIoCImplementationCommand().Execute();
        IoC.Resolve<Hwdtech.ICommand>("Scopes.Current.Set", IoC.Resolve<object>("Scopes.New", IoC.Resolve<object>("Scopes.Root"))).Execute();

        var gameObjects = new Dictionary<object, IUObject>();
        IoC.Resolve<Hwdtech.ICommand>(
            "IoC.Register",
            "GameObjects",
            (object[] args) => gameObjects
        ).Execute();

        IoC.Resolve<Hwdtech.ICommand>(
            "IoC.Register",
            "GameObject.Register",
            (object[] args) => new RegisterGameObjectCommand((IUObject)args[0], args[1])
        ).Execute();

        IoC.Resolve<Hwdtech.ICommand>(
            "IoC.Register",
            "PositionGenerator.Create",
            (object[] args) => new PositionGenerator((int[])args[0]).NextPosition()
        ).Execute();

    }
    [Fact]
    public void SuccessfullyInitStartConditionGame()
    {
        var expectedVectors = new List<Vector>() { new Vector(new int[] { 0, 0 }), new Vector(new int[] { 0, 1 }), new Vector(new int[] { 0, 2 }), new Vector(new int[] { 1, 0 }), new Vector(new int[] { 1, 1 }), new Vector(new int[] { 1, 2 }) };

        var obj = new Mock<IUObject>();
        IoC.Resolve<Hwdtech.ICommand>(
            "IoC.Register",
            "GameObject.Create",
            (object[] args) => obj.Object
        ).Execute();

        var actualVectors = new List<Vector>();
        var mockCommandSetFuel = new Mock<ICommand>();
        IoC.Resolve<Hwdtech.ICommand>(
            "IoC.Register",
            "GameObject.Property.Set",
            (object[] args) => new ActionCommand(() =>
            {
                if ((string)args[1] == "Position")
                {
                    actualVectors.Add((Vector)args[2]);
                }
                else
                {
                    mockCommandSetFuel.Object.Execute();
                }
            })
        ).Execute();

        var volumeFuel = 1;
        IoC.Resolve<Hwdtech.ICommand>(
            "IoC.Register",
            "Game.GetFuelVolume",
            (object[] args) => (object)volumeFuel
        ).Execute();

        var initStartConditionCommand = new InitStartConditionCommand(new int[] { 3, 3 });
        initStartConditionCommand.Execute();

        Assert.Equal(6, IoC.Resolve<IDictionary<object, IUObject>>("GameObjects").Count());
        mockCommandSetFuel.Verify(m => m.Execute(), Times.Exactly(6));
        Assert.True(expectedVectors.SequenceEqual(actualVectors));
    }
}
