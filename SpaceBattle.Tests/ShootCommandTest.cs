using Hwdtech;
using Hwdtech.Ioc;
using Moq;

namespace SpaceBattle.Lib.Tests;

public class ShootCommandTest
{
    public ShootCommandTest()
    {
        new InitScopeBasedIoCImplementationCommand().Execute();
        IoC.Resolve<Hwdtech.ICommand>("Scopes.Current.Set", IoC.Resolve<object>("Scopes.New", IoC.Resolve<object>("Scopes.Root"))).Execute();

        IoC.Resolve<Hwdtech.ICommand>(
            "IoC.Register",
            "Game.Torpedo.Get",
            (object[] args) =>
            {
                return new Mock<IUObject>().Object;
            }
        ).Execute();

        IoC.Resolve<Hwdtech.ICommand>(
            "IoC.Register",
            "Game.Order.Create",
            (object[] args) =>
            {
                return new Mock<IUObject>().Object;
            }
        ).Execute();

    }
    [Fact]
    public void SuccessfullyShootCommandExecute()
    {
        var shootable = new Mock<IShootable>();
        shootable.Setup(s => s.Position);
        shootable.Setup(s => s.TorpedoVelocity);

        var startMoveCommand = new Mock<ICommand>();
        IoC.Resolve<Hwdtech.ICommand>(
            "IoC.Register",
            "Game.Command.StartMove",
            (object[] args) =>
            {
                return startMoveCommand.Object;
            }
        ).Execute();

        var shootCommand = new ShootCommand(shootable.Object);
        shootCommand.Execute();

        startMoveCommand.Verify(s => s.Execute(), Times.Once);
    }
    [Fact]
    public void FailedShootCommandExecute()
    {
        var shootable = new Mock<IShootable>();
        shootable.Setup(s => s.Position).Throws(new Exception());
        shootable.Setup(s => s.TorpedoVelocity);

        var startMoveCommand = new Mock<ICommand>();
        IoC.Resolve<Hwdtech.ICommand>(
            "IoC.Register",
            "Game.Command.StartMove",
            (object[] args) =>
            {
                return startMoveCommand.Object;
            }
        ).Execute();

        var shootCommand = new ShootCommand(shootable.Object);

        Assert.Throws<Exception>(() => shootCommand.Execute());
        startMoveCommand.Verify(s => s.Execute(), Times.Never);
    }
}
