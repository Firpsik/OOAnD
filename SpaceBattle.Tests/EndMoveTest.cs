using Hwdtech;
using Hwdtech.Ioc;
using Moq;

namespace SpaceBattle.Tests;

public class EndCommandTest
{
    public EndCommandTest()
    {
        new InitScopeBasedIoCImplementationCommand().Execute();

        IoC.Resolve<Hwdtech.ICommand>(
            "Scopes.Current.Set",
            IoC.Resolve<object>(
                "Scopes.New",
                IoC.Resolve<object>("Scopes.Root")
            )
        ).Execute();

        IoC.Resolve<Hwdtech.ICommand>(
            "IoC.Register",
            "Game.Command.EndMoveCommand",
            (object[] args) => new EndMoveCommand((IMoveCommandEndable)args[0])
        ).Execute();
    }
    [Fact]
    public void BridgeCommandTest()
    {
        var mCommandOld = new Mock<ICommand>();
        mCommandOld.Setup(m => m.Execute());
        var mCommandNew = new Mock<ICommand>();
        mCommandNew.Setup(m => m.Execute());

        var bridgeCommand = new BridgeCommand(mCommandOld.Object);

        bridgeCommand.Inject(mCommandNew.Object);

        bridgeCommand.Execute();

        mCommandOld.Verify(m => m.Execute(), Times.Never);
        mCommandNew.Verify(m => m.Execute(), Times.Once);
    }

    [Fact]
    public void EndMoveCommandTestSuccessfully()
    {
        var mCommand = new Mock<ICommand>();
        var bridgeCommand = new BridgeCommand(mCommand.Object);

        var mUObject = new Mock<IUObject>();

        var mEndable = new Mock<IMoveCommandEndable>();
        mEndable.Setup(m => m.Move).Returns(bridgeCommand);
        mEndable.Setup(m => m.Object).Returns(mUObject.Object);
        mEndable.Setup(m => m.Properties).Returns(new List<string> { "velocity" });

        var mEmptyCommand = new Mock<ICommand>();
        mEmptyCommand.Setup(e => e.Execute());

        IoC.Resolve<Hwdtech.ICommand>(
            "IoC.Register",
            "Game.Command.EmptyCommand",
            (object[] args) => mEmptyCommand.Object
        ).Execute();

        var mDeletePropertyCommand = new Mock<ICommand>();
        mDeletePropertyCommand.Setup(m => m.Execute());
        IoC.Resolve<Hwdtech.ICommand>(
            "IoC.Register",
            "Game.UObject.DeleteProperty",
            (object[] args) => mDeletePropertyCommand.Object
        ).Execute();

        var endMoveCommand = IoC.Resolve<ICommand>("Game.Command.EndMoveCommand", mEndable.Object);

        endMoveCommand.Execute();

        mDeletePropertyCommand.Verify(m => m.Execute(), Times.Once);
    }

    [Fact]
    public void EndMoveCommandTestFailedGetObject()
    {
        var mCommand = new Mock<ICommand>();
        var bridgeCommand = new BridgeCommand(mCommand.Object);

        var mEndable = new Mock<IMoveCommandEndable>();
        mEndable.Setup(m => m.Move).Returns(bridgeCommand);
        mEndable.Setup(m => m.Object).Throws(new Exception());
        mEndable.Setup(m => m.Properties).Returns(new List<string> { "velocity" });

        var mEmptyCommand = new Mock<ICommand>();
        mEmptyCommand.Setup(e => e.Execute());

        IoC.Resolve<Hwdtech.ICommand>(
            "IoC.Register",
            "Game.Command.EmptyCommand",
            (object[] args) => mEmptyCommand.Object
        ).Execute();

        var mDeletePropertyCommand = new Mock<ICommand>();
        mDeletePropertyCommand.Setup(m => m.Execute());
        IoC.Resolve<Hwdtech.ICommand>(
            "IoC.Register",
            "Game.UObject.DeleteProperty",
            (object[] args) => mDeletePropertyCommand.Object
        ).Execute();

        var endMoveCommand = IoC.Resolve<ICommand>("Game.Command.EndMoveCommand", mEndable.Object);

        Assert.Throws<Exception>(() => endMoveCommand.Execute());
    }
    [Fact]
    public void EndMoveCommandTestFailedGetProperty()
    {
        var mCommand = new Mock<ICommand>();
        var bridgeCommand = new BridgeCommand(mCommand.Object);

        var mUObject = new Mock<IUObject>();

        var mEndable = new Mock<IMoveCommandEndable>();
        mEndable.Setup(m => m.Move).Returns(bridgeCommand);
        mEndable.Setup(m => m.Object).Returns(mUObject.Object);
        mEndable.Setup(m => m.Properties).Throws(new Exception());

        var mEmptyCommand = new Mock<ICommand>();
        mEmptyCommand.Setup(e => e.Execute());

        IoC.Resolve<Hwdtech.ICommand>(
            "IoC.Register",
            "Game.Command.EmptyCommand",
            (object[] args) => mEmptyCommand.Object
        ).Execute();

        var mDeletePropertyCommand = new Mock<ICommand>();
        mDeletePropertyCommand.Setup(m => m.Execute());
        IoC.Resolve<Hwdtech.ICommand>(
            "IoC.Register",
            "Game.UObject.DeleteProperty",
            (object[] args) => mDeletePropertyCommand.Object
        ).Execute();

        var endMoveCommand = IoC.Resolve<ICommand>("Game.Command.EndMoveCommand", mEndable.Object);

        Assert.Throws<Exception>(() => endMoveCommand.Execute());
    }
    [Fact]
    public void EndMoveCommandTestFailedGetCommand()
    {
        var mCommand = new Mock<ICommand>();
        var bridgeCommand = new BridgeCommand(mCommand.Object);

        var mUObject = new Mock<IUObject>();

        var mEndable = new Mock<IMoveCommandEndable>();
        mEndable.Setup(m => m.Move).Throws(new Exception());
        mEndable.Setup(m => m.Object).Returns(mUObject.Object);
        mEndable.Setup(m => m.Properties).Returns(new List<string> { "velocity" });

        var mEmptyCommand = new Mock<ICommand>();
        mEmptyCommand.Setup(e => e.Execute());

        IoC.Resolve<Hwdtech.ICommand>(
            "IoC.Register",
            "Game.Command.EmptyCommand",
            (object[] args) => mEmptyCommand.Object
        ).Execute();

        var mDeletePropertyCommand = new Mock<ICommand>();
        mDeletePropertyCommand.Setup(m => m.Execute());
        IoC.Resolve<Hwdtech.ICommand>(
            "IoC.Register",
            "Game.UObject.DeleteProperty",
            (object[] args) => mDeletePropertyCommand.Object
        ).Execute();

        var endMoveCommand = IoC.Resolve<ICommand>("Game.Command.EndMoveCommand", mEndable.Object);

        Assert.Throws<Exception>(() => endMoveCommand.Execute());
    }
}

