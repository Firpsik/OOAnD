using Hwdtech;
using Hwdtech.Ioc;
using Moq;

namespace SpaceBattle.Tests
{
    public class StartRotateCommandTests
    {
        private readonly Mock<IUObject> uobject;
        private readonly Mock<IRotateCommandStartable> rcs;
        private readonly StartRotateCommand rs;

        public StartRotateCommandTests()
        {
            new InitScopeBasedIoCImplementationCommand().Execute();
            rcs = new Mock<IRotateCommandStartable>();
            uobject = new Mock<IUObject>();
            rcs.Setup(r => r.UObject).Returns(uobject.Object);
            rcs.Setup(r => r.initValues).Returns(new Dictionary<string, object>());
            rs = new StartRotateCommand(rcs.Object);
        }

        [Fact]
        public void LongOperationTest()
        {
            var queue = new Mock<IQueue>();
            var command = new Mock<ICommand>();
            var rotate_command = new Mock<ICommand>();
            var inject_command = new Mock<ICommand>();

            IoC.Resolve<Hwdtech.ICommand>("IoC.Register", "Queue", (object[] args) => queue.Object).Execute();
            IoC.Resolve<Hwdtech.ICommand>("IoC.Register", "UObject.Register", (object[] args) => command.Object).Execute();
            IoC.Resolve<Hwdtech.ICommand>("IoC.Register", "Rotate.Command", (object[] args) => rotate_command.Object).Execute();
            IoC.Resolve<Hwdtech.ICommand>("IoC.Register", "Inject.Command", (object[] args) => inject_command.Object).Execute();

            rs.Execute();
            rcs.Verify(r => r.initValues, Times.Once());
            queue.Verify(q => q.Add(It.IsAny<ICommand>()), Times.Once());
        }
    }
}
